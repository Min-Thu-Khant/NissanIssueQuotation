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

        #region SetTextBoxesFromParameters
        private void SetTextBoxesFromParameters()
        {
            string ORDER_DATE = Utility.GetParameterByName("ORDER_DATE", PARAMETERS);
            txtOrderDate.Text = string.IsNullOrEmpty(ORDER_DATE) ? DateTime.Now.ToString("yyyy/MM/dd") : ORDER_DATE;
            txtSystemEffectiveDate.Text = Utility.GetParameterByName("SYSTEM_EFFECTIVE_DATE", PARAMETERS);
            txtSystemRegisterDeadline.Text = Utility.GetParameterByName("SYSTEM_REGISTER_DEADLINE", PARAMETERS);
            txtTransactionType.Text = Utility.GetParameterByName("TRANSACTION_TYPE", PARAMETERS);
            txtREQ_SEQ.Text = Utility.GetParameterByName("REQ_SEQ", PARAMETERS);
            txtStartUseDate.Text = Utility.GetParameterByName("START_USE_DATE", PARAMETERS);
        }
        #endregion

        #region FormLoad
        private void FrmRegisterPreview_Load(object sender, EventArgs e)
        {
            uIUtility = new UIUtility();

            //theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            //load pdf
            try
            {
                pdfDocViewer.LoadFromFile(Utility.GetParameterByName("PDF_FILE_PATH", PARAMETERS));
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
                    DataTable result = oController.Submit(PARAMETERS, Utility.GetParameterByName("PDF_FILE_PATH", PARAMETERS), "pdf");
                    string message = Convert.ToString(result.Rows[0]["Message"]);
                    string error_message = Convert.ToString(result.Rows[0]["Error Message"]);

                    if (!string.IsNullOrEmpty(result.Rows[0]["Message"].ToString()))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.ORDER_DATE = txtOrderDate.Text.Trim();
                        MetroMessageBox.Show(this, "\n" + message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (!string.IsNullOrEmpty(result.Rows[0]["Error Message"].ToString()))
                    {
                        //this.DialogResult = DialogResult.Cancel;
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
            string REQ_SEQ = txtREQ_SEQ.Text.Trim();
            string START_USE_DATE = txtStartUseDate.Text.Trim();

            //validate

            if (!CheckUtility.SearchConditionCheck(this, ORDER_DATE, true, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, SYSTEM_EFFECTIVE_DATE, true, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, SYSTEM_REGISTER_DEADLINE, true, Utility.DataType.TIMESTAMP, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, TRANSACTION_TYPE, true, Utility.DataType.HALF_NUMBER, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, REQ_SEQ, true, Utility.DataType.HALF_NUMBER, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, START_USE_DATE, true, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            //update parameters
            PARAMETERS.Rows[0]["ORDER_DATE"] = ORDER_DATE;
            PARAMETERS.Rows[0]["SYSTEM_EFFECTIVE_DATE"] = SYSTEM_EFFECTIVE_DATE;
            PARAMETERS.Rows[0]["SYSTEM_REGISTER_DEADLINE"] = SYSTEM_REGISTER_DEADLINE;
            PARAMETERS.Rows[0]["TRANSACTION_TYPE"] = TRANSACTION_TYPE;
            PARAMETERS.Rows[0]["REQ_SEQ"] = REQ_SEQ;
            PARAMETERS.Rows[0]["START_USE_DATE"] = START_USE_DATE;

            return true;
        }
        #endregion
    }
}
