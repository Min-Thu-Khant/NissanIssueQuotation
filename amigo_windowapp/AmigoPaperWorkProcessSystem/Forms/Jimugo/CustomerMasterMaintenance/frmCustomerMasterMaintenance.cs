using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework;
using System.Data;
using AmigoPaperWorkProcessSystem.Controllers;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmCustomerMasterMaintenance : Form
    {

        #region Declare
        private UIUtility uIUtility;
        private string programID = "";
        private string programName = "顧客マスタメンテナンス";

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colEFFECTIVE_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10, Min=8},
            new Validate{ Name = "colCONTRACT_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10, Min=8},
            new Validate{ Name = "colSPECIAL_NOTES_1", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colSPECIAL_NOTES_2", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colSPECIAL_NOTES_3", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colSPECIAL_NOTES_4", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50},
            new Validate{ Name = "colNCS_CUSTOMER_CODE", Type = Utility.DataType.FULL_WIDTH, Edit=true, Require=false, Max=4 },
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_1", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_1", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_2", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_2", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_3", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_3", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NAME_4", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colBILL_BANK_ACCOUNT_NUMBER_4", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 48},
            new Validate{ Name = "colBILL_BILLING_INTERVAL", Type = Utility.DataType.TEXT, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colBILL_DEPOSIT_RULES", Type = Utility.DataType.TEXT, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colBILL_TRANSFER_FEE", Type = Utility.DataType.MINIMUM_TRANSFER_FEE, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colBILL_EXPENSES", Type = Utility.DataType.MINIMUM_EXPENSE, Edit = true, Require = false, Max = 255},
            new Validate{ Name = "colCOMPANY_NAME_CHANGED_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10},
            new Validate{ Name = "colPREVIOUS_COMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 80},
            new Validate{ Name = "colOBOEGAKI_DATE", Type = Utility.DataType.DATE, Edit = true, Require = false, Max = 10}
        };

        #region cmt
        //private string[] dummyColumns = {
        //    "colNo",
        //    "colCK",
        //    "colMK",
        //    "colCOMPANY_NO_BOX",
        //    "colTRANSACTION_TYPE",
        //    "colEFFECTIVE_DATE",
        //    "colUPDATE_CONTENT",
        //    "colCOMPANY_NAME",
        //    "colCOMPANY_NAME_READING",
        //    "colQUOTATION_DATE",
        //    "colCONTRACT_DATE",
        //    "colCOMPLETION_NOTIFICATION_DATE",
        //    "colCONTRACTOR_COMPANY_NAME",
        //    "colCONTRACTOR_DEPARTMENT_IN_CHARGE",
        //    "colCONTRACTOR_CONTACT_NAME",
        //    "colCONTRACTOR_CONTACT_NAME_READING",
        //    "colCONTRACTOR_POSTAL_CODE",
        //    "colCONTRACTOR_ADDRESS",
        //    "colCONTRACTOR_ADDRESS_BUILDING",
        //    "colCONTRACTOR_MAIL_ADDRESS",
        //    "colCONTRACTOR_PHONE_NUMBER",
        //    "colBILL_SUPPLIER_NAME",
        //    "colBILL_SUPPLIER_NAME_READING",
        //    "colBILL_COMPANY_NAME",
        //    "colBILL_DEPARTMENT_IN_CHARGE",
        //    "colBILL_CONTACT_NAME",
        //    "colBILL_CONTACT_NAME_READING",
        //    "colBILL_POSTAL_CODE",
        //    "colBILL_ADDRESS",
        //    "colBILL_ADDRESS_BUILDING",
        //    "colBILL_MAIL_ADDRESS",
        //    "colBILL_PHONE_NUMBER",
        //    "colSPECIAL_NOTES_1",
        //    "colSPECIAL_NOTES_2",
        //    "colSPECIAL_NOTES_3",
        //    "colSPECIAL_NOTES_4",
        //    "colBILL_TYPE",
        //    "colBILL_METHOD1",
        //    "colBILL_METHOD2",
        //    "colBILL_METHOD3",
        //    "colBILL_METHOD5",
        //    "colNCS_CUSTOMER_CODE",
        //    "colBILL_BANK_ACCOUNT_NAME_1",
        //    "colBILL_BANK_ACCOUNT_NUMBER_1",
        //    "colBILL_BANK_ACCOUNT_NAME_2",
        //    "colBILL_BANK_ACCOUNT_NUMBER_2",
        //    "colBILL_BANK_ACCOUNT_NAME_3",
        //    "colBILL_BANK_ACCOUNT_NUMBER_3",
        //    "colBILL_BANK_ACCOUNT_NAME_4",
        //    "colBILL_BANK_ACCOUNT_NUMBER_4",
        //    "colBILL_BILLING_INTERVAL",
        //    "colBILL_DEPOSIT_RULES",
        //    "colBILL_TRANSFER_FEE",
        //    "colBILL_EXPENSES",
        //    "colPLAN_AMIGO_CAI",
        //    "colPLAN_AMIGO_BIZ",
        //    "colBOX_SIZE",
        //    "colINITIAL_COST",
        //    "colMONTHLY_COST",
        //    "colYEAR_COST",
        //    "colColumn1",
        //    "colCONTRACT_PLAN",
        //    "colOP_AMIGO_CAI",
        //    "colOP_AMIGO_BIZ",
        //    "colOP_BOX_SERVER",
        //    "colOP_BOX_BROWSER",
        //    "colOP_FLAT",
        //    "colOP_CLIENT",
        //    "colOP_BASIC_SERVICE",
        //    "colOP_ADD_SERVICE",
        //    "colSOCIOS_USER_FLG",
        //    "colCOMPANY_NAME_CHANGED_DATE",
        //    "colPREVIOUS_COMPANY_NAME",
        //    "colNML_CODE_NISSAN",
        //    "colNML_CODE_NS",
        //    "colNML_CODE_JATCO",
        //    "colNML_CODE_AK",
        //    "colNML_CODE_NK",
        //    "colOBOEGAKI_DATE",
        //    "colEDI_ACCOUNT",
        //    "colMAIL_ADDRESS",
        //    "colREQ_MAIL_ADDRESS",
        //    "colUPDATED_AT",
        //    "colUPDATED_BY",
        //    "colUPDATED_AT_RAW",
        //    "colROW_ID",
        //    "colUPDATE_MESSAGE",
        //    "colREQ_SEQ",
        //    "colORG_EFFECTIVE_DATE",
        //    "colDISABLED_FLG",
        // };
        #endregion

        private string[] dummyColumns = {
            "No",
            "CK",
            "MK",
            "COMPANY_NO_BOX",
            "TRANSACTION_TYPE",
            "EFFECTIVE_DATE",
            "UPDATE_CONTENT",
            "COMPANY_NAME",
            "COMPANY_NAME_READING",
            "QUOTATION_DATE",
            "CONTRACT_DATE",
            "COMPLETION_NOTIFICATION_DATE",
            "CONTRACTOR_COMPANY_NAME",
            "CONTRACTOR_DEPARTMENT_IN_CHARGE",
            "CONTRACTOR_CONTACT_NAME",
            "CONTRACTOR_CONTACT_NAME_READING",
            "CONTRACTOR_POSTAL_CODE",
            "CONTRACTOR_ADDRESS",
            "CONTRACTOR_ADDRESS_BUILDING",
            "CONTRACTOR_MAIL_ADDRESS",
            "CONTRACTOR_PHONE_NUMBER",
            "BILL_SUPPLIER_NAME",
            "BILL_SUPPLIER_NAME_READING",
            "BILL_COMPANY_NAME",
            "BILL_DEPARTMENT_IN_CHARGE",
            "BILL_CONTACT_NAME",
            "BILL_CONTACT_NAME_READING",
            "BILL_POSTAL_CODE",
            "BILL_ADDRESS",
            "BILL_ADDRESS_BUILDING",
            "BILL_MAIL_ADDRESS",
            "BILL_PHONE_NUMBER",
            "SPECIAL_NOTES_1",
            "SPECIAL_NOTES_2",
            "SPECIAL_NOTES_3",
            "SPECIAL_NOTES_4",
            "BILL_TYPE",
            "BILL_METHOD1",
            "BILL_METHOD2",
            "BILL_METHOD3",
            "BILL_METHOD4",
            "NCS_CUSTOMER_CODE",
            "BILL_BANK_ACCOUNT_NAME-1",
            "BILL_BANK_ACCOUNT_NUMBER-1",
            "BILL_BANK_ACCOUNT_NAME-2",
            "BILL_BANK_ACCOUNT_NUMBER-2",
            "BILL_BANK_ACCOUNT_NAME-3",
            "BILL_BANK_ACCOUNT_NUMBER-3",
            "BILL_BANK_ACCOUNT_NAME-4",
            "BILL_BANK_ACCOUNT_NUMBER-4",
            "BILL_BILLING_INTERVAL",
            "BILL_DEPOSIT_RULES",
            "BILL_TRANSFER_FEE",
            "BILL_EXPENSES",
            "PLAN_AMIGO_CAI",
            "PLAN_AMIGO_BIZ",
            "BOX_SIZE",
            "INITIAL_COST",
            "MONTHLY_COST",
            "YEAR_COST",
            "BREAK_DOWN",
            "CONTRACT_PLAN",
            "OP_AMIGO_CAI",
            "OP_AMIGO_BIZ",
            "OP_BOX_SERVER",
            "OP_BOX_BROWSER",
            "OP_FLAT",
            "OP_CLIENT",
            "OP_BASIC_SERVICE",
            "OP_ADD_SERVICE",
            "SOCIOS_USER_FLG",
            "COMPANY_NAME_CHANGED_DATE",
            "PREVIOUS_COMPANY_NAME",
            "NML_CODE_NISSAN",
            "NML_CODE_NS",
            "NML_CODE_JATCO",
            "NML_CODE_AK",
            "NML_CODE_NK",
            "OBOEGAKI_DATE",
            "EDI_ACCOUNT",
            "CONSTRACTOR_SERVICE_DESK_MAIL",
            "SERVICE_ERROR_NOTIFICATION_MAIL",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "UPDATED_AT_RAW",
            "ROW_ID",
            "REQ_SEQ",
            "ORG_EFFECTIVE_DATE",
            "DISABLED_FLG",
         };

        #endregion

        #region Constructor
        public frmCustomerMasterMaintenance()
        {
            InitializeComponent();
        }

        public frmCustomerMasterMaintenance(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }
        #endregion

        #region FormLoad
        private void FrmCustomerMasterMaintenance_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;

            //utility
            uIUtility = new UIUtility(dgvList, null, null, Modifiable, dummyColumns);
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
            SetDefaultColumnWidths(); //adjust checkbox sizes
            uIUtility.DummyTable();// add dummy table to merge columns
            uIUtility.DisableAutoSort();//disable autosort
            PopulateDropdowns();

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

            chkContractor.Checked = false;
            chkInvoice.Checked = false;
            chkServiceDesk.Checked = false;
            chkNotificationDestination.Checked = false;

            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            //Bind_Classification()", //grid dropdown
            uIUtility.DisplayCountCombo(cboLimit); //search filter
        }
        #endregion

        #region CustomerMaster
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text != "")
            {
                if (!CheckUtility.SearchConditionCheck(this, txtCompanyName.Text, false, Utility.DataType.FULL_WIDTH, 80, 0))
                {
                    return;
                }
            }

            if (txtCompanyNameReading.Text != "")
            {
                if (!CheckUtility.SearchConditionCheck(this, txtCompanyNameReading.Text, false, Utility.DataType.FULL_WIDTH, 60, 0))
                {
                    return;
                }
            }

            if (txtCompanyNoBox.Text != "")
            {
                if (!CheckUtility.SearchConditionCheck(this, txtCompanyNoBox.Text, false, Utility.DataType.HALF_ALPHA_NUMERIC, 60, 0))
                {
                    return;
                }
            }

            if (txtEDIAccount.Text != "")
            {
                if (!CheckUtility.SearchConditionCheck(this, txtEDIAccount.Text, false, Utility.DataType.EDI_ACCOUNT, 4, 0))
                {
                    return;
                }
            }

            if (txtMailAddress.Text != "")
            {
                if (!CheckUtility.SearchConditionCheck(this, txtMailAddress.Text, false, Utility.DataType.EMAIL, 255, 0))
                {
                    return;
                }
            }


            uIUtility.MetaData.Offset = 0;
            try
            {
                uIUtility.MetaData.Limit = int.Parse(cboLimit.SelectedValue.ToString());

            }
            catch (Exception)
            {
                uIUtility.MetaData.Limit = 0;
            }
            try
            {
                if (uIUtility.checkSelectedRow())
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + JimugoMessages.I000ZZ012, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.OK)
                    {
                        BindGrid();
                    }
                }
                else
                {
                    BindGrid();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                
                    //assign search keywords
                string company_no_box = txtCompanyNoBox.Text;
                string company_name = txtCompanyName.Text;
                string company_name_reading = txtCompanyNameReading.Text;
                string edi_account = txtEDIAccount.Text;
                string mialAddress = txtMailAddress.Text;
                string contractor = "";
                string invoice = "";
                string serviceDesk = "";
                string notificationDestination = "";

                #region CheckBox
                if (chkContractor.Checked)
                {
                    contractor = chkContractor.Text;
                }
                else
                {
                    contractor = "";
                }

                if (chkInvoice.Checked)
                {
                    invoice = chkInvoice.Text;
                }
                else
                {
                    invoice = "";
                }

                if (chkServiceDesk.Checked)
                {
                    serviceDesk = chkServiceDesk.Text;
                }
                else
                {
                    serviceDesk = "";
                }

                if (chkNotificationDestination.Checked)
                {
                    notificationDestination = chkNotificationDestination.Text;
                }
                else
                {
                    notificationDestination = "";
                }
                #endregion
                

                //assign search keywords
                frmCustomerMasterMaintenanceController oController = new frmCustomerMasterMaintenanceController();
                DataTable dt = oController.GetCustomerMasterMaintenanceList(company_no_box, company_name, company_name_reading, edi_account, mialAddress, contractor, invoice,serviceDesk, notificationDestination, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData); //need to add more parameter
                if (dt.Rows.Count > 0)
                {

                    uIUtility.dtList = dt;
                    dgvList.DataSource = uIUtility.dtList;
                    uIUtility.dtOrigin = uIUtility.dtList.Copy();

                    //pagination
                    uIUtility.CalculatePagination(lblcurrentPage, lblTotalPages, lblTotalRecords);
                }
                else
                {
                    //clear data except headers
                    uIUtility.ClearDataGrid();
                    uIUtility.CalculatePagination(lblcurrentPage, lblTotalPages, lblTotalRecords);
                }

                uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
                uIUtility.FormatUpdatedat();

                //check for disable flag
                uIUtility.CheckForDisableField();
            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ModifyButton
        private void BtnModify_Click(object sender, EventArgs e)
        {
            uIUtility.CommonGridManage("M");
        }
        #endregion

        #region DrawColumnHeaders

        private void Add_Constructor_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
            
            dgvList.Columns["colCONTRACTOR_COMPANY_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_DEPARTMENT_IN_CHARGE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_CONTACT_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_CONTACT_NAME_READING"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_POSTAL_CODE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_ADDRESS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_ADDRESS_BUILDING"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_MAIL_ADDRESS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colCONTRACTOR_PHONE_NUMBER"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;


        }

        private void Add_BillingAddress_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);

            dgvList.Columns["colBILL_SUPPLIER_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_SUPPLIER_NAME_READING"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_COMPANY_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_DEPARTMENT_IN_CHARGE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_CONTACT_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_CONTACT_NAME_READING"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_POSTAL_CODE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_ADDRESS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_ADDRESS_BUILDING"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_MAIL_ADDRESS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_PHONE_NUMBER"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_Request_Method_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
            dgvList.Columns["colBILL_METHOD1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_METHOD2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_METHOD3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_METHOD5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }


        // add 3 column header
        private void Add_BillingBank_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void Add_1stMonth_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);

            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_2stMonth_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);

            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_3stMonth_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);

            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_4stMonth_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);

            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }


        private void Add_Amigo_Authority_Usage_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);

            dgvList.Columns["colPLAN_AMIGO_CAI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colPLAN_AMIGO_BIZ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_Usage_Fee_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
            dgvList.Columns["colINITIAL_COST"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colMONTHLY_COST"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colYEAR_COST"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colBREAK_DOWN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_Option_Plan_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);

            dgvList.Columns["colOP_AMIGO_CAI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colOP_AMIGO_BIZ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colOP_BOX_SERVER"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colOP_BOX_BROWSER"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colOP_FLAT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colOP_CLIENT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_Service_Desk_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
            dgvList.Columns["colOP_BASIC_SERVICE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colOP_ADD_SERVICE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_Company_Name_Change_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);

            dgvList.Columns["colCOMPANY_NAME_CHANGED_DATE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colPREVIOUS_COMPANY_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void Add_Supplier_Code_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
            dgvList.Columns["colNML_CODE_NISSAN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colNML_CODE_NS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colNML_CODE_JATCO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colNML_CODE_AK"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvList.Columns["colNML_CODE_NK"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {

            Add_Constructor_Header(e, 12, 9, "契約先");
            Add_BillingAddress_Header(e, 21, 11, "請求先");
            Add_Request_Method_Header(e,37,4, "請求方法");

            Add_BillingBank_Header(e, 42, 8, "請求先銀行", 3, 0);  //add third column 42 4
            Add_1stMonth_Header(e, 42, 2, "1口目", 3, 1);
            Add_2stMonth_Header(e, 44, 2, "2口目", 3, 1);
            Add_3stMonth_Header(e, 46, 2, "3口目", 3, 1);
            Add_4stMonth_Header(e, 48, 2, "4口目", 3, 1);

            Add_Amigo_Authority_Usage_Header(e, 54, 2, "Amigo権限利用数");
            Add_Usage_Fee_Header(e, 57, 4, "利用料金");
            Add_Option_Plan_Header(e, 62, 6, "オプションプラン");
            Add_Service_Desk_Header(e, 68, 2, "サービスデスク");
            Add_Company_Name_Change_Header(e, 71, 2, "社名変更");
            Add_Supplier_Code_Header(e, 73, 5, "サプライヤコード");

        }

        private void DgvList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //to trigger repaint 
            this.dgvList.Invalidate();
        }

        private void DgvList_Scroll(object sender, ScrollEventArgs e)
        {
            //to trigger repaint 
            //only update on HorizontalScroll Scroll
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.dgvList.Invalidate();
            }
        }
        #endregion

        #region CellValueChanged
        private void DgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                uIUtility.WatchMKValue(e);

                //check for disable flag
                uIUtility.CheckForDisableField();
            }
            catch (Exception)
            {
                //skip in form load
            }
        }
        #endregion

        #region SubmitButton
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //get column values where MK not null or empty
            DataTable dt = uIUtility.SubmitChanges();

            //send to web service
            frmCustomerMasterMaintenanceController oController = new frmCustomerMasterMaintenanceController();
            try
            {
                DataTable result = oController.Submit(dt, out uIUtility.MetaData);

                //update data grid view
                uIUtility.UpdateReturnedresults(result);
            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CellContentClick
        private void DgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    switch (dgvList.Columns[e.ColumnIndex].Name)
                    {
                        case "colBREAK_DOWN":
                            OpenCustomerMasterPopup(dgvList.Rows[e.RowIndex]);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region OpenCustomerMasterPopup
        private void OpenCustomerMasterPopup(DataGridViewRow row)
        {
            string value = Convert.ToString(row.Cells["colBREAK_DOWN"].Value);
            if (value != null)
            {
                    frmCustomerMasterPopup frm = new frmCustomerMasterPopup(
                    Convert.ToString(row.Cells["colCOMPANY_NO_BOX"].Value),
                    Convert.ToString(row.Cells["colREQ_SEQ"].Value)
                    );

                frm.Show();
                //if (frm.Close()==true)
                //{
                //    row.Cells["colORDER_DATE"].Value = frm.ORDER_DATE;
                //    row.Cells["colUPDATED_BY"].Value = Utility.Id;
                //    frm.Dispose();
                //}
            }
        }

        #endregion

        #region ClearLabel
        private void LblClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        #endregion

        #region ClearSearchCondition
        private void ClearSearch()
        {
            chkContractor.Checked = false;
            chkInvoice.Checked = false;
            chkServiceDesk.Checked = false;
            chkNotificationDestination.Checked = false;

            txtCompanyNoBox.Text = "";
            txtCompanyName.Text = "";
            txtCompanyNameReading.Text = "";
            txtEDIAccount.Text = "";
            txtMailAddress.Text = "";
            cboLimit.SelectedIndex = 0;
            uIUtility.ClearDataGrid();
            lblTotalRecords.Text = "";
            lblTotalPages.Text = "0";
            lblcurrentPage.Text = "0";

            cboLimit.SelectedIndex = 0;
            uIUtility.ClearDataGrid();
        }
        #endregion

        #region SetDefaultColumnWidths
        private void SetDefaultColumnWidths()
        {
            uIUtility.ResetCheckBoxSize();
            dgvList.Columns["colCOMPANY_NO_BOX"].Width = 110;
            dgvList.Columns["colTRANSACTION_TYPE"].Width = 90;
            dgvList.Columns["colEFFECTIVE_DATE"].Width = 100;
            dgvList.Columns["colUPDATE_CONTENT"].Width = 120;
            dgvList.Columns["colCOMPANY_NAME"].Width = 150;
            dgvList.Columns["colCOMPANY_NAME_READING"].Width = 250;
            dgvList.Columns["colQUOTATION_DATE"].Width = 100;
            dgvList.Columns["colCONTRACT_DATE"].Width = 100;
            dgvList.Columns["colCOMPLETION_NOTIFICATION_DATE"].Width = 100;
            dgvList.Columns["colCONTRACTOR_COMPANY_NAME"].Width = 160;
            dgvList.Columns["colCONTRACTOR_DEPARTMENT_IN_CHARGE"].Width = 160;
            dgvList.Columns["colCONTRACTOR_CONTACT_NAME"].Width = 80;
            dgvList.Columns["colCONTRACTOR_CONTACT_NAME_READING"].Width = 120;
            dgvList.Columns["colCONTRACTOR_POSTAL_CODE"].Width = 80;
            dgvList.Columns["colCONTRACTOR_ADDRESS"].Width = 250;
            dgvList.Columns["colCONTRACTOR_ADDRESS_BUILDING"].Width = 250;
            dgvList.Columns["colCONTRACTOR_MAIL_ADDRESS"].Width = 200;
            dgvList.Columns["colCONTRACTOR_PHONE_NUMBER"].Width = 110;

            dgvList.Columns["colBILL_SUPPLIER_NAME"].Width = 150;
            dgvList.Columns["colBILL_SUPPLIER_NAME_READING"].Width = 250;
            dgvList.Columns["colBILL_COMPANY_NAME"].Width = 150;
            dgvList.Columns["colBILL_DEPARTMENT_IN_CHARGE"].Width = 160;
            dgvList.Columns["colBILL_CONTACT_NAME"].Width = 80;
            dgvList.Columns["colBILL_CONTACT_NAME_READING"].Width = 120;
            dgvList.Columns["colBILL_POSTAL_CODE"].Width = 80;
            dgvList.Columns["colBILL_ADDRESS"].Width = 250;
            dgvList.Columns["colBILL_ADDRESS_BUILDING"].Width = 250;
            dgvList.Columns["colBILL_MAIL_ADDRESS"].Width = 200;
            dgvList.Columns["colBILL_PHONE_NUMBER"].Width = 110;

            dgvList.Columns["colSPECIAL_NOTES_1"].Width = 250;
            dgvList.Columns["colSPECIAL_NOTES_2"].Width = 250;
            dgvList.Columns["colSPECIAL_NOTES_3"].Width = 250;
            dgvList.Columns["colSPECIAL_NOTES_4"].Width = 250;

            dgvList.Columns["colBILL_METHOD1"].Width = 50;
            dgvList.Columns["colBILL_METHOD2"].Width = 50;
            dgvList.Columns["colBILL_METHOD3"].Width = 50;
            dgvList.Columns["colBILL_METHOD5"].Width = 50;


            dgvList.Columns["colNCS_CUSTOMER_CODE"].Width = 90;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_1"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_1"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_2"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_2"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_3"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_3"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NAME_4"].Width = 120;
            dgvList.Columns["colBILL_BANK_ACCOUNT_NUMBER_4"].Width = 120;

            dgvList.Columns["colBILL_BILLING_INTERVAL"].Width = 100;
            dgvList.Columns["colBILL_DEPOSIT_RULES"].Width = 110;
            dgvList.Columns["colBILL_TRANSFER_FEE"].Width = 115;
            dgvList.Columns["colBILL_EXPENSES"].Width = 90;

            dgvList.Columns["colPLAN_AMIGO_CAI"].Width = 90;
            dgvList.Columns["colPLAN_AMIGO_BIZ"].Width = 90;//

            dgvList.Columns["colBOX_SIZE"].Width = 90;

            dgvList.Columns["colINITIAL_COST"].Width = 90;
            dgvList.Columns["colMONTHLY_COST"].Width = 90;
            dgvList.Columns["colYEAR_COST"].Width = 90;
            dgvList.Columns["colBREAK_DOWN"].Width = 50;//

            dgvList.Columns["colCONTRACT_PLAN"].Width = 115;

            dgvList.Columns["colOP_AMIGO_CAI"].Width = 120;
            dgvList.Columns["colOP_AMIGO_BIZ"].Width = 120;
            dgvList.Columns["colOP_BOX_SERVER"].Width = 120;
            dgvList.Columns["colOP_BOX_BROWSER"].Width = 120;
            dgvList.Columns["colOP_FLAT"].Width = 120;
            dgvList.Columns["colOP_CLIENT"].Width = 120;//

            dgvList.Columns["colOP_BASIC_SERVICE"].Width = 120;
            dgvList.Columns["colOP_ADD_SERVICE"].Width = 120;

            dgvList.Columns["colSOCIOS_USER_FLG"].Width = 90;

            dgvList.Columns["colCOMPANY_NAME_CHANGED_DATE"].Width = 100;
            dgvList.Columns["colPREVIOUS_COMPANY_NAME"].Width = 150;//

            dgvList.Columns["colNML_CODE_NISSAN"].Width = 100;
            dgvList.Columns["colNML_CODE_NS"].Width = 100;
            dgvList.Columns["colNML_CODE_JATCO"].Width = 100;
            dgvList.Columns["colNML_CODE_AK"].Width = 100;
            dgvList.Columns["colNML_CODE_NK"].Width = 100;

            dgvList.Columns["colOBOEGAKI_DATE"].Width = 100;
            dgvList.Columns["colEDI_ACCOUNT"].Width = 80;
            dgvList.Columns["colMAIL_ADDRESS"].Width = 200;
            dgvList.Columns["colREQ_MAIL_ADDRESS"].Width = 200;
            dgvList.Columns["colUPDATED_AT"].Width = 145;
            dgvList.Columns["colUPDATED_BY"].Width = 120;
            dgvList.Columns["colUPDATE_MESSAGE"].Width = 350;

        }
        #endregion

        #region PreviousButton
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (!uIUtility.IsInModifyMode())
            {
                uIUtility.MetaData.Offset -= int.Parse(cboLimit.SelectedValue.ToString());
                BindGrid();
            }
        }
        #endregion

        #region NextButton
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!uIUtility.IsInModifyMode())
            {
                uIUtility.MetaData.Offset += int.Parse(cboLimit.SelectedValue.ToString());
                BindGrid();
            }
        }
        #endregion

        #region FirstButton
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            if (!uIUtility.IsInModifyMode())
            {
                uIUtility.MetaData.Offset = 0;
                BindGrid();
            }
        }
        #endregion

        #region LastButton
        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (!uIUtility.IsInModifyMode())
            {
                uIUtility.MetaData.Offset = (int.Parse(lblTotalPages.Text.Replace("Pages", "").Trim()) - 1) * int.Parse(cboLimit.SelectedValue.ToString());
                BindGrid();
            }
        }
        #endregion

        #region CheckAll
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(true);
        }

        #endregion

        #region UncheckAll
        private void BtnUnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(false);
        }
        #endregion

        #region CancelButton
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            uIUtility.CancelChanges();
        }
        #endregion
    }
}
