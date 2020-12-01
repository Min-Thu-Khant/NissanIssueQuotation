using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using AmigoPaperWorkProcessSystem.Forms.Jimugo;
using AmigoPaperWorkProcessSystem.Forms.Jimugo.Issue_Quotation;
using AmigoPaperWorkProcessSystem.Forms.RegisterCompleteNotification;
using AmigoPaperWorkProcessSystem.Jimugo;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frmUsageApplicationList : Form
    {
        #region Declare

        private UIUtility uIUtility;
        private DataTable SUBPROGRAMS;
        private string programID = "";
        private string programName = "";

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colCLOSE_FLG", Type = Utility.DataType.TEXT, Edit = true, Require = false, Max = 255, },
            new Validate{ Name = "colGD", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 255 },
        };

        private string[] dummyColumns = {
            "No",
            "CK",
            "MK",
            "COMPANY_NO_BOX",
            "REQ_SEQ",
            "COMPANY_NAME",
            "CLOSE_FLG",
            "GD",
            "REQ_TYPE",
            "REQ_STATUS",
            "REQ_DATE",
            "QUOTATION_DATE",
            "ORDER_DATE",
            "SYSTEM_EFFECTIVE_DATE",
            "SYSTEM_SETTING_STATUS",
            "COMPLETION_NOTIFICATION_DATE",
            "NML_CODE_NISSAN",
            "NML_CODE_NS",
            "NML_CODE_JATCO",
            "NML_CODE_AK",
            "NML_CODE_NK",
            "DISABLED_FLG",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "UPDATED_AT_RAW",
            "ROW_ID",
            "REQUEST_ID_UPDATED_AT"
        };

        private string[] alignBottoms = {
               "colREQ_TYPE",
               "colREQ_STATUS",
               "colREQ_DATE",
               "colSYSTEM_EFFECTIVE_DATE",
               "colSYSTEM_SETTING_STATUS"
        };
        #endregion

        #region Constructor
        public frmUsageApplicationList()
        {
            InitializeComponent();
        }
        public frmUsageApplicationList(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
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

        #region FormLoad
        private void FrmUsageApplicationList_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;
            this.Text = "[" + programID + "] " + programName;

            uIUtility = new UIUtility(dgvList, null, null, Modifiable, dummyColumns);

            uIUtility.ResetCheckBoxSize();//adjust checkbox sizes
            uIUtility.DummyTable();// add dummy table to merge columns
            uIUtility.DisableAutoSort();//disable autosort
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
            PopulateDropdowns();

            uIUtility.ResetCheckBoxSize();//adjust checkbox sizes
            AlignBottomHeaders();//adjust column headers

            //get sub program names to appear in titles
            getSubProgramNames();

            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.Font = Properties.Settings.Default.jimugoFont;

            dgvList.Columns["REQUEST_ID_UPDATED_AT"].Visible = false;


        }
        #endregion

        #region GetProgramNames
        //fetch sub program names from this from
        private void getSubProgramNames()
        {
            try
            {
                frmUsageApplicationListController oController = new frmUsageApplicationListController();
                SUBPROGRAMS = oController.getSubProgramList();
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }
        }
        #endregion

        #region GetProgramNameByID
        private string GetProgramNameByID(string ID)
        {
            try
            {
                return SUBPROGRAMS.Select("PROGRAM_ID ='" + ID + "'")[0]["PROGRAM_NAME"].ToString();
            }
            catch (Exception)
            {

                return "";
            }
        }
        #endregion

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit);

            //GD
            uIUtility.GDCombo(cboGD);

            //application status
            uIUtility.AppStatusCombo(cboApplicationStatus);

            //setting status
            uIUtility.SystemSettingStatusCombo(cboSystemSettingStatus);
        }
        #endregion

        #region SearchButton
        private void BtnSearch_Click(object sender, EventArgs e)
        {
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
                if (!uIUtility.IsInModifyMode())
                {
                    BindGrid();
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

        #region ValidateInputs
        private bool ValidateInputs(
            out string COMPANY_NO_BOX, 
            out string COMPANY_NAME, 
            out string CLOSE_FLG, 
            out string GD, 
            out string REQUEST_STATUS, 
            out string REQ_DATE_FROM, 
            out string REQ_DATE_TO, 
            out string QUOTATION_DATE_FROM, 
            out string QUOTATION_DATE_TO, 
            out string ORDER_DATE_FROM, 
            out string ORDER_DATE_TO, 
            out string SYSTEM_SETTING_STATUS)
        {
            #region Assign Variables
            COMPANY_NO_BOX = txtCompanyNoBox.Text.Trim();
            COMPANY_NAME = txtCompanyName.Text.Trim();
            CLOSE_FLG = rdoAll.Text;
            if (rdoProcessing.Checked)
            {
                CLOSE_FLG = rdoProcessing.Text;
            }
            if (rdoClose.Checked)
            {
                CLOSE_FLG = rdoClose.Text;
            }
            GD = cboGD.SelectedValue == null ? "" : cboGD.SelectedValue.ToString();
            REQUEST_STATUS = cboApplicationStatus.SelectedValue == null ? "" : cboApplicationStatus.SelectedValue.ToString();
            REQ_DATE_FROM = txtApplicationDateFrom.Text.Trim();
            REQ_DATE_TO = txtApplicationDateTo.Text.Trim();
            QUOTATION_DATE_FROM = txtQuotationIssueDateFrom.Text.Trim();
            QUOTATION_DATE_TO = txtQuotationIssueDateTo.Text.Trim();
            ORDER_DATE_FROM = txtOrderDateFrom.Text.Trim();
            ORDER_DATE_TO = txtOrderDateTo.Text.Trim();
            SYSTEM_SETTING_STATUS = cboSystemSettingStatus.SelectedValue == null ? "" : cboSystemSettingStatus.SelectedValue.ToString();
            #endregion

            #region Validate
            if (!CheckUtility.SearchConditionCheck(this, lblCompanyNoBox.Text, txtCompanyNoBox.Text, false, Utility.DataType.HALF_KANA_ALPHA_NUMERIC, 10, 0))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, lblCompanyName.Text, txtCompanyName.Text, false, Utility.DataType.FULL_WIDTH, 80, 0))
            {
                return false;
            }

            if (!DateRangeCheck(REQ_DATE_FROM, REQ_DATE_TO, "申請日"))
            {
                return false;
            }

            if (!DateRangeCheck(QUOTATION_DATE_FROM, QUOTATION_DATE_TO, "見積書発行日"))
            {
                return false;
            }

            if (!DateRangeCheck(ORDER_DATE_FROM, ORDER_DATE_TO, "注文日"))
            {
                return false;
            }
            return true;
            #endregion
        }

        #region DateRangeCheck
        private bool DateRangeCheck(string from, string to, string field)
        {

            if (!CheckUtility.SearchConditionCheck(this, field, from, false, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if (!CheckUtility.SearchConditionCheck(this, field, to, false, Utility.DataType.DATE, -1, -1))
            {
                return false;
            }

            if ((!string.IsNullOrEmpty(from)) || (!string.IsNullOrEmpty(to)))
            {
                if (!CheckUtility.DateRationalCheck(from, to))
                {
                    MetroMessageBox.Show(this, "\n" + string.Format(JimugoMessages.E000ZZ045, string.IsNullOrEmpty(from) ? "日付(From)" : from , to), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            return true;
        }
        #endregion
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                string COMPANY_NO_BOX, COMPANY_NAME, CLOSE_FLG, GD, REQUEST_STATUS, REQ_DATE_FROM, REQ_DATE_TO, QUOTATION_DATE_FROM, QUOTATION_DATE_TO, ORDER_DATE_FROM, ORDER_DATE_TO, SYSTEM_SETTING_STATUS;

                if (ValidateInputs(out COMPANY_NO_BOX, out COMPANY_NAME, out CLOSE_FLG, out GD, out REQUEST_STATUS, out REQ_DATE_FROM, out REQ_DATE_TO, out QUOTATION_DATE_FROM, out QUOTATION_DATE_TO, out ORDER_DATE_FROM, out ORDER_DATE_TO, out SYSTEM_SETTING_STATUS))
                {
                    frmUsageApplicationListController oController = new frmUsageApplicationListController();

                    DataTable dt = oController.GetApplicationList(COMPANY_NO_BOX, COMPANY_NAME, CLOSE_FLG, GD, REQUEST_STATUS, REQ_DATE_FROM, REQ_DATE_TO, QUOTATION_DATE_FROM, QUOTATION_DATE_TO, ORDER_DATE_FROM, ORDER_DATE_TO, SYSTEM_SETTING_STATUS, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData);
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

                    //check for disable flag
                    uIUtility.CheckForDisableField();
                    uIUtility.FormatUpdatedat();
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

        #region ClearSearchConditions
        private void LblClear_Click(object sender, EventArgs e)
        {
            txtCompanyNoBox.Text = "";
            txtCompanyName.Text = "";
            txtApplicationDateFrom.Text = "";
            txtApplicationDateTo.Text = "";
            txtQuotationIssueDateFrom.Text = "";
            txtQuotationIssueDateTo.Text = "";
            txtOrderDateFrom.Text = "";
            txtOrderDateTo.Text = "";
            cboGD.SelectedIndex = -1;
            cboApplicationStatus.SelectedIndex = -1;
            cboSystemSettingStatus.SelectedIndex = -1;
            cboLimit.SelectedIndex = 0;
            rdoProcessing.Checked = true;
        }
        #endregion

        #region FormSizeChanged
        private void FrmUsageApplicationList_SizeChanged(object sender, EventArgs e)
        {
            //uIUtility.ResetCheckBoxSize();
        }
        #endregion

        #region SetDefaultColumnWidths
        private void SetDefaultColumnWidths()
        {
            uIUtility.ResetCheckBoxSize();
            dgvList.Columns["colCOMPANY_NO_BOX"].Width = 110;
            dgvList.Columns["colREQ_SEQ"].Width = 40;
            dgvList.Columns["colCOMPANY_NAME"].Width = 150;
            dgvList.Columns["colCLOSE_FLG"].Width = 60;
            dgvList.Columns["colGD"].Width = 105;
            dgvList.Columns["colREQ_TYPE"].Width = 100;
            dgvList.Columns["colREQ_STATUS"].Width = 100;
            dgvList.Columns["colREQ_DATE"].Width = 145;
            dgvList.Columns["colQUOTATION_DATE"].Width = 100;
            dgvList.Columns["colORDER_DATE"].Width = 100;
            dgvList.Columns["colSYSTEM_EFFECTIVE_DATE"].Width = 145;
            dgvList.Columns["colSYSTEM_SETTING_STATUS"].Width = 105;
            dgvList.Columns["colCOMPLETION_NOTIFICATION_DATE"].Width = 100;
            dgvList.Columns["colUPDATED_AT"].Width = 145;
            dgvList.Columns["colUPDATED_BY"].Width = 120;
            dgvList.Columns["colUPDATE_MESSAGE"].Width = 350;
        }
        #endregion

        #region DrawColumnHeaders

        private void Add_Password_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void Add_Login_Info_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Password_Header(e, 8, 3, "利用申請");
            Add_Login_Info_Header(e, 13, 2, "システム設定");
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

        #region ModifyButton
        private void BtnModify_Click(object sender, EventArgs e)
        {
            uIUtility.CommonGridManage("M");
        }

        #endregion

        #region CancelButton
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            uIUtility.CancelChanges();
            uIUtility.CheckForDisableField();
        }

        #endregion

        #region DataSourceChanged_HandlePaginationButtons
        private void DgvList_DataSourceChanged(object sender, EventArgs e)
        {
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);

        }
        #endregion

        #region SubmitButton
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //get column values where MK not null or empty
            DataTable dt = uIUtility.SubmitChanges();

            //send to web service
            frmUsageApplicationListController oController = new frmUsageApplicationListController();
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

        #region WatchMKValue_and_ModifyGrid
        private void DgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                uIUtility.WatchMKValue(e);

            }
            catch (Exception)
            {
                //skip in form load
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

        #region CheckAll
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(true);
        }

        #endregion

        #region UnCheckall
        private void BtnUnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(false);
        }
        #endregion

        #region ApplicationCancelButton
        private void BtnCancelApplication_Click(object sender, EventArgs e)
        {
            //get checked columns
            DataTable dt = uIUtility.GetCheckedValuesForMail(); 

            //send to web service
            frmUsageApplicationListController oController = new frmUsageApplicationListController();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DataTable result = oController.SubmitApplicationCancel(dt, out uIUtility.MetaData);

                    //update data grid view
                    uIUtility.UpdateReturnedresults(result);
                }
               
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

        #region ShowMailLoading
        private void ShowMailLoading()
        {
            Application.Run(new frmMailLoading());
        }
        #endregion

        #region ConfirmationRequestButton
        private void BtnGDConfirmationRequest_Click(object sender, EventArgs e)
        {
            try
            {
                //get checked columns
                DataTable dt = uIUtility.GetCheckedValuesForMail();

                if (dt.Rows.Count > 0 )
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + "メール送信しますか？", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.OK)
                    {
                        //Show mail progress message
                        Thread mailthread = new Thread(new ThreadStart(ShowMailLoading));
                        mailthread.Start();
                        //send to web service
                        frmUsageApplicationListController oController = new frmUsageApplicationListController();
                   
                        DataTable result = oController.SubmitConfirmationRequest(dt, out uIUtility.MetaData);

                        //update data grid view
                        uIUtility.UpdateReturnedresults(result);

                    
                        mailthread.Abort();
                    }
                
                }
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

        #region ConfirmationCompleteButton
        private void BtnGDConfirmationComplete_Click(object sender, EventArgs e)
        {
            try
            {
                //get checked columns
                DataTable dt = uIUtility.GetCheckedValuesForMail();

                if (dt.Rows.Count > 0)
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + "メール送信しますか？", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.OK)
                    {
                        //Show mail progress message
                        Thread mailthread = new Thread(new ThreadStart(ShowMailLoading));
                        mailthread.Start();

                        //send to web service
                        frmUsageApplicationListController oController = new frmUsageApplicationListController();
                    
                        DataTable result = oController.SubmitConfirmationComplete(dt, out uIUtility.MetaData);

                        //update data grid view
                        uIUtility.UpdateReturnedresults(result);
                   
                        mailthread.Abort();
                    }
                }
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
                        case "colREQ_STATUS": //CTS030
                            OpenApplicationApprovalForm(dgvList.Rows[e.RowIndex]);
                            break;
                        case "colORDER_DATE": //CTS050
                            OpenPurchaseOrderForm(dgvList.Rows[e.RowIndex]);
                            break;
                        case "colSYSTEM_SETTING_STATUS":// CTS070
                            OpenUsageInfoRegistrationForm(dgvList.Rows[e.RowIndex]);
                            break;
                        case "colCOMPLETION_NOTIFICATION_DATE":// CTS060
                            OpenRegistrationCompleteNotiForm(dgvList.Rows[e.RowIndex]);
                            break;
                        case "colQUOTATION_DATE"://CTS040
                            OpenIssueQuotationForm(dgvList.Rows[e.RowIndex]);
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

        #region OpenApplicationApprovalForm
        private void OpenApplicationApprovalForm(DataGridViewRow row)
        {
            frmApplicationApproval frm = new frmApplicationApproval(
                    "CTS030",
                    GetProgramNameByID("CTS030"),
                    Convert.ToString(row.Cells["colCOMPANY_NO_BOX"].Value),
                    Convert.ToString(row.Cells["colREQ_SEQ"].Value),
                    Convert.ToString(row.Cells["colREQ_TYPE"].Value),
                    Convert.ToString(row.Cells["colREQ_STATUS"].Value)
                );
            if (frm.ShowDialog() == DialogResult.OK)
            {
                row.Cells["colREQ_STATUS"].Value = frm.REQ_STATUS_RAW;
                row.Cells["colUPDATED_AT"].Value = frm.UPDATED_AT;
                row.Cells["colUPDATED_AT_RAW"].Value = frm.UPDATED_AT_RAW;
                row.Cells["colUPDATED_BY"].Value = Utility.Id;
                frm.Dispose();
            }
        }
        #endregion

        #region OpenUsageInfoRegistrationForm
        private void OpenUsageInfoRegistrationForm(DataGridViewRow row)
        {
            string value = Convert.ToString(row.Cells["colREQ_STATUS"].Value);
            if (value == "承認済" || value == "申請取消")
            {
                frmUsageInfoRegistrationList frm = new frmUsageInfoRegistrationList(
                    "CTS070", 
                    GetProgramNameByID("CTS070"),
                    row.Cells["colCOMPANY_NO_BOX"].Value.ToString(),
                    ""
                );
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    row.Cells["colSYSTEM_SETTING_STATUS"].Value = frm.SYSTEM_SETTING_STATUS;
                    row.Cells["colUPDATED_AT"].Value = frm.UPDATED_AT;
                    row.Cells["colUPDATED_AT_RAW"].Value = frm.UPDATED_AT_RAW;
                    row.Cells["colUPDATED_BY"].Value = Utility.Id;
                    frm.Dispose();
                }
            }
        }
        #endregion

        #region OpenOrderRegistrationForm
        private void OpenPurchaseOrderForm(DataGridViewRow row)
        {
            string value = Convert.ToString(row.Cells["colQUOTATION_DATE"].Value);
            if (value != null)
            {
                OrderRegistration.frmPurchaseOrder frm = new OrderRegistration.frmPurchaseOrder(
                    "CTS050", GetProgramNameByID("CTS050"),
                    Convert.ToString(row.Cells["colCOMPANY_NO_BOX"].Value),
                    Convert.ToString(row.Cells["colREQ_SEQ"].Value),
                    Convert.ToString(row.Cells["colQUOTATION_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colQUOTATION_DATE"].Value),
                    Convert.ToString(row.Cells["colORDER_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colORDER_DATE"].Value),
                    Convert.ToString(row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value),
                    Convert.ToString(row.Cells["colCOMPANY_NAME"].Value)
                );
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    row.Cells["colORDER_DATE"].Value = frm.ORDER_DATE;
                    row.Cells["colUPDATED_AT"].Value = frm.UPDATED_AT;
                    row.Cells["colUPDATED_AT_RAW"].Value = frm.UPDATED_AT_RAW;
                    row.Cells["colUPDATED_BY"].Value = Utility.Id;
                    frm.Dispose();
                }
            }
        }
        #endregion

        #region OpenIssueQuotationForm
        private void OpenIssueQuotationForm(DataGridViewRow row)
        {
            string value = Convert.ToString(row.Cells["colQUOTATION_DATE"].Value);
            if (value != null)
            {
                frmIssueQuotation frm = new frmIssueQuotation(
                    "CTS040", GetProgramNameByID("CTS040"),
                    Convert.ToString(row.Cells["colCOMPANY_NO_BOX"].Value),
                    Convert.ToString(row.Cells["colREQ_SEQ"].Value),
                    Convert.ToString(row.Cells["colQUOTATION_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colQUOTATION_DATE"].Value),
                    Convert.ToString(row.Cells["colORDER_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colORDER_DATE"].Value),
                    Convert.ToString(row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value),
                    Convert.ToString(row.Cells["colCOMPANY_NAME"].Value)
                );
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    row.Cells["colQUOTATION_DATE"].Value = frm.QUOTIATION_DATE;
                    row.Cells["colUPDATED_AT"].Value = frm.UPDATED_AT;
                    row.Cells["colUPDATED_AT_RAW"].Value = frm.UPDATED_AT_RAW;
                    row.Cells["colUPDATED_BY"].Value = Utility.Id;
                    frm.Dispose();
                }
            }
        }
        #endregion

        #region OpenRegistrationCompleteNotiForm

        private void OpenRegistrationCompleteNotiForm(DataGridViewRow row)
        {
             string value = Convert.ToString(row.Cells["colREQ_STATUS"].Value);
            if (value == "承認済" || value == "申請取消")
            {
                frmRegisterCompleteNotification frm = new frmRegisterCompleteNotification(
                    "CTS060",
                    GetProgramNameByID("CTS060"),
                    row.Cells["colCOMPANY_NO_BOX"].Value.ToString(),
                    row.Cells["colREQ_SEQ"].Value.ToString(),
                    Convert.ToString(row.Cells["colQUOTATION_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colQUOTATION_DATE"].Value),
                    Convert.ToString(row.Cells["colORDER_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colORDER_DATE"].Value),
                    Convert.ToString(row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value) == "*" ? "" : Convert.ToString(row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value),
                    row.Cells["colCOMPANY_NAME"].Value.ToString()
                );
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    row.Cells["colCOMPLETION_NOTIFICATION_DATE"].Value = frm.COMPLETION_NOTIFICATION_DATE;
                    row.Cells["colUPDATED_AT"].Value = frm.UPDATED_AT;
                    row.Cells["colUPDATED_AT_RAW"].Value = frm.UPDATED_AT_RAW;
                    row.Cells["colUPDATED_BY"].Value = Utility.Id;
                    frm.Dispose();
                }
            }
        }
        #endregion

        private void DgvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            uIUtility.setComboAlignCenter(e);
        }
    }
}
