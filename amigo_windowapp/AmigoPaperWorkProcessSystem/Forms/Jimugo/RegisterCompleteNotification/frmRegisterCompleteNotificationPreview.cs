using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Controllers.RegisterCompleteNotification;
using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exception = System.Exception;
using Outlook = Microsoft.Office.Interop.Outlook;
using WebUtility = AmigoPaperWorkProcessSystem.Core.WebUtility;

namespace AmigoPaperWorkProcessSystem.Forms.RegisterCompleteNotification
{
    public partial class frmRegisterCompleteNotificationPreview : Form
    {
        #region Declare
        private UIUtility uIUtility;
        string COMPANY_NO_BOX="";
        string REQ_SEQ = "";
        string QUOTATION_DATE = "";
        string ORDER_DATE = "";
        string COMPLETION_NOTIFICATION_DATE = "";
        string COMPANY_NAME = "";
        string EMAIL_ADDRESS = "";
        string EDI_ACCOUNT = "";
        string FILENAME = "";
        #endregion

        #region Constructors
        public frmRegisterCompleteNotificationPreview()
        {
            InitializeComponent();
        }

        public frmRegisterCompleteNotificationPreview(DataTable dt)
           : this()
        {
            foreach (DataRow row in dt.Rows)
            {
                COMPANY_NO_BOX = row["COMPANY_NO_BOX"].ToString();
                REQ_SEQ = row["REQ_SEQ"].ToString();
                QUOTATION_DATE = row["QUOTATION_DATE"].ToString(); 
                ORDER_DATE = row["ORDER_DATE"].ToString();
                COMPLETION_NOTIFICATION_DATE = row["COMPLETION_NOTIFICATION_DATE"].ToString();
                COMPANY_NAME = row["COMPANY_NAME"].ToString();
                EMAIL_ADDRESS = row["EMAIL_ADDRESS"].ToString();
                EDI_ACCOUNT = row["EDI_ACCOUNT"].ToString();
                FILENAME = row["FILENAME"].ToString();

            }
        }

        #endregion

        #region Properties
        public DialogResult Dialog { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }
        #endregion

        #region FormLoad
        private void FrmPreviewScreen_Load(object sender, EventArgs e)
        {
            try
            {
                //theme
                this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
                this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

                uIUtility = new UIUtility();
                string pdf_deirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"/Temp/" + FILENAME;
                pdfDocumentViewer.LoadFromFile(pdf_deirectory);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }

            Dialog = DialogResult.Cancel;
        }
        #endregion

        #region ButtonCreateMail
        private async void BtnCreateMail_Click(object sender, EventArgs e)
        {

            DataTable dt = DTRequestDetailUpdate(COMPANY_NO_BOX, REQ_SEQ, QUOTATION_DATE, ORDER_DATE, COMPLETION_NOTIFICATION_DATE, COMPANY_NAME, EMAIL_ADDRESS, EDI_ACCOUNT, FILENAME);

            //send to web service
            frmRegisterCompleteNotificationPreviewController oController = new frmRegisterCompleteNotificationPreviewController();
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
                catch (Exception)
                {

                }

                if (string.IsNullOrEmpty(return_message))
                {
                    //download zip file
                    string ZipFileName = result.Rows[0]["ZipFileName"].ToString();
                    string emailAddressCC = result.Rows[0]["EmailAddressCC"].ToString();
                    string templateString = result.Rows[0]["TemplateString"].ToString();
                    string subjectString = result.Rows[0]["SubjectString"].ToString();

                    string FIleAttachment = temp_deirectory + "/" + ZipFileName;
                    bool success = await Core.WebUtility.Download(Properties.Settings.Default.GetTempFile + "?FILENAME=" + ZipFileName, FIleAttachment);

                    if (success)
                    {
                        #region Outlook Mail Open and Replace
                        Outlook.Application outlookApp = new Outlook.Application();

                        Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                        mailItem.Subject = subjectString; //come from configtable
                        mailItem.To = EMAIL_ADDRESS;
                        mailItem.Body = templateString;
                        mailItem.CC = emailAddressCC;

                        mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
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

                        mailItem.Display(false);
                        #endregion
                        Dialog = DialogResult.OK;
                        this.UPDATED_AT = result.Rows[0]["UPDATED_AT"].ToString();
                        this.UPDATED_AT_RAW = result.Rows[0]["UPDATED_AT_RAW"].ToString();
                    }


                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + return_message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }
        }
        #endregion

        #region Parametere
        public DataTable DTRequestDetailUpdate(string COMPANY_NO_BOX, string REQ_SEQ, string QUOTATION_DATE, string ORDER_DATE, string COMPLETION_NOTIFICATION_DATE, string COMPANY_NAME, string EMAIL_ADDRESS, string EDI_ACCOUNT,String DOWNLOAD_LINK)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("REQ_SEQ");
            dt.Columns.Add("QUOTATION_DATE");
            dt.Columns.Add("ORDER_DATE");
            dt.Columns.Add("COMPLETION_NOTIFICATION_DATE");
            dt.Columns.Add("COMPANY_NAME");
            dt.Columns.Add("EMAIL_ADDRESS");
            dt.Columns.Add("EDI_ACCOUNT");
            dt.Columns.Add("FILENAME");
            dt.Rows.Add(COMPANY_NO_BOX,  REQ_SEQ,  QUOTATION_DATE,  ORDER_DATE,  COMPLETION_NOTIFICATION_DATE,  COMPANY_NAME,  EMAIL_ADDRESS,  EDI_ACCOUNT, DOWNLOAD_LINK);

            return dt;
        }
        #endregion


        private void BtnBack_Click(object sender, EventArgs e)
        {
            Dialog = DialogResult.Cancel; 
            this.Close();
        }

        private void FrmPreviewScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRegisterCompleteNotificationController oController = new frmRegisterCompleteNotificationController();
            oController.DeleteTempFiles(FILENAME);
            pdfDocumentViewer.Dispose();
            this.DialogResult = Dialog;
        }
    }
}
