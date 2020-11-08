using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Forms.Jimugo.IssueQuotation;
using MetroFramework;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.Issue_Quotation
{
    public partial class frmIssueQuotation : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private string programID = "";
        private string programName = "";
        private string CompanyNoBox = "AJ-0001-01";
        private string REQ_SEQ = "1";
        private string Quotation_Date;
        private string Order_Date;
        private string Reg_Complete_Date;
        private string CompanyName;
        private string pdfLink = "";
        private string strCONTRACT_CODE = "";
        #endregion

        #region Constructor
        public frmIssueQuotation()
        {
            InitializeComponent();
        }

        public frmIssueQuotation(
            string programID, 
            string programName, 
            string CompanyNoBox, 
            string REQ_SEQ,
            string Quotation_Date,
            string Order_Date,
            string Reg_Complete_Date,
            string CompanyName) :this()
        {
            this.programID = programID;
            this.programName = programName;
            this.CompanyNoBox = "AJ-0001-05";
            this.REQ_SEQ = "1";
            this.Quotation_Date = Quotation_Date;
            this.Order_Date = Order_Date;
            this.Reg_Complete_Date = Reg_Complete_Date;
            this.CompanyName = CompanyName;

        }
        #endregion

        #region FormLoad
        private void FrmIssueQuotation_Load(object sender, EventArgs e)
        {
            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;
            this.Font = Properties.Settings.Default.jimugoFont;

            //set title
            lblMenu.Text = programName; 
            uIUtility = new UIUtility();

            //set textboxes
            txtCompanyNoBox.Text = CompanyNoBox;
            txtCompanyName.Text = CompanyName;
            txtNotificationDate.Text = Reg_Complete_Date;

            GetInitialData();
        }
        #endregion

        #region GetInitialData
        private void GetInitialData()
        {
            //try
            //{
                frmIssueQuotationController issueQuotation = new frmIssueQuotationController();
                DataTable result = issueQuotation.GetInitialData(CompanyNoBox, REQ_SEQ, out uIUtility.MetaData);
                if (result.Rows.Count > 0)
                {
                    SetValues(result.Rows[0]);
                }
            //}
            //catch (Exception)
            //{

            //}
        }
        #endregion

        #region SetValues
        private void SetValues(DataRow dr)
        {
            //set EDI account
            txtEDIAccount.Text = dr["EDI_ACCOUNT"].ToString();
            try
            {
                //set quotation start date
                txtQuotationStartDate.Text = DateTime.ParseExact(dr["START_USE_DATE"].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");

            }
            catch (Exception)
            {

            }
            //set email address
            txtDestinationMail.Text = dr["EMAIL_ADDRESS"].ToString();

            //check for contract code and manupulate controls
            CheckEditableRegions(dr["CONTRACT_PLAN"].ToString().Trim());
            strCONTRACT_CODE = dr["CONTRACT_PLAN"].ToString().Trim();
        }
        #endregion

        #region CheckEditableRegions
        private void CheckEditableRegions(string CONTRACT_CODE)
        {
            switch (CONTRACT_CODE)
            {
                case "PRODUCT":
                    ChangeEditableDependingOnContractCode(true);
                    break;
                default:
                    ChangeEditableDependingOnContractCode(false);
                    break;
            }
        }
        #endregion

        #region void ChangeEditableDependingOnContractCode
        private void ChangeEditableDependingOnContractCode(bool isproduct)
        {
            chkInitialQuot.Checked = false;
            chkMonthlyQuote.Checked = false;
            chkProductionInfo.Checked = false;

            chkInitialQuot.Enabled = isproduct;
            chkMonthlyQuote.Enabled = isproduct;
            chkProductionInfo.Enabled = !isproduct;
            txtInitialSpecialDiscount.Enabled = isproduct;
            txtPeriodFrom.Enabled = !isproduct;
            txtPeriodTo.Enabled = !isproduct;
        }
        #endregion

        private async void BtnPreview_Click(object sender, EventArgs e)
        {
            
            //string COMPANY_NAME, string COMPANY_NO_BOX, string REQ_SEQ, string EDI_ACCOUNT,string strExporType,string strFileHeader;
            frmIssueQuotationController oController = new frmIssueQuotationController();
            try
            {
                string strExportType = "";
                decimal decSpecialAmt = 0;
                if (chkInitialQuot.Checked)
                {
                    strExportType = "1";
                    decimal.TryParse(txtInitialSpecialDiscount.Text, out decSpecialAmt);
                    decSpecialAmt = decSpecialAmt * -1;
                }
                else if (chkMonthlyQuote.Checked)
                {
                    strExportType = "2";
                    decimal.TryParse(txtMonthlySpecialDiscount.Text, out decSpecialAmt);
                    decSpecialAmt = decSpecialAmt * -1;
                }
                else if (chkProductionInfo.Checked)
                {
                    decimal IntialDiscount = 0;
                    decimal.TryParse(txtInitialSpecialDiscount.Text, out IntialDiscount);
                    decimal MonthlyDiscount = 0;
                    decimal.TryParse(txtMonthlySpecialDiscount.Text, out MonthlyDiscount);
                    decSpecialAmt = IntialDiscount + MonthlyDiscount * -1;
                    strExportType = "3";
                }
                else if (chkOrderForm.Checked)
                {
                    if (strCONTRACT_CODE == "PRODUCT")
                    {
                        decimal.TryParse(txtInitialSpecialDiscount.Text, out decSpecialAmt);
                        decSpecialAmt = decSpecialAmt * -1;
                    }
                    else if (strCONTRACT_CODE != "PRODUCT")
                    {
                        decimal IntialDiscount = 0;
                        decimal.TryParse(txtInitialSpecialDiscount.Text, out IntialDiscount);
                        decimal MonthlyDiscount = 0;
                        decimal.TryParse(txtMonthlySpecialDiscount.Text, out MonthlyDiscount);
                        decSpecialAmt = IntialDiscount + MonthlyDiscount * -1;
                    }
                    strExportType = "4";
                }

                decimal decTaxAmount = (decimal)0;
                string strStartDate = "";
                string strExpireDate = "";
                string strFromCertificate = "";
                string strToCertificate = "";

                decimal.TryParse(txtTax.Text, out decTaxAmount);
                if (CheckUtility.SearchConditionCheck(this, txtQuotationStartDate.Text, false, Utility.DataType.DATE, 255, 0))
                {
                    strStartDate = DateConverter(txtQuotationStartDate.Text).ToString("yyyyMMdd");
                }
                else
                {
                    strStartDate = DateTime.Now.ToString("yyyyMMdd");
                }

                if (CheckUtility.SearchConditionCheck(this, txtQuotationEndDate.Text, false, Utility.DataType.DATE, 255, 0))
                {
                    strExpireDate = DateConverter(txtQuotationEndDate.Text).ToString("yyyyMMdd");
                }
                else
                {
                    strExpireDate = DateTime.Now.ToString("yyyyMMdd");
                }

                if (CheckUtility.SearchConditionCheck(this, txtPeriodFrom.Text, false, Utility.DataType.DATE, 255, 0))
                {
                    strFromCertificate = DateConverter(txtPeriodFrom.Text).ToString("yyyyMMdd");
                }
                else
                {
                    strFromCertificate = DateTime.Now.ToString("yyyyMMdd");
                }

                if (CheckUtility.SearchConditionCheck(this, txtPeriodTo.Text, false, Utility.DataType.DATE, 255, 0))
                {
                    strToCertificate = DateConverter(txtPeriodTo.Text).ToString("yyyyMMdd");
                }
                else
                {
                    strToCertificate = DateTime.Now.ToString("yyyyMMdd");
                }

                

                DataTable result = oController.PreviewFunction(txtCompanyNoBox.Text, txtCompanyName.Text, REQ_SEQ, txtEDIAccount.Text, decTaxAmount,strStartDate,strExpireDate,"", strFromCertificate,strToCertificate, strExportType, DateTime.Now.ToString("yyyyMMddHHmmss"), strCONTRACT_CODE, decSpecialAmt);

                string message = Convert.ToString(result.Rows[0]["Message"]);
                string error_message = Convert.ToString(result.Rows[0]["Error Message"]);

                if (!string.IsNullOrEmpty(message))
                {
                    pdfLink = Convert.ToString(result.Rows[0]["DownloadLink"]);
                    MetroMessageBox.Show(this, "\n" + message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(error_message))
                {
                    MetroMessageBox.Show(this, "\n" + error_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DataTable dt = DTParameter(txtCompanyNoBox.Text, REQ_SEQ, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), txtCompanyName.Text, txtDestinationMail.Text, txtEDIAccount.Text, pdfLink, strExportType);
                
                #region CallPreviewScreen
                string temp_deirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Temp";

                if (!Directory.Exists(temp_deirectory))
                {
                    Directory.CreateDirectory(temp_deirectory);
                }

                //delete temp files
                Utility.DeleteFiles(temp_deirectory);

                string destinationpath = temp_deirectory + @"\Quotation_temp.pdf";
                btnPreview.Enabled = false;
                bool success = await Core.WebUtility.Download(pdfLink, destinationpath);
                if (success)
                {
                    frmIssueQuotationPrevew frm = new frmIssueQuotationPrevew(dt);
                    frm.ShowDialog();
                    this.Show();                   
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

        #region AddToDataTable
        public DataTable DTParameter(string companyNoBox, string reqSeq, string quotationDate, string orderDate,string companyName, string emailAddress, string ediAccount, string downloadLink,string strExportType)
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
            dt.Columns.Add("EXPORT_TYPE");
            dt.Rows.Add(companyNoBox, reqSeq, quotationDate, orderDate, companyName, emailAddress, ediAccount, downloadLink, strExportType);

            return dt;
        }
        #endregion

        #region DateConverter
        protected DateTime DateConverter(string strDataValue)
        {
            DateTime dtm = new DateTime();
            try
            {
                dtm = DateTime.ParseExact(strDataValue, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                try
                {
                    dtm = DateTime.ParseExact(strDataValue, "yyyy/M/dd", CultureInfo.InvariantCulture);
                }
                catch (Exception ex2)
                { 
                
                }
            }
            return dtm;
        }
        #endregion

        private void chkType_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                switch (chk.Name)
                {
                    case "chkInitialQuot":
                        chkInitialQuot.Checked = true;
                        chkMonthlyQuote.Checked = false;
                        chkProductionInfo.Checked = false;
                        break;
                    case "chkMonthlyQuote":
                        chkInitialQuot.Checked = false;
                        chkMonthlyQuote.Checked = true;
                        chkProductionInfo.Checked = false;
                        break;
                    case "chkProductionInfo":
                        chkInitialQuot.Checked = false;
                        chkMonthlyQuote.Checked = false;
                        chkProductionInfo.Checked = true;
                        break;
                }
            }
        }
    }
}
