using AmigoPaperWorkProcessSystem.Controllers.PurchaseOrder;
using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using System;
using System.Data;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.OrderRegistration
{
    public partial class frmPurchaseOrder : Form
    {
        #region Declare
        private UIUtility uIUtility;
        #endregion

        #region Properties
        public string ORDER_DATE { get; set; }
        public string ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string REQ_SEQ { get; set; }
        public string CONTRACT_PLAN { get; set; }
        public string AMIGO_COOPERATION_CHENGED_ITEMS { get; set; }
        public DialogResult Dialog { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }

        #endregion

        #region Constructor
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        public frmPurchaseOrder(string programID, string programName, string COMPANY_NO_BOX, string REQ_SEQ, string QUOTATION_DATE, string ORDER_DATE, string REGIESTER_COMPLETE_NOTI_DATE, string COMPANY_NAME) : this()
        {
            this.ProgramID = programID;
            this.ProgramName = programName;
            txtCompanyNoBox.Text = COMPANY_NO_BOX;
            txtCompanyName.Text = COMPANY_NAME;
            txtQuotationIssueDate.Text = QUOTATION_DATE;
            txtOrderDate.Text = string.IsNullOrEmpty(ORDER_DATE) ? DateTime.Now.ToString("yyyy/MM/dd") : ORDER_DATE;
            txtCompleteNotificationDate.Text = REGIESTER_COMPLETE_NOTI_DATE;
            this.REQ_SEQ = REQ_SEQ;
        }
        #endregion

        #region FormLoad
        private void FrmOrderRegistration_Load(object sender, EventArgs e)
        {
            Dialog = DialogResult.Cancel;
            //set title
            lblMenu.Text = this.ProgramName;
            this.Text = "[" + ProgramID + "] " + ProgramName;

            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            //font
            try
            {

                this.Font = Properties.Settings.Default.jimugoFont;
            }
            catch (Exception)
            {

            }
            
            uIUtility = new UIUtility();
            //get initial data from web service
            BindData(txtCompanyNoBox.Text, REQ_SEQ);
            Dialog = DialogResult.Cancel;
        }
        #endregion

        #region PreviewButton
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF|*.pdf";
            openFile.Multiselect = false;
            try
            {
                bool validation = false;
                DataTable parameters = GetParameters(out validation);
                if (validation)
                {
                    if (openFile.ShowDialog() == DialogResult.OK) // save as dialog
                    {
                        parameters.Rows[0]["PDF_FILE_PATH"] = openFile.FileName;

                        frmPurchaseOrderPreview frm = new frmPurchaseOrderPreview(parameters);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            this.ORDER_DATE = frm.ORDER_DATE;
                            Dialog = DialogResult.OK;
                            txtOrderDate.Text = this.ORDER_DATE;
                            UPDATED_AT = frm.UPDATED_AT;
                            UPDATED_AT_RAW = frm.UPDATED_AT_RAW;
                        }
                        else
                        {
                            this.ORDER_DATE = null;
                            Dialog = DialogResult.Cancel;
                        }

                        this.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }
            finally
            {
                openFile.Dispose();
            }
        }
        #endregion

        #region BindData
        public void BindData(string COMPANY_NO_BOX, string REQ_SEQ)
        {
            try
            {
                frmPruchaseOrderController oController = new frmPruchaseOrderController();
                DataTable dt = oController.GetSearchItem(txtCompanyNoBox.Text.Trim(), REQ_SEQ, out uIUtility.MetaData);
                if (dt.Rows.Count > 0)
                {
                    //assign data to text boxes and variables
                    txtEDIAccount.Text = dt.Rows[0]["EDI_ACCOUNT"].ToString();
                    txtTransactionType.Text = dt.Rows[0]["TRANSACTION_TYPE"].ToString();
                    txtStartUseDate.Text = dt.Rows[0]["START_USE_DATE"].ToString();
                    txtREQ_TYPE.Text = dt.Rows[0]["REQ_TYPE"].ToString();
                    AMIGO_COOPERATION_CHENGED_ITEMS = dt.Rows[0]["AMIGO_COOPERATION_CHENGED_ITEMS"].ToString();
                    CONTRACT_PLAN = dt.Rows[0]["CONTRACT_PLAN"].ToString();
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

        #region AddToDataTable
        public DataTable GetParameters(out bool valid)
        {
            valid = false;
            DataTable dt = new DataTable();
            dt.Columns.Add("COMPANY_NO_BOX");
            dt.Columns.Add("COMPANY_NAME");
            dt.Columns.Add("TRANSACTION_TYPE");
            dt.Columns.Add("REQ_TYPE");
            dt.Columns.Add("START_USE_DATE");
            dt.Columns.Add("REQ_SEQ");
            dt.Columns.Add("ORDER_DATE");
            dt.Columns.Add("SYSTEM_EFFECTIVE_DATE");
            dt.Columns.Add("SYSTEM_REGISTER_DEADLINE");
            dt.Columns.Add("PDF_FILE_PATH");
            dt.Columns.Add("AMIGO_COOPERATION_CHENGED_ITEMS");
            dt.Columns.Add("CONTRACT_PLAN");

            //validate inputs
            string COMPANY_NO_BOX, COMPANY_NAME, TRANSACTION_TYPE, REQ_TYPE, ORDER_DATE, EFFECTIVE_DATE, REGISTERATION_DAEADLINE, START_USE_DATE;

            if (ValidateInputs(out ORDER_DATE, out EFFECTIVE_DATE, out REGISTERATION_DAEADLINE, out COMPANY_NO_BOX, out COMPANY_NAME, out TRANSACTION_TYPE, out REQ_TYPE, out START_USE_DATE))
            {
                valid = true;
            }

            DataRow dr = dt.NewRow();
            dr["COMPANY_NO_BOX"] = COMPANY_NO_BOX;
            dr["COMPANY_NAME"] = COMPANY_NAME;
            dr["TRANSACTION_TYPE"] = TRANSACTION_TYPE;
            dr["REQ_TYPE"] = REQ_TYPE;
            dr["REQ_SEQ"] = REQ_SEQ;
            dr["ORDER_DATE"] = ORDER_DATE;
            dr["SYSTEM_EFFECTIVE_DATE"] = EFFECTIVE_DATE;
            dr["SYSTEM_REGISTER_DEADLINE"] = REGISTERATION_DAEADLINE;
            dr["PDF_FILE_PATH"] = "";
            dr["AMIGO_COOPERATION_CHENGED_ITEMS"] = "";
            dr["CONTRACT_PLAN"] = CONTRACT_PLAN;
            dr["START_USE_DATE"] = START_USE_DATE;

            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        #region Validate Inputs
        private bool ValidateInputs(out string ORDER_DATE, out string EFFECTIVE_DATE, out string REGISTERATION_DAEADLINE, out string COMPANY_NO_BOX, out string COMPANY_NAME, out string TRANSACTION_TYPE, out string REQ_TYPE, out string START_USE_DATE)
        {
            ORDER_DATE = txtOrderDate.Text.Trim();
            EFFECTIVE_DATE = txtSystemEffectiveDate.Text.Trim();
            REGISTERATION_DAEADLINE = txtSystemRegisterDeadline.Text.Trim();
            COMPANY_NO_BOX = txtCompanyNoBox.Text.Trim();
            COMPANY_NAME = txtCompanyName.Text.Trim();
            TRANSACTION_TYPE = txtTransactionType.Text.Trim();
            REQ_TYPE = txtREQ_TYPE.Text.Trim();
            START_USE_DATE = txtStartUseDate.Text.Trim();

            if (!CheckUtility.SearchConditionCheck(this, lblOrderDate.Text, ORDER_DATE, false, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblSystemEffectiveDate.Text, EFFECTIVE_DATE, false, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblSystemRegisterDeadline.Text, REGISTERATION_DAEADLINE, false, Utility.DataType.TIMESTAMP, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblStartUseDate.Text, START_USE_DATE, false, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            return true;
            
        }

        #endregion

        #region FormClosing
        private void FrmOrderRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = Dialog;
        }
        #endregion
    }
}
