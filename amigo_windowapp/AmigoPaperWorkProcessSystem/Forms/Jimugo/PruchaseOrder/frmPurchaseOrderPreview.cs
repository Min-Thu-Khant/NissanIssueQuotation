using AmigoPaperWorkProcessSystem.Controllers.PurchaseOrder;
using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using System;
using System.Data;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frmPurchaseOrderPreview : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private DataTable PARAMETERS;
        #endregion

        #region Properties
        public string ORDER_DATE { get; set; }
        public DialogResult Dialog { get; set; }
        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }
        #endregion

        #region Constructor
        public frmPurchaseOrderPreview()
        {
            InitializeComponent();
        }
        public frmPurchaseOrderPreview(DataTable PARAMETERS) : this()
        {
            this.PARAMETERS = PARAMETERS;

            //set to cancel initial
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region GetParameterByName
        private string GetParameterByName(string key)
        {
            try
            {
                return PARAMETERS.Rows[0][key].ToString();
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                return "";
            }
        }
        #endregion

        #region SetTextBoxesFromParameters
        private void SetTextBoxesFromParameters()
        {
            string ORDER_DATE = GetParameterByName("ORDER_DATE");
            txtOrderDate.Text = string.IsNullOrEmpty(ORDER_DATE) ? DateTime.Now.ToString("yyyy/MM/dd") : ORDER_DATE;
            txtSystemEffectiveDate.Text = GetParameterByName("SYSTEM_EFFECTIVE_DATE");
            txtSystemRegisterDeadline.Text = GetParameterByName("SYSTEM_REGISTER_DEADLINE");
            txtTransactionType.Text = GetParameterByName("TRANSACTION_TYPE");
            txtREQ_TYPE.Text = GetParameterByName("REQ_TYPE");
            txtStartUseDate.Text = GetParameterByName("START_USE_DATE");
        }
        #endregion

        #region FormLoad
        private void FrmRegisterPreview_Load(object sender, EventArgs e)
        {
            Dialog = DialogResult.Cancel;
            uIUtility = new UIUtility();

            //theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            //load pdf
            try
            {
                pdfDocViewer.LoadFromFile(GetParameterByName("PDF_FILE_PATH"));
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }

            //set text box value from main screen
            SetTextBoxesFromParameters();

            
        }
        #endregion

        #region FormClosing
        private void FrmOrderRegistrationPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.pdfDocViewer.Dispose();
            this.DialogResult = Dialog;
        }
        #endregion

        #region BackButton
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region RegisterButton
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            //Validate textboxes
            if (ValidateInputs())
            {
                frmPurchaseOrderPreviewController oController = new frmPurchaseOrderPreviewController();
                try
                {
                    DataTable result = oController.Submit(PARAMETERS, GetParameterByName("PDF_FILE_PATH"), "pdf");
                    string message = Convert.ToString(result.Rows[0]["Message"]);
                    string error_message = Convert.ToString(result.Rows[0]["Error Message"]);

                    if (!string.IsNullOrEmpty(result.Rows[0]["Message"].ToString()))
                    {
                        Dialog = DialogResult.OK;
                        this.ORDER_DATE = txtOrderDate.Text.Trim();
                        this.UPDATED_AT = result.Rows[0]["UPDATED_AT"].ToString();
                        this.UPDATED_AT_RAW = result.Rows[0]["UPDATED_AT_RAW"].ToString();
                        MetroMessageBox.Show(this, "\n" + message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (!string.IsNullOrEmpty(result.Rows[0]["Error Message"].ToString()))
                    {
                        Dialog = DialogResult.Cancel;
                        this.ORDER_DATE = null;
                        MetroMessageBox.Show(this, "\n" + error_message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(ex.Message, ex, false);
                    MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Validate Inputs
        private bool ValidateInputs()
        {
            //assign values
            string ORDER_DATE = txtOrderDate.Text.Trim();
            string SYSTEM_EFFECTIVE_DATE = txtSystemEffectiveDate.Text.Trim();
            string SYSTEM_REGISTER_DEADLINE = txtSystemRegisterDeadline.Text.Trim();
            string TRANSACTION_TYPE = txtTransactionType.Text.Trim();
            string REQ_TYPE = txtREQ_TYPE.Text.Trim();
            string START_USE_DATE = txtStartUseDate.Text.Trim();

            //validate

            if (!CheckUtility.SearchConditionCheck(this, lblOrderDate.Text, ORDER_DATE, true, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblSystemEffectiveDate.Text, SYSTEM_EFFECTIVE_DATE, true, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblSystemRegisterDeadline.Text, SYSTEM_REGISTER_DEADLINE, true, Utility.DataType.TIMESTAMP, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblTransactionType.Text, TRANSACTION_TYPE, true, Utility.DataType.HALF_NUMBER, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblREQ_TYPE.Text, REQ_TYPE, true, Utility.DataType.HALF_NUMBER, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblStartUseDate.Text, START_USE_DATE, true, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            //update parameters
            PARAMETERS.Rows[0]["ORDER_DATE"] = ORDER_DATE;
            PARAMETERS.Rows[0]["SYSTEM_EFFECTIVE_DATE"] = SYSTEM_EFFECTIVE_DATE;
            PARAMETERS.Rows[0]["SYSTEM_REGISTER_DEADLINE"] = SYSTEM_REGISTER_DEADLINE;
            PARAMETERS.Rows[0]["TRANSACTION_TYPE"] = TRANSACTION_TYPE;
            PARAMETERS.Rows[0]["REQ_TYPE"] = REQ_TYPE;
            PARAMETERS.Rows[0]["START_USE_DATE"] = START_USE_DATE;

            return true;
        }
        #endregion
    }
}
