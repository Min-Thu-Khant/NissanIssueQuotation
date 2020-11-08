using AmigoPaperWorkProcessSystem.Core;
using Spire.PdfViewer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Outlook;
using MetroFramework;
using AmigoPaperWorkProcessSystem.Controllers;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.IssueQuotation
{
    public partial class frmIssueQuotationPrevew : Form
    {
        #region Declare
        private UIUtility uIUtility;
        string COMPANY_NO_BOX = "";
        string REQ_SEQ = "";
        string QUOTATION_DATE = "";
        string ORDER_DATE = "";
        string COMPANY_NAME = "";
        string EMAIL_ADDRESS = "";
        string EDI_ACCOUNT = "";
        string DOWNLOAD_LINK = "";
        string EXPORT_TYPE = "";
        #endregion

        #region Constructors
        public frmIssueQuotationPrevew()
        {
            InitializeComponent();
        }

        public frmIssueQuotationPrevew(DataTable dt)
        {
            InitializeComponent();
            foreach (DataRow row in dt.Rows)
            {
                COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
                REQ_SEQ = row["REQ_SEQ"].ToString();
                QUOTATION_DATE = row["QUOTATION_DATE"].ToString();
                ORDER_DATE = row["ORDER_DATE"].ToString();
                COMPANY_NAME = row["COMPANY_NAME"].ToString();
                EMAIL_ADDRESS = row["EMAIL_ADDRESS"].ToString();
                EDI_ACCOUNT = row["EDI_ACCOUNT"].ToString();
                DOWNLOAD_LINK = row["DOWNLOAD_LINK"].ToString();
                EXPORT_TYPE = row["EXPORT_TYPE"].ToString();
            }
        }
        #endregion

        #region FormLoad
        private void FrmPreviewScreen_Load(object sender, EventArgs e)
        {
            try
            {
                uIUtility = new UIUtility();
                string pdf_deirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Temp\Quotation_temp.pdf";
                switch (EXPORT_TYPE)
                {
                    case "1":
                        pdfInitialQuote.LoadFromFile(pdf_deirectory);
                        tbQuoteType.SelectedIndex = 0;
                        break;
                    case "2":
                        pdfMonthlyQuote.LoadFromFile(pdf_deirectory);
                        tbQuoteType.SelectedIndex = 1;
                        break;
                    case "3":
                        pdfInitialQuote.LoadFromFile(pdf_deirectory);
                        tbQuoteType.SelectedIndex = 0;
                        break;
                    case "4":
                        pdfOrderForm.LoadFromFile(pdf_deirectory);
                        tbQuoteType.SelectedIndex = 2;
                        break;
                }
                
            }
            catch (System.Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }


        }
        #endregion

        #region BackButton
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FrmPreviewScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            pdfInitialQuote.Dispose();
            pdfMonthlyQuote.Dispose();
            pdfOrderForm.Dispose();
        }

        #region btnCreateMail_Click
        private async void btnCreateMail_Click(object sender, EventArgs e)
        {
            string filename = WebUtility.GetFileNamefromURL(DOWNLOAD_LINK);
            DataTable dt = DTRequestDetailUpdate(COMPANY_NO_BOX, REQ_SEQ, QUOTATION_DATE, ORDER_DATE, COMPANY_NAME, EMAIL_ADDRESS, EDI_ACCOUNT, filename);

            //send to web service
            frmIssuQuotationPreviewController oController = new frmIssuQuotationPreviewController();
            try
            {
                string temp_deirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "/Temp/Zip";

                if (!Directory.Exists(temp_deirectory))
                {
                    Directory.CreateDirectory(temp_deirectory);
                }
                //delete temp files
                Utility.DeleteFiles(temp_deirectory);

                //send notification
                DataTable result = oController.SendMailNotification(dt, out uIUtility.MetaData);

                string return_message = "";
                try
                {
                    return_message = result.Rows[0]["Error Message"].ToString();
                }
                catch (System.Exception ex)
                {

                }

                if (string.IsNullOrEmpty(return_message))
                {
                    //download zip file
                    string zipDownloadLink = result.Rows[0]["ZipDownloadLink"].ToString();
                    filename = WebUtility.GetFileNamefromURL(zipDownloadLink);
                    string emailAddressCC = result.Rows[0]["EmailAddressCC"].ToString();
                    string templateString = result.Rows[0]["TemplateString"].ToString();
                    string subjectString = result.Rows[0]["SubjectString"].ToString();

                    string FIleAttachment = temp_deirectory + "/" + filename;
                    bool success = await Core.WebUtility.Download(zipDownloadLink, FIleAttachment);

                    if (success)
                    {
                        #region Outlook Mail Open and Replace
                        Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

                        Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        mailItem.Subject = subjectString; //come from configtable
                        mailItem.To = EMAIL_ADDRESS;
                        mailItem.Body = templateString;
                        mailItem.CC = emailAddressCC;

                        mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                        // make sure a filename was passed
                        if (string.IsNullOrEmpty(FIleAttachment) == false)
                        {
                            // need to check to see if file exists before we attach !
                            if (!File.Exists(FIleAttachment))
                                MessageBox.Show("Attached document " + FIleAttachment + " does not exist", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                               Attachment attachment = mailItem.Attachments.Add(FIleAttachment, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                            }
                        }

                        mailItem.Display(true);
                        #endregion
                    }


                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + return_message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

            catch (System.Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }
        }
        #endregion

        #region Parametere
        public DataTable DTRequestDetailUpdate(string COMPANY_NO_BOX, string REQ_SEQ, string QUOTATION_DATE, string ORDER_DATE, string COMPANY_NAME, string EMAIL_ADDRESS, string EDI_ACCOUNT, String DOWNLOAD_LINK)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("REQ_SEQ");
            dt.Columns.Add("QUOTATION_DATE");
            dt.Columns.Add("ORDER_DATE");
            dt.Columns.Add("COMPANY_NAME");
            dt.Columns.Add("EMAIL_ADDRESS");
            dt.Columns.Add("EDI_ACCOUNT");
            dt.Columns.Add("DOWNLOAD_LINK");
            dt.Rows.Add(COMPANY_NO_BOX, REQ_SEQ, QUOTATION_DATE, ORDER_DATE, COMPANY_NAME, EMAIL_ADDRESS, EDI_ACCOUNT, DOWNLOAD_LINK);

            return dt;
        }
        #endregion
       
    }
}
