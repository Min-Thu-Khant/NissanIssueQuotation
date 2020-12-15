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

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.Issue_Quotation
{
    public partial class frmIssueQuotationPrevew : Form
    {
        #region Declare
        DataTable _paraTable = new DataTable();
        DataTable _exportTable = new DataTable();
        #endregion

        #region Properties
        public DialogResult Dialog { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }
        #endregion

        #region Constructors
        public frmIssueQuotationPrevew()
        {
            InitializeComponent();
        }

        public frmIssueQuotationPrevew(DataTable paraTable, DataTable exportTable)
        {
            InitializeComponent();
            _paraTable = paraTable;
            _exportTable = exportTable;
        }
        #endregion

        #region FormLoad
        private void FrmPreviewScreen_Load(object sender, EventArgs e)
        {
            Dialog = DialogResult.Cancel;

            //theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            try
            {
                for (int i = 0; i < _exportTable.Rows.Count; i++)
                {
                    string strExpType = _exportTable.Rows[i]["ExportType"].ToString();
                    string pdf_deirectory = _exportTable.Rows[i]["LocalPath"].ToString();
                    switch (strExpType)
                    {
                        case "1":
                            pdfInitialQuote.LoadFromFile(pdf_deirectory);
                            break;
                        case "2":
                            pdfMonthlyQuote.LoadFromFile(pdf_deirectory);
                            break;
                        case "3":
                            pdfOrderForm.LoadFromFile(pdf_deirectory);
                            break;
                        case "4":
                            pdfInitialQuote.LoadFromFile(pdf_deirectory);
                            break;
                    }
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

        #region FormClosing
        private void FrmPreviewScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmIssuQuotationPreviewController oController = new frmIssuQuotationPreviewController();
            oController.DeleteTempFiles(_exportTable);
            pdfInitialQuote.Dispose();
            pdfMonthlyQuote.Dispose();
            pdfOrderForm.Dispose();
            this.DialogResult = Dialog;
        }
        #endregion

        #region btnCreateMail_Click
        private void btnCreateMail_Click(object sender, EventArgs e)
        {
            try
            {
                //send to web service
                frmIssuQuotationPreviewController oController = new frmIssuQuotationPreviewController();

                DataTable result = oController.GetQuotationMail(
                      Utility.GetParameterByName("COMPANY_NO_BOX", _paraTable),
                      Utility.GetParameterByName("COMPANY_NAME", _paraTable),
                      Utility.GetParameterByName("REQ_SEQ", _paraTable),
                      Utility.GetParameterByName("CONSUMPTION_TAX", _paraTable),
                      Utility.GetParameterByName("INITIAL_SPECIAL_DISCOUNT", _paraTable),
                      Utility.GetParameterByName("MONTHLY_SPECIAL_DISCOUNT", _paraTable),
                      Utility.GetParameterByName("YEARLY_SPECIAL_DISCOUNT", _paraTable),
                      Utility.GetParameterByName("EMAIL_ADDRESS" , _paraTable),
                      Utility.GetParameterByName("INPUT_PERSON", _paraTable),
                      Utility.DtToJSon(_exportTable, "Export Table"),
                      Utility.GetParameterByName("CONTRACT_PLAN", _paraTable),
                      Utility.GetParameterByName("Created Time", _paraTable),
                      Utility.GetParameterByName("PERIOD_FROM", _paraTable),
                      Utility.GetParameterByName("PERIOD_TO", _paraTable)
                    );

                string error_message = Convert.ToString(result.Rows[0]["Error Message"]);

                if (string.IsNullOrEmpty(error_message))
                {

                    string emailAddressCC = Convert.ToString(result.Rows[0]["EmailAddressCC"]);
                    string templateString = Convert.ToString(result.Rows[0]["TemplateString"]);
                    string subjectString = Convert.ToString(result.Rows[0]["SubjectString"]);

                    #region Open Outlook mail Client
                    Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

                    MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);

                    mailItem.Subject = subjectString; //come from configtable
                    mailItem.To = Utility.GetParameterByName("EMAIL_ADDRESS", _paraTable);
                    mailItem.Body = templateString;
                    mailItem.CC = emailAddressCC;

                    mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;

                    for (int i = 0; i < _exportTable.Rows.Count; i++)
                    {
                        string filepath = Convert.ToString(_exportTable.Rows[i]["localPath"]);
                        if (!string.IsNullOrEmpty(filepath))
                        {
                            // need to check to see if file exists before we attach
                            if (!File.Exists(filepath))
                                MessageBox.Show("Attached document " + filepath + " does not exist", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                Attachment attachment = mailItem.Attachments.Add(filepath, OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                            }
                        }
                    }
                    mailItem.Display(false);
                    #endregion
                    Dialog = DialogResult.OK;
                    UPDATED_AT = Convert.ToString(result.Rows[0]["UPDATED_AT"]);
                    UPDATED_AT_RAW = Convert.ToString(result.Rows[0]["UPDATED_AT_RAW"]);
                }
                else
                {
                    MetroMessageBox.Show(this, "\n" + error_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dialog = DialogResult.Cancel;
                }
            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
       
    }
}
