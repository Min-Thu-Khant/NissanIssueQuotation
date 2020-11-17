using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Forms.Jimugo.ApplicationApproval;
using MetroFramework;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmApplicationApproval : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private DataSet result;
        private string[] dummyColumns = {
            "No",
            "DISTINGUISH",
            "REQ_TYPE",
            "REQ_STATUS",
            "TRANSACTION_TYPE",
            "COMPANY_NAME",
            "COMPANY_NAME_READING",
            "REQ_DATE",
            "INPUT_DATE",
            "INPUT_PERSON",
            "INPUT_PERSON_EMAIL_ADDRESS",
            "CANCELLATION_DATE",
            "CANCELLATION_EDI_ACCOUNT",
            "CANCELLATION_REASON",
            "START_USE_DATE",
            "NML_CODE_NISSAN",
            "NML_CODE_NS",
            "NML_CODE_JATCO",
            "NML_CODE_AK",
            "NML_CODE_NK",
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
            "BILL_METHOD1",
            "BILL_METHOD2",
            "BILL_METHOD3",
            "BILL_METHOD5",
            "BILL_COMPANY_NAME",
            "BILL_DEPARTMENT_IN_CHARGE",
            "BILL_CONTACT_NAME",
            "BILL_CONTACT_NAME_READING",
            "BILL_POSTAL_CODE",
            "BILL_ADDRESS",
            "BILL_ADDRESS_BUILDING",
            "BILL_MAIL_ADDRESS",
            "BILL_PHONE_NUMBER",
            "BILL_BANK_ACCOUNT_NAME_1",
            "BILL_BANK_ACCOUNT_NUMBER_1",
            "BILL_BANK_ACCOUNT_NAME_2",
            "BILL_BANK_ACCOUNT_NUMBER_2",
            "BILL_BANK_ACCOUNT_NAME_3",
            "BILL_BANK_ACCOUNT_NUMBER_3",
            "BILL_BANK_ACCOUNT_NAME_4",
            "BILL_BANK_ACCOUNT_NUMBER_4",
            "INITIAL_COST",
            "MONTHLY_COST",
            "YEAR_COST",
            "BREAKDOWN",
            "CONTRACT_PLAN",
            "PLAN_AMIGO_CAI",
            "PLAN_AMIGO_BIZ",
            "BOX_SIZE",
            "OP_AMIGO_CAI",
            "OP_AMIGO_BIZ",
            "OP_BOX_SERVER",
            "OP_BOX_BROWSER",
            "OP_FLAT",
            "OP_CLIENT",
            "OP_BASIC_SERVICE",
            "OP_ADD_SERVICE",
            "SERVICE_DESK",
            "CAI_SERVER_IP_ADDRESS",
            "CAI_NETWORK",
            "CONTRACT_CSP",
            "CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS",
            "ERROR_NOTIFICATION",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "INPUT_PERSON_EMAIL_ADDRESS_",
            "MAIL_SENDING_TARGET_FLG",
            "MAIL_DESTINATION",
            "UPDATED_AT_RAW",
            "REQ_SEQ"
        };
        private string[] alignBottoms = {
               "NML_CODE_NISSAN",
               "NML_CODE_NS",
               "NML_CODE_JATCO",
               "NML_CODE_AK",
               "NML_CODE_NK",
               "CANCELLATION_DATE",
               "CANCELLATION_EDI_ACCOUNT",
               "CANCELLATION_REASON",
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
                "BILL_METHOD1",
                "BILL_METHOD2",
                "BILL_METHOD3",
                "BILL_METHOD5",
                "BILL_COMPANY_NAME",
                "BILL_DEPARTMENT_IN_CHARGE",
                "BILL_CONTACT_NAME",
                "BILL_CONTACT_NAME_READING",
                "BILL_POSTAL_CODE",
                "BILL_ADDRESS",
                "BILL_ADDRESS_BUILDING",
                "BILL_MAIL_ADDRESS",
                "BILL_PHONE_NUMBER",
                "BILL_BANK_ACCOUNT_NAME_1",
                "BILL_BANK_ACCOUNT_NUMBER_1",
                "BILL_BANK_ACCOUNT_NAME_2",
                "BILL_BANK_ACCOUNT_NUMBER_2",
                "BILL_BANK_ACCOUNT_NAME_3",
                "BILL_BANK_ACCOUNT_NUMBER_3",
                "BILL_BANK_ACCOUNT_NAME_4",
                "BILL_BANK_ACCOUNT_NUMBER_4",
                "INITIAL_COST",
                "MONTHLY_COST",
                "YEAR_COST",
                "BREAKDOWN",
                "PLAN_AMIGO_CAI",
                "PLAN_AMIGO_BIZ",
                "OP_AMIGO_CAI",
                "OP_AMIGO_BIZ",
                "OP_BOX_SERVER",
                "OP_BOX_BROWSER",
                "OP_FLAT",
                "OP_CLIENT",
                "OP_BASIC_SERVICE",
                "OP_ADD_SERVICE"
        };

        private Dictionary<string, string> OperationItems = new Dictionary<string,string> {
            { "COMPANY_NAME", "会社名" },
            { "NML_CODE_NISSAN", "サプライヤコード(日産)" },
            { "NML_CODE_NS", "サプライヤコード(NS)" },
            { "NML_CODE_JATCO", "サプライヤコード(JATCO)" },
            { "NML_CODE_AK", "サプライヤコード(愛知機械)" },
            { "NML_CODE_NK", "サプライヤコード(日産工機)" },
            { "CONTRACT_PLAN", "Amigo契約プラン" },
            { "OP_FLAT", "FLAT変換" },
            { "CAI_SERVER_IP_ADDRESS", "サーバーIPアドレス" },
            { "PLAN_AMIGO_CAI", "CAI利用者数" },
            { "PLAN_AMIGO_BIZ", "Biz利用者数" },
            { "BOX_SIZE", "BOXサイズ" }
        };
        #endregion

        #region Property
        public string ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string COMPANY_NO_BOX  { get; set; }
        public string REQ_TYPE_RAW { get; set; }
        public string _REQ_SEQ { get; set; }
        private string _req_status;
        public string _REQ_STATUS
        {
            get { return _req_status; }
            set {
                switch (value)
                {
                    case "仮登録(保存)":
                        _req_status = "0";
                        break;
                    case "申請中":
                        _req_status = "1";
                        break;
                    case "承認済":
                        _req_status = "2";
                        break;
                    case "否認":
                        _req_status = "3";
                        break;
                    case "申請取消":
                        _req_status = "9";
                        break;
                    default:
                        _req_status = "-1";
                        break;
                }
            }
        }

        private string _req_type;

        public string _REQ_TYPE
        {
            get { return _req_type; }
            set {
                switch (value)
                {
                    case "新規":
                        _req_type = "1";
                        break;
                    case "変更":
                        _req_type = "2";
                        break;
                    case "解約":
                        _req_type = "9";
                        break;
                    default:
                        _req_type = "-1";
                        break;
                }
            }
        }

        #endregion

        #region Constructor
        public frmApplicationApproval()
        {
            InitializeComponent();
        }

        public frmApplicationApproval(string PROGRAM_ID, string PROGRAM_NAME, string COMPANY_NO_BOX, string REQ_SEQ, string REQ_TYPE):this()
        {
            this.ProgramID = PROGRAM_ID;
            this.ProgramName = PROGRAM_NAME;
            //this.COMPANY_NO_BOX = COMPANY_NO_BOX;
            //this._REQ_SEQ = REQ_SEQ;
            //this.APPLICATION_SELECTION = APPLICATION_SELECTION;
            this.COMPANY_NO_BOX = "AJ-0001-02";
            this._REQ_SEQ = "1";
            this._REQ_STATUS = "仮登録(保存)";
            this._REQ_TYPE = "解約";
            this.REQ_TYPE_RAW = "解約";

        }
        #endregion

        #region AlignBottomHeaders
        private void AlignBottomHeaders()
        {
            foreach (string item in alignBottoms)
            {
                dgvList.Columns[item].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
        }
        #endregion

        #region ChangeBackGround
        private void ChangeBackGroundColor()
        {
            if (dgvList.Rows.Count > 1)
            {
                for (int i = 0; i < dgvList.Columns.Count; i++)
                {
                    string first = Convert.ToString(dgvList.Rows[0].Cells[i].Value);
                    string second = Convert.ToString(dgvList.Rows[1].Cells[i].Value);
                    if ((first ==null ? "" : first.Trim()) != (second == null ? "" : second.Trim()))
                    {
                        dgvList.Rows[1].Cells[i].Style.BackColor = Color.Pink;
                        foreach (var item in OperationItems)
                        {
                            if (dgvList.Columns[i].Name == item.Key)
                            {
                                string text = txtItemChanged.Text.Trim();
                                if (string.IsNullOrEmpty(text))
                                {
                                    txtItemChanged.Text = item.Value;
                                }
                                else
                                {
                                    txtItemChanged.Text = text + ", " + item.Value; 
                                }
                            }
                        }
                    }

                    if (dgvList.Columns[i].Name == "SERVICE_DESK")
                    {
                        if (result.Tables["SERVICE_DESK_CURRENT"].Rows.Count != result.Tables["SERVICE_DESK_CHANGE"].Rows.Count)
                        {
                            dgvList.Rows[1].Cells[i].Style.BackColor = Color.Pink;
                        }
                    }

                    if (dgvList.Columns[i].Name == "BREAKDOWN")
                    {
                        if (result.Tables["BREAKDOWN_CURRENT"].Rows.Count != result.Tables["BREAKDOWN_CURRENT"].Rows.Count)
                        {
                            dgvList.Rows[1].Cells[i].Style.BackColor = Color.Pink;
                        }
                    }

                    if (dgvList.Columns[i].Name == "ERROR_NOTIFICATION")
                    {
                        if (result.Tables["ERROR_NOTI_CURRENT"].Rows.Count != result.Tables["ERROR_NOTI_CURRENT"].Rows.Count)
                        {
                            dgvList.Rows[1].Cells[i].Style.BackColor = Color.Pink;
                            txtItemChanged.Text = txtItemChanged.Text + ", " + "エラー通知";
                        }
                    }

                }
            }
        }
        #endregion

        #region FormLoad
        private void FrmApplicationApproval_Load(object sender, EventArgs e)
        {
            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.Font = Properties.Settings.Default.jimugoFont;

            //start parameters
            txtCompanyNoBox.Text = this.COMPANY_NO_BOX;

            //set title
            lblMenu.Text = ProgramName;

            

            //UI
            uIUtility = new UIUtility(dgvList, null,null,null, dummyColumns);
            uIUtility.DummyTable();// add dummy table to merge columns
            uIUtility.DisableAutoSort();//disable autosort
            AlignBottomHeaders();//adjust column headers
            

            //get data
            GetInitialData();
            dgvList.ColumnHeadersHeight = 60;
            ChangeBackGroundColor();//check for changes and change color
        }
        #endregion

        #region GetInitialData
        private void GetInitialData()
        {
            try
            {
                frmApplicationApprovalController approval = new frmApplicationApprovalController();
                result = approval.GetInitialData(COMPANY_NO_BOX, _REQ_SEQ, _REQ_STATUS, _REQ_TYPE);


                if (result.Tables["LISTING"].Rows.Count > 0)
                {
                    uIUtility.dtList = result.Tables["LISTING"];
                    dgvList.DataSource = uIUtility.dtList;
                    uIUtility.dtOrigin = uIUtility.dtList.Copy();
                    if (dgvList.Rows.Count > 1)
                    {
                        dgvList.Rows[0].Cells["DISTINGUISH"].Value = "現行";
                        dgvList.Rows[1].Cells["DISTINGUISH"].Value = "変更";
                    }
                    else
                    {
                        dgvList.Rows[0].Cells["DISTINGUISH"].Value = REQ_TYPE_RAW;
                    }
                }
                else
                {
                    //clear data except headers
                    uIUtility.ClearDataGrid();
                }

                uIUtility.FormatUpdatedat();


            }
            catch (System.TimeoutException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.ServerTimeOut, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Net.WebException)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoConnection, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DrawColumnHeaders

        private void ApplicationForTermination_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
         
            //dgvList.Columns["colCONTRACTOR_COMPANY_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);

        }

        private void SupplierCodeHeader_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void PointOfContract_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void InvoiceCompany_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }
        private void InvoiceMethods_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void InvoiceAddress_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void BANK1_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void BANK2_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void BANK3_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void BANK4_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void BANK_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void UsageFee_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void OptionPlan_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void ServiceDesk_Header(PaintEventArgs e, int index, int count, string text, int rowcount, int row)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList, rowcount, row);
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            ApplicationForTermination_Header(e, 11, 3, "解約申請", 2, 0);
            SupplierCodeHeader_Header(e, 15, 5, "サプライヤコード", 2, 0);
            PointOfContract_Header(e, 20, 8, "契約窓口", 2, 0);
            InvoiceCompany_Header(e, 29, 2, "請求先会社", 2, 0);
            InvoiceMethods_Header(e, 31, 4, "請求方法", 2, 0);
            InvoiceAddress_Header(e, 35, 9, "請求書送付先", 2, 0);
            BANK1_Header(e, 44, 2, "1口目", 3, 1);
            BANK2_Header(e, 46, 2, "2口目", 3, 1);
            BANK3_Header(e, 48, 2, "3口目", 3, 1);
            BANK4_Header(e, 50, 2, "4口目", 3, 1);
            BANK_Header(e, 44, 8, "請求先銀行", 3, 0);
            UsageFee_Header(e, 52, 4, "利用料金", 2, 0);
            OptionPlan_Header(e, 60, 6, "オプションプラン", 2, 0);
            ServiceDesk_Header(e, 66, 2, "サービスデスク", 2, 0);
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

        #region CellContentClick
        private void DgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    switch (dgvList.Columns[e.ColumnIndex].Name)
                    {
                        case "BREAKDOWN":
                            frmUsageChargeBreakDown frmBreak = new frmUsageChargeBreakDown(result.Tables["BREAKDOWN_CURRENT"], result.Tables["BREAKDOWN_CHANGE"]);
                            frmBreak.ShowDialog();
                            break;
                        case "SERVICE_DESK":
                            frmServiceDesk frmService = new frmServiceDesk(result.Tables["SERVICE_DESK_CURRENT"], result.Tables["SERVICE_DESK_CHANGE"]);
                            frmService.ShowDialog();
                            break;
                        case "ERROR_NOTIFICATION":
                            frmErrrorNotification frmErrorNoti = new frmErrrorNotification(result.Tables["ERROR_NOTI_CURRENT"], result.Tables["ERROR_NOTI_CHANGE"]);
                            frmErrorNoti.ShowDialog();
                            break;
                        default:
                            break;
                    }


                }
            }
            catch (System.Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ApproveCancel
        private void BtnApproveCancel_Click(object sender, EventArgs e)
        {
            if (_REQ_STATUS == "2")
            {
                MetroMessageBox.Show(this, "\n" + JimugoMessages.E000ZZ036, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string List = Utility.DtToJSon(uIUtility.dtList, "LISTING");
                frmApplicationApprovalController approval = new frmApplicationApprovalController();
                DataSet ds = approval.ApproveCancel(txtCompanyNoBox.Text.Trim(), List);
                if (ds.Tables.Contains("LISTING"))
                {
                    dgvList.DataSource = ds.Tables["LISTING"];
                }
            }
        }
        #endregion

        private void BtnDisApprove_Click(object sender, EventArgs e)
        {
            bool SEND_FROM_SERVER = false;
            if (Utility.CheckIfProcessIsRunning("OUTLOOK"))
            {
                SEND_FROM_SERVER = true;
            }
            string List = Utility.DtToJSon(uIUtility.dtList, "LISTING");
            frmApplicationApprovalController approval = new frmApplicationApprovalController();
            DataSet ds = approval.Disapprove(txtCompanyNoBox.Text.Trim(), _REQ_TYPE, txtItemChanged.Text.Trim(), txtSystemEffectiveDate.Text.Trim(), txtRegDeadline.Text.Trim(), SEND_FROM_SERVER, List);
            if (ds.Tables.Contains("LISTING"))
            {
                dgvList.DataSource = ds.Tables["LISTING"];
            }

            if (!SEND_FROM_SERVER)
            {
                OpenOutlook(ds.Tables["MAIL"]);
            }
        }

        private void OpenOutlook(DataTable dt)
        {
            #region Open Outlook mail Client
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

            MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);

            mailItem.Subject = Utility.GetParameterByName("SubjectString", dt);
            mailItem.To = Utility.GetParameterByName("SendMail", dt);
            mailItem.Body = Utility.GetParameterByName("TemplateString", dt);
            mailItem.CC = Utility.GetParameterByName("EmailAddressCC", dt);

            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;

            mailItem.Display(true);
            #endregion
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            bool SEND_FROM_SERVER = false;
            if (Utility.CheckIfProcessIsRunning("OUTLOOK"))
            {
                SEND_FROM_SERVER = true;
            }

            //TEST
            uIUtility.dtList.Rows[0]["MAIL_SENDING_TARGET_FLG"] = 1;
            uIUtility.dtList.Rows[0]["MAIL_DESTINATION"] = "*";
            //TEST

            string List = Utility.DtToJSon(uIUtility.dtList, "LISTING");
            frmApplicationApprovalController approval = new frmApplicationApprovalController();
            DataSet ds = approval.Approve(txtCompanyNoBox.Text.Trim(), _REQ_TYPE, txtItemChanged.Text.Trim(), txtSystemEffectiveDate.Text.Trim(), txtRegDeadline.Text.Trim(), List);
            if (ds.Tables.Contains("LISTING"))
            {
                dgvList.DataSource = ds.Tables["LISTING"];
            }

            if (!SEND_FROM_SERVER && uIUtility.dtList.Rows[0]["MAIL_DESTINATION"].ToString() !="1")
            {
                OpenOutlook(ds.Tables["MAIL"]);
            }
        }
    }
}
