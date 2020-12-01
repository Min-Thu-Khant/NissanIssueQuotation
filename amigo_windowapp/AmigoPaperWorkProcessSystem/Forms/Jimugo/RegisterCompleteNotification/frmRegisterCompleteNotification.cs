using AmigoPapaerWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Controllers.RegisterCompleteNotification;
using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.RegisterCompleteNotification
{
    public partial class frmRegisterCompleteNotification : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private string programID = "";
        private string programName = "";
        private string COMPANY_NO_BOX = "";
        private string REQ_SEQ = "";
        private string QUOTATION_DATE = "";
        private string ORDER_DATE = "";
        private string COMPANY_NAME = "";
        #endregion

        #region Properties
        public string COMPLETION_NOTIFICATION_DATE { get; set; }
        public DialogResult Dialog { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }
        #endregion

        #region Constructor
        public frmRegisterCompleteNotification()
        {
            InitializeComponent();
            txtDestinationMailAddress.Enabled = true;
        }

        public frmRegisterCompleteNotification(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }

        public frmRegisterCompleteNotification(string programID, string programName, string company_no_box,string req_seq,string quotation_date,string order_date,string completion_notification_date,string company_name):this()
        {
            this.programID = programID;
            this.programName = programName;

            this.COMPANY_NO_BOX = company_no_box;
            this.REQ_SEQ = req_seq;
            this.QUOTATION_DATE = quotation_date;
            this.ORDER_DATE = order_date;
            this.COMPLETION_NOTIFICATION_DATE = completion_notification_date;
            this.COMPANY_NAME = company_name;
        }
        #endregion
        
        #region BindGrid
        private void BindGrid()
        {
            try
            {
                //assign search keywords
                txtCompanyNoBox.Text =COMPANY_NO_BOX;
                txtCompanyName.Text =COMPANY_NAME;
                txtQuotationIssueDate.Text = QUOTATION_DATE;
                txtOrderDate.Text = ORDER_DATE;
                txtRegisterCompleteNotificationDate.Text = COMPLETION_NOTIFICATION_DATE;

                frmRegisterCompleteNotificationController oController = new frmRegisterCompleteNotificationController();

                DataTable dt = oController.GetScreenData(COMPANY_NO_BOX, out uIUtility.MetaData);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        txtEDIAccount.Text = row["EDI_ACCOUNT"].ToString();
                        txtDestinationMailAddress.Text = row["EMAIL_ADDRESS"].ToString();
                    }
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
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region FormLoad
        private void FrmRegisterCompleteNotification_Load(object sender, EventArgs e)
        {

            //set title
            lblMenu.Text = this.programName;
            this.Text = "[" + programID + "] " + programName;

            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;
            try
            {

                this.Font = Properties.Settings.Default.jimugoFont;
            }
            catch (Exception)
            {
            }

            uIUtility = new UIUtility();
            BindGrid();
            Dialog = DialogResult.Cancel;
        }
        #endregion

        #region PreviewButton
        private async void BtnPreview_Click(object sender, EventArgs e)
        {
           
            if(CheckUtility.SearchConditionCheck(this, lblDestinationMailAddress.Text, txtDestinationMailAddress.Text, false, Utility.DataType.EMAIL, 255, 0))
            {
                frmRegisterCompleteNotificationController oController = new frmRegisterCompleteNotificationController();
                try
                {
                    DataTable result = oController.PreviewFunction(txtCompanyName.Text, txtCompanyNoBox.Text, REQ_SEQ, txtEDIAccount.Text);

                    string return_message="";
                    try
                    {
                        return_message = result.Rows[0]["Message"].ToString();
                    }
                    catch (Exception)
                    {

                    }
                    string FILENAME = "";
                    if (string.IsNullOrEmpty(return_message))
                    {
                        FILENAME = result.Rows[0]["FILENAME"].ToString();
                        MetroMessageBox.Show(this, "\n" + JimugoMessages.I000WB001, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "\n" + return_message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DataTable dt = DTParameter(txtCompanyNoBox.Text, REQ_SEQ, QUOTATION_DATE, ORDER_DATE, COMPLETION_NOTIFICATION_DATE, COMPANY_NAME, txtDestinationMailAddress.Text, txtEDIAccount.Text, FILENAME);

                    #region CallPreviewScreen
                    string temp_deirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"/Temp";

                    if (!Directory.Exists(temp_deirectory))
                    {
                        Directory.CreateDirectory(temp_deirectory);
                    }

                    //delete temp files
                    Utility.DeleteFiles(temp_deirectory);

                    string destinationpath = temp_deirectory + "/" + FILENAME;
                    btnPreview.Enabled = false;
                    bool success = await Core.WebUtility.Download(Properties.Settings.Default.GetTempFile + "?FILENAME=" + FILENAME, destinationpath);
                    if (success)
                    {
                        frmRegisterCompleteNotificationPreview frm = new frmRegisterCompleteNotificationPreview(dt);
                        frm.ShowDialog();
                        this.Show();
                        UPDATED_AT = frm.UPDATED_AT;
                        UPDATED_AT_RAW = frm.UPDATED_AT_RAW;
                        COMPLETION_NOTIFICATION_DATE = txtRegisterCompleteNotificationDate.Text.Trim();
                        Dialog = DialogResult.OK;
                        this.BringToFront();
                    }
                    btnPreview.Enabled = true;
                    #endregion

                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(ex.Message, ex, false);
                }

            }
                
        }
        #endregion

        #region AddToDataTable
        public DataTable DTParameter(string companyNoBox, string reqSeq, string quotationDate, string orderDate, string completionNotificationDate, string companyName, string emailAddress, string ediAccount, string downloadLink)
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

            dt.Rows.Add(companyNoBox,reqSeq,quotationDate, orderDate, completionNotificationDate, companyName, emailAddress, ediAccount, downloadLink);

            return dt;
        }
        #endregion

        #region ClientCertificateButton
        private void BtnClientCertificate_Click(object sender, EventArgs e)
        {
            this.Hide();
            string year = DateTime.Now.Year.ToString();
            frmClientCertificateList frm = new frmClientCertificateList(year,txtCompanyNoBox.Text, "CTS080", "クライアント証明書一覧");
            frm.ShowDialog();
            this.Show();
            //BindGrid(fromDate, toDate);
            this.BringToFront();
        }
        #endregion

        #region FormClosing
        private void FrmRegisterCompleteNotification_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = Dialog;
        }
        #endregion
    }
}
