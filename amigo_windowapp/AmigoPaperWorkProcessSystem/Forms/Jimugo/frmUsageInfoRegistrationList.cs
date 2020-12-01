using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using AmigoPaperWorkProcessSystem.Jimugo;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmUsageInfoRegistrationList : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private DataTable EDITable = new DataTable();
        private bool FirstLunch = true;

        private List<Validate> Insertable = new List<Validate>{
            new Validate{ Name = "colEDI_ACCOUNT", Type = Utility.DataType.EDI_ACCOUNT, Edit = true, Require = true, Max = 4, Min = 4},
            new Validate{ Name = "colCOMPANY_NO_BOX", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require = true, Max = 10 },
            new Validate{ Name = "colCONSIGN_FLG", Edit=true, Require=false, Type = Utility.DataType.HALF_ALPHA_NUMERIC, Max = 1 },
            new Validate{ Name = "colLOGIN_TYPE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Initial="B", Max = 1, Min = 1 },
            new Validate{ Name = "colMAKER1", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER2", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER3", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER4", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER5", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER6", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER7", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER8", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER9", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER10", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colADM_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC , Edit=true, Require=false, Max = 64 },
            new Validate{ Name = "colADM_PASSWORD", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 100 },
            new Validate{ Name = "colATDL_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 64 },
            new Validate{ Name = "colATDL_PASSWORD", Type = Utility.DataType.HALF_ALPHA_NUMERIC,  Edit=true, Require=false, Max = 100 },
            new Validate{ Name = "colSSHGW_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 20 },
            new Validate{ Name = "colSSHGW_PUBLIC_KEY", Type = Utility.DataType.HALF_ALPHA_NUMERIC,  Edit=true, Require=false, Max = 255 }
        };

        private List<Validate> Copyable  = new List<Validate>{
            new Validate{ Name = "colEDI_ACCOUNT", Type = Utility.DataType.EDI_ACCOUNT, Edit = true, Require = true, Max = 4, Min = 4},
            new Validate{ Name = "colCOMPANY_NO_BOX", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require = true, Max = 10 },
            new Validate{ Name = "colCONSIGN_FLG", Edit=true, Require=false, Type = Utility.DataType.HALF_ALPHA_NUMERIC, Max = 1 },
            new Validate{ Name = "colLOGIN_TYPE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Initial="B", Max = 1, Min = 1 },
            new Validate{ Name = "colMAKER1", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER2", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER3", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER4", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER5", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER6", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER7", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER8", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER9", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER10", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colADM_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC , Edit=true, Require=false, Max = 64 },
            new Validate{ Name = "colADM_PASSWORD", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 100 },
            new Validate{ Name = "colATDL_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 64 },
            new Validate{ Name = "colATDL_PASSWORD", Type = Utility.DataType.HALF_ALPHA_NUMERIC,  Edit=true, Require=false, Max = 100 },
            new Validate{ Name = "colSSHGW_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 20 },
            new Validate{ Name = "colSSHGW_PUBLIC_KEY", Type = Utility.DataType.HALF_ALPHA_NUMERIC,  Edit=true, Require=false, Max = 255 }
        };

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colCONSIGN_FLG", Edit=true, Require=false, Type = Utility.DataType.HALF_ALPHA_NUMERIC, Max = 1 },
            new Validate{ Name = "colLOGIN_TYPE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 1, Min = 1 },
            new Validate{ Name = "colMAKER1", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER2", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER3", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER4", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER5", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER6", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER7", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER8", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER9", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colMAKER10", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 4 },
            new Validate{ Name = "colADM_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC , Edit=true, Require=false, Max = 64 },
            new Validate{ Name = "colADM_PASSWORD", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 100 },
            new Validate{ Name = "colATDL_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 64 },
            new Validate{ Name = "colATDL_PASSWORD", Type = Utility.DataType.HALF_ALPHA_NUMERIC,  Edit=true, Require=false, Max = 100 },
            new Validate{ Name = "colSSHGW_USER_ID", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit=true, Require=false, Max = 20 },
            new Validate{ Name = "colSSHGW_PUBLIC_KEY", Type = Utility.DataType.HALF_ALPHA_NUMERIC,  Edit=true, Require=false, Max = 255 }
        };

        private string[] dummyColumns = {
            "No",
            "CK",
            "MK",
            "EDI_ACCOUNT",
            "COMPANY_NO_BOX",
            "COMPANY_NAME",
            "GD_CODE",
            "CONSIGN_FLG",
            "LOGIN_TYPE",
            "MAKER1",
            "MAKER2",
            "MAKER3",
            "MAKER4",
            "MAKER5",
            "MAKER6",
            "MAKER7",
            "MAKER8",
            "MAKER9",
            "MAKER10",
            "BOX_SIZE",
            "SERVER_CONNECTION_TYPE",
            "CAI_SERVER_IP_ADDRESS",
            "PLAN_AMIGO_BIZ",
            "PLAN_AMIGO_CAI",
            "MAIL_ADDRESS1",
            "MAIL_ADDRESS2",
            "MAIL_ADDRESS3",
            "ADM_USER_ID",
            "ADM_PASSWORD",
            "ATDL_USER_ID",
            "ATDL_PASSWORD",
            "SSHGW_USER_ID",
            "SSHGW_PUBLIC_KEY",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "UPDATED_AT_RAW",
            "ROW_ID"
        };

        #endregion

        #region Properties
        public string programID { get; set; }
        public string programName { get; set; }

        public string SYSTEM_SETTING_STATUS { get; set; }

        public string UPDATED_AT { get; set; }
        public string UPDATED_AT_RAW { get; set; }

        public bool SEARCH { get; set; }
        #endregion

        #region Constructors
        public frmUsageInfoRegistrationList()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.SEARCH = false;
        }
        public frmUsageInfoRegistrationList(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }

        public frmUsageInfoRegistrationList(string programID, string programName, string COMPANY_NO_BOX, string EID_ACCOUNT) : this()
        {
            this.programID = programID;
            this.programName = programName;
            txtCompanyNoBox.Text = COMPANY_NO_BOX.Trim();
            txtEDIAccount.Text = EID_ACCOUNT.Trim();
            this.SEARCH = true;
            
        }

        #endregion

        #region FormLoad
        private void FrmUsageInfoRegistrationList_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;
            this.Text = "[" + programID + "] " + programName;

            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;
            this.Font = Properties.Settings.Default.jimugoFont;

            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            uIUtility = new UIUtility(dgvList, Insertable, Copyable, Modifiable, dummyColumns);
            uIUtility.ResetCheckBoxSize();//adjust checkbox sizes
            uIUtility.DummyTable();// add dummy table to merge columns
            uIUtility.DisableAutoSort();//disable autosort
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
            PopulateDropdowns();

            if (this.SEARCH)
            {
                btnSearch.PerformClick();
            }
        }

        #endregion

        #region BindGrid
        private void BindGrid()
        {
            try
            {
                string company_no_box , company_name, edi_account;

                if (!CheckUtility.SearchConditionCheck(this, lblCompanyNoBox.Text , txtCompanyNoBox.Text, false, Utility.DataType.HALF_ALPHA_NUMERIC, 10, 0))
                {
                    return;
                }

                if (!CheckUtility.SearchConditionCheck(this, lblCompanyName.Text, txtCompanyName.Text, false, Utility.DataType.FULL_WIDTH, 80, 0))
                {
                    return;
                }

                if (!CheckUtility.SearchConditionCheck(this, lblEDIAccount.Text, txtEDIAccount.Text, false, Utility.DataType.EDI_ACCOUNT, 4, 0))
                {
                    return;
                }

                company_no_box = txtCompanyNoBox.Text.Trim();
                company_name = txtCompanyName.Text.Trim();
                edi_account = txtEDIAccount.Text.Trim();

                frmUsageInfoRegistrationListController oController = new frmUsageInfoRegistrationListController();

                DataTable dt = oController.GetUsageInfoRegistrationList(company_no_box, company_name, edi_account, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData);
                if (dt.Rows.Count > 0)
                {
                    uIUtility.dtList = dt;
                    dgvList.DataSource = uIUtility.dtList;
                    uIUtility.dtOrigin = uIUtility.dtList.Copy();

                    //pagination
                    uIUtility.CalculatePagination(lblcurrentPage, lblTotalPages, lblTotalRecords);
                    uIUtility.FormatUpdatedat();
                }
                else
                {
                    //pagination
                    uIUtility.CalculatePagination(lblcurrentPage, lblTotalPages, lblTotalRecords);

                    //clear data except headers
                    uIUtility.ClearDataGrid();
                }
                uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);

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

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit); //search filter
        }
        #endregion

        #region ClearLable
        private void LblClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        #endregion

        #region ClearSearchCondition
        private void ClearSearch()
        {
            txtCompanyName.Text = "";
            txtCompanyNoBox.Text = "";
            txtEDIAccount.Text = "";
            cboLimit.SelectedIndex = 0;
        }
        #endregion

        #region Pagination
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

        #region PrevButton
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

        #region LastButton
        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (!uIUtility.IsInModifyMode())
            {
                uIUtility.MetaData.Offset = (int.Parse(lblTotalPages.Text) - 1) * int.Parse(cboLimit.SelectedValue.ToString());
                BindGrid();
            }
        }
        #endregion

        #region CheckAllButton
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(true);
        }
        #endregion

        #region UnCheckButton
        private void BtnUnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(false);
        }
        #endregion

        #endregion

        #region SearchButton
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FirstLunch = true; //reset random pool
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
            catch (Exception)
            {
            }
        }

        #endregion

        #region ModifyButton
        private void BtnModify_Click(object sender, EventArgs e)
        {
            uIUtility.CommonGridManage("M");
        }
        #endregion

        #region InsertButton
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            uIUtility.CommonGridManage("I");
        }
        #endregion

        #region CopyButton
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            uIUtility.CommonGridManage("C");
        }
        #endregion

        #region DeleteButton
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            uIUtility.CommonGridManage("D");
        }
        #endregion

        #region Send Mail
        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (uIUtility.checkSelectedRow())
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + "メール送信しますか？", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.OK)
                    {
                        
                        DataTable dt = uIUtility.GetCheckedValuesForMail();
                        if (dt.Rows.Count > 0)
                        {
                            //Show mail progress message
                            Thread mailthread = new Thread(new ThreadStart(ShowMailLoading));
                            mailthread.Start();

                            //send to web service
                            frmUsageInfoRegistrationListController oController = new frmUsageInfoRegistrationListController();
                            DataTable result = oController.SettingComplete(dt, out uIUtility.MetaData);

                            //close mail dialog
                            mailthread.Abort();

                            //update data grid view
                            uIUtility.UpdateReturnedresults(result);
                        }
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

        #region ShowMailLoading
        private void ShowMailLoading()
        {
            Application.Run(new frmMailLoading());
        }
        #endregion
        #endregion

        #region CellValueChanged
        private void DgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                uIUtility.WatchMKValue(e);
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region EDIAutoSetButton
        private void BtnEDI_AutoNumber_Click(object sender, EventArgs e)
        {
            if (uIUtility.IsInInsertOrCopyMode())
            {
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    string mkValue = dgvList.Rows[i].Cells["colMK"].Value == null ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString().Trim();
                    string ckValue = dgvList.Rows[i].Cells["colCK"].Value == null ? null : dgvList.Rows[i].Cells["colCK"].Value.ToString().Trim();

                    if ((!String.IsNullOrEmpty(ckValue)) && (mkValue=="I" || mkValue=="C"))
                    {
                        GenerateEDIAccount(i);
                    }
                }
            }
        }
        #endregion

        #region GenerateEDIAccount
        private void GenerateEDIAccount(int index)
        {
            try
            {
                frmUsageInfoRegistrationListController oController = new frmUsageInfoRegistrationListController();
                if ((EDITable.Rows.Count <= 0) && FirstLunch)//if it is first time
                {
                    EDITable = oController.GetEDICandidates();
                    FirstLunch = false;
                }

                if (EDITable.Rows.Count <= 0) //if there is no candidate left
                {
                    //show message here
                    dgvList.Rows[index].Cells["colUPDATE_MESSAGE"].Value = JimugoMessages.E000ZZ042;
                    dgvList.Rows[index].Cells["colMK"].Value = "X";
                    //end process
                }
                else
                {
                    //get random EDI account
                    int totalAccounts = EDITable.Rows.Count;

                    Random random = new System.Random();
                    int randomIndex = random.Next(0, totalAccounts - 1);

                    //random account
                    string EDIAccount = EDITable.Rows[randomIndex][0].ToString();

                    string COMPANY_NO_BOX = dgvList.Rows[index].Cells["colCOMPANY_NO_BOX"].Value == null ? "" : dgvList.Rows[index].Cells["colCOMPANY_NO_BOX"].Value.ToString();
                    if (string.IsNullOrEmpty(COMPANY_NO_BOX))
                    {
                        dgvList.Rows[index].Cells["colUPDATE_MESSAGE"].Value =  String.Format(JimugoMessages.E000ZZ051, "会社番号＋BOX");
                        dgvList.Rows[index].Cells["colMK"].Value = "X";
                    }
                    else
                    {
                        //remove current account from random pool
                        EDITable.Rows.RemoveAt(randomIndex);

                        //get more info for EDIAccount
                        DataTable dt = oController.GetEDIAccountDetail(COMPANY_NO_BOX);

                        //set values
                        SetEDIValue(dt.Rows[0], index, EDIAccount);
                    }
                   

                }
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }


        }
        #endregion

        #region SetEdiValue
        public void SetEDIValue(DataRow EDIDetail, int index, string EDIAccount)
        {
            //EDIAccount
            dgvList.Rows[index].Cells["colEDI_Account"].Value = "@" + EDIAccount;

            //COMPANY NAME
            dgvList.Rows[index].Cells["colCOMPANY_NAME"].Value = EDIDetail["COMPANY_NAME"] == null ? "" : EDIDetail["COMPANY_NAME"].ToString().Trim();

            //GD CODE
            dgvList.Rows[index].Cells["colGD_CODE"].Value = EDIDetail["GD_CODE"] == null ? "" : EDIDetail["GD_CODE"].ToString().Trim();

            //CONTRACT MAKER 1
            dgvList.Rows[index].Cells["colMAKER1"].Value = EDIDetail["CONTRACT_MAKER1"] == null ? "" : EDIDetail["CONTRACT_MAKER1"].ToString().Trim();

            //ADMIN ID
            dgvList.Rows[index].Cells["colADM_USER_ID"].Value = EDIAccount.Substring(0,2) + "ADM01";

            //ADMIN INITIAL PASSWORD
            dgvList.Rows[index].Cells["colADM_USER_ID"].Value = Crypto.Generate8DigitPassword();

            string SERVER_CONNECTION = EDIDetail["SERVER_CONNECTION_TYPE"].ToString();
            //AUTO PASSWORD ID
            if (SERVER_CONNECTION == "C")
            {
                dgvList.Rows[index].Cells["colATDL_USER_ID"].Value = EDIAccount.Substring(0, 2) + "ADM01";
            }
            else
            {
                dgvList.Rows[index].Cells["colATDL_USER_ID"].Value = "";
            }
            //AUTO PASSWORD 
            if (SERVER_CONNECTION == "C")
            {
                dgvList.Rows[index].Cells["colATDL_PASSWORD"].Value = Crypto.Generate8DigitPassword();
            }
            else
            {
                dgvList.Rows[index].Cells["colATDL_PASSWORD"].Value = "";
            }

            //SSH USER ID
            if ((SERVER_CONNECTION == "L") || (SERVER_CONNECTION == "F"))
            {
                dgvList.Rows[index].Cells["colSSHGW_USER_ID"].Value = EDIAccount.Substring(0, 2) + Crypto.Generate6DigitPassword();
            }
            else
            {
                dgvList.Rows[index].Cells["colSSHGW_USER_ID"].Value = "";
            }

        }
        #endregion

        #region Submit
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //get column values where MK not null or empty
            DataTable dt = uIUtility.SubmitChanges();

            if (dt.Rows.Count > 0)
            {
                //send to web service
                frmUsageInfoRegistrationListController oController = new frmUsageInfoRegistrationListController();
                try
                {
                    DataTable result = oController.Submit(dt, out uIUtility.MetaData);

                    //update data grid view
                    uIUtility.UpdateReturnedresults(result);
                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(ex.Message, ex, false);
                }
            }
        }
        #endregion

        #region Cancel
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            uIUtility.CancelChanges();
        }
        #endregion

        #region DrawColumnHeaders

        private void Add_Maker(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void Add_Admin(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void Add_Automatic_Download(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void Add_Supplier(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Maker(e, 9, 10, "契約メーカー");
            Add_Admin(e, 27, 2, "管理者");
            Add_Automatic_Download(e, 29, 2, "自動ダウンロード");
            Add_Supplier(e, 31, 2, "Supplier");
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
    }
}
