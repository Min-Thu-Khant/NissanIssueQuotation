using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using AmigoPaperWorkProcessSystem.Jimugo;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmCompanyCodeList : Form
    {

        #region Declare
        private UIUtility uIUtility;
        private List<Validate> Insertable = new List<Validate>{
            new Validate{ Name = "colAUTO_INDEX_ID", Type = Utility.DataType.TEXT, Edit = true, Require = true, Initial ="サプライヤ", Max = 10, },
            new Validate{ Name = "colCOMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 80},
            new Validate{ Name = "colPASSWORD_", Type = Utility.DataType.TEXT, Edit = false, Require = true, Max = 100 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = false, Max = 16, Min = 16 ,},
            new Validate{ Name = "colPASSWORD_EXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit = true, Require = false, Max = 16, Min = 16},
            new Validate{ Name = "colEMAIL_ADDRESS", Type = Utility.DataType.EMAIL, Edit = true, Require = true, Max = 255 },
            new Validate{ Name = "colLOGIN_FAIL_COUNT", Type = Utility.DataType.HALF_NUMBER, Edit = false, Require = false, Initial = "0", Max = 100, Min=0},
            new Validate{ Name = "colGD_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Max = 6 },
            new Validate{ Name = "colDISABLED_FLG", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "*" , Max = 1 },
            new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.DATE_RANGE, Edit=true, Require = false, Max = 16, Min = 16 , Data1="colPASSWORD_SET_DATE", Data2="colPASSWORD_EXPIRATION_DATE"},
            new Validate{ Name = "colCOMPANY_NO", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 },
            new Validate{ Name = "colCOMPANY_BOX",Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 }
        };

        private List<Validate> Copyable = new List<Validate>{
            new Validate{ Name = "colAUTO_INDEX_ID", Type = Utility.DataType.TEXT, Edit = false, Require = false, Initial ="copy", Max = 10, },
            new Validate{ Name = "colCOMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Initial ="copy", Max = 80},
            new Validate{ Name = "colPASSWORD_", Type = Utility.DataType.TEXT, Edit = false, Require = true, Max = 100 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = false, Max = 16, Min = 16 ,},
            new Validate{ Name = "colPASSWORD_EXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit = true, Require = false, Max = 16, Min = 16},
            new Validate{ Name = "colEMAIL_ADDRESS", Type = Utility.DataType.EMAIL, Edit = true, Require = true, Max = 255 },
            new Validate{ Name = "colLOGIN_FAIL_COUNT", Type = Utility.DataType.HALF_NUMBER, Edit = false, Require = false, Initial = "0", Max = 100, Min=0 },
            new Validate{ Name = "colGD_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Initial="copy", Max = 6 },
            new Validate{ Name = "colDISABLED_FLG", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "*" , Max = 1 },
            new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50 },
            new Validate{ Name = "colCOMPANY_NO", Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 },
            new Validate{ Name = "colCOMPANY_BOX",Type = Utility.DataType.TEXT, Edit=false, Require=false, Initial = "copy" , Max = 255 }
        };

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colCOMPANY_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 80},
            new Validate{ Name = "colPASSWORD_", Type = Utility.DataType.TEXT, Edit = false, Require = true, Max = 100 },
            new Validate{ Name = "colPASSWORD_SET_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = false, Max = 16, Min = 16 ,},
            new Validate{ Name = "colPASSWORD_EXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit = true, Require = false, Max = 16, Min = 16},
            new Validate{ Name = "colEMAIL_ADDRESS", Type = Utility.DataType.EMAIL, Edit = true, Require = false, Max = 255 },
            new Validate{ Name = "colLOGIN_FAIL_COUNT", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true,Max = 100, Min=0},
            new Validate{ Name = "colGD_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = false, Initial="copy", Max = 6 },
            new Validate{ Name = "colDISABLED_FLG", Type = Utility.DataType.TEXT, Edit=true, Require=false, Max = 1 },
            new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 50 }
        };

        private string[] dummyColumns = {
            "No",
            "CK",
            "MK",
            "COMPANY_NO_BOX",
            "AUTO_INDEX_ID",
            "COMPANY_NAME",
            "PASSWORD",
            "PASSWORD_SET_DATE",
            "PASSWORD_EXPIRATION_DATE",
            "EMAIL_ADDRESS",
            "EMAIL_SEND_DATE",
            "LOGIN_FAIL_COUNT",
            "SESSION_ID",
            "LAST_ACCESS_DATE",
            "LAST_FAIL_DATE",
            "GD_CODE",
            "DISABLED_FLG",
            "MEMO",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "SOCIOS_USER_FLG",
            "COPY_COMPANY_NO_BOX",
            "COMPANY_NO",
            "COMPANY_BOX",
            "UPDATED_AT_RAW",
            "ROW_ID"
        };

        #endregion

        #region Properties
        public string programID { get; set; }
        public string programName { get; set; }
        #endregion

        #region Constructors
        public frmCompanyCodeList()
        {
            InitializeComponent();
        }

        public frmCompanyCodeList(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }
        #endregion

        #region FormLoad
        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;

            //utility
            uIUtility = new UIUtility(dgvList, Insertable, Copyable, Modifiable, dummyColumns);
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
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit); //search filter
        }
        #endregion

        #region Search
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
                string company_no_box , company_name,  email ;

                if (!CheckUtility.SearchConditionCheck(this, txtCompanyNoBox.Text, false, Utility.DataType.HALF_KANA_ALPHA_NUMERIC, 10, 0))
                {
                    return;
                }

                if (!CheckUtility.SearchConditionCheck(this, txtCompanyName.Text, false, Utility.DataType.FULL_WIDTH, 80, 0))
                {
                    return;
                }

                if (!CheckUtility.SearchConditionCheck(this, txtEmail.Text, false, Utility.DataType.HALF_ALPHA_NUMERIC, 255, 0))
                {
                    return;
                }
                company_no_box = txtCompanyNoBox.Text.Trim();
                company_name = txtCompanyName.Text.Trim();
                email = txtEmail.Text.Trim();

                frmCompanyCodeListController oController = new frmCompanyCodeListController();

                DataTable dt = oController.GetCompanyCodeList(company_no_box, company_name, email, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData);
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

        #region ClearLabel
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
            txtEmail.Text = "";
            cboLimit.SelectedIndex = 0;
            uIUtility.ClearDataGrid();
            lblTotalRecords.Text = "";
            lblTotalPages.Text = "0";
            lblcurrentPage.Text = "0";
        }

        #endregion

        #region FormSizeChanged
        private void FrmCustomerList_SizeChanged(object sender, EventArgs e)
        {
            uIUtility.ResetCheckBoxSize();
        }
        #endregion

        #region SetDefaultColumnWidths
        private void SetDefaultColumnWidths()
        {
            uIUtility.ResetCheckBoxSize();
            dgvList.Columns["colCOMPANY_NO_BOX"].Width = 110;
            dgvList.Columns["colAUTO_INDEX_ID"].Width = 70;
            dgvList.Columns["colCOMPANY_NAME"].Width = 150;
            dgvList.Columns["colPASSWORD_"].Width = 100;
            dgvList.Columns["colPASSWORD_SET_DATE"].Width = 145;
            dgvList.Columns["colPASSWORD_EXPIRATION_DATE"].Width = 145;
            dgvList.Columns["colEMAIL_ADDRESS"].Width = 200;
            dgvList.Columns["colEMAIL_SEND_DATE"].Width = 145;
            dgvList.Columns["colLOGIN_FAIL_COUNT"].Width = 75;
            dgvList.Columns["colSESSION_ID"].Width = 100;
            dgvList.Columns["colLAST_ACCESS_DATE"].Width = 145;
            dgvList.Columns["colLAST_FAIL_DATE"].Width = 145;
            dgvList.Columns["colGD_CODE"].Width = 80;
            dgvList.Columns["colMEMO"].Width = 200;
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
            Add_Password_Header(e, 7, 2, "パスワード");
            Add_Login_Info_Header(e, 11, 4, "ログイン情報");
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
            CommonGridManage("M");
        }
        #endregion

        #region InsertButton
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            CommonGridManage("I");
        }
        #endregion

        #region DeleteButton
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CommonGridManage("D");
        }
        #endregion

        #region CancelButton
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            uIUtility.CancelChanges();
            uIUtility.CheckForDisableField();
        }
        #endregion

        #region CopyButton
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            CommonGridManage("C");
        }
        #endregion

        #region SubmitButton
        private void BtnSubmit_Click(object sender, EventArgs e)
        {   
            //get column values where MK not null or empty
            DataTable dt = uIUtility.SubmitChanges();

            if (dt.Rows.Count>0)
            {
                //send to web service
                frmCompanyCodeListController oController = new frmCompanyCodeListController();
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

        #region CommonGridManage
        public void CommonGridManage(string operation)
        {
            if (uIUtility.checkSelectedRow())
            {
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    string originalvalue = dgvList.Rows[i].Cells["colMK"].Value == null ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString();
                    string checkvalue = dgvList.Rows[i].Cells["colCK"].Value.ToString().Trim();
                    
                    if (String.IsNullOrEmpty(checkvalue) ? false : true)
                    {
                        switch (operation)
                        {
                            case "I":
                                uIUtility.InsertMode(operation, dgvList.Rows[i], true);
                                i++;
                                break;
                            case "M":
                                if (originalvalue != "D" || String.IsNullOrEmpty(originalvalue == null ? null : originalvalue.Trim()) || originalvalue =="O" || originalvalue =="X")
                                {
                                    dgvList.Rows[i].Cells["colMK"].Value = operation;
                                }
                                break;
                            case "D":
                                if (originalvalue == "I" || originalvalue == "C")
                                {
                                    uIUtility.dtList.Rows[i].Delete(); //delete row
                                    i--;
                                }
                                else
                                {
                                    dgvList.Rows[i].Cells["colMK"].Value = operation;
                                }
                                break;
                            case "C":
                                uIUtility.CopyMode(operation, dgvList.Rows[i], true);
                                IncreaseCompanyNoBox(i);
                                i++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else
            {
                if ((operation != "I") )
                {
                    MetroMessageBox.Show(dgvList.Parent, "\n" + JimugoMessages.E000ZZ004, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            //if there is no row in datagrid view and insert button is clicked
            bool Ischecked = uIUtility.checkSelectedRow();
            if ((dgvList.Rows.Count <= 0 && operation == "I") || (!Ischecked && operation == "I"))
            {
                uIUtility.InsertInitialRow(operation);
            }

        }
        #endregion

        #region IncreaseCompanyNoBox
        private void IncreaseCompanyNoBox(int index)
        {
            //get COMPANY_NO value
            string company_no = dgvList.Rows[index].Cells["colCOMPANY_NO"].Value.ToString();

            //get COMPANY_BOX value
            string company_box = dgvList.Rows[index].Cells["colCOMPANY_BOX"].Value.ToString();


            //get number only
            int number = int.Parse(company_box);

            //increase number;
            number += 1;

            //dgvList.Rows[index + 1].Cells["colCOMPANY_NO_BOX"].Value = company_no + "-" + number.ToString().PadLeft(2, '0');
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
                uIUtility.MetaData.Offset = (int.Parse(lblTotalPages.Text.Replace("Pages","").Trim()) - 1) * int.Parse(cboLimit.SelectedValue.ToString());
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

        #region UncheckAll
        private void BtnUnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(false);
        }
        #endregion

        #region PasswordGenerateButton
        private void BtnGeneratePassword_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    string MK_Value = dgvList.Rows[i].Cells["colMK"].Value == null ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString();
                    if (MK_Value == "I" || MK_Value == "C" || MK_Value == "M")
                    {
                        frmCompanyCodeListController companyCodeList = new frmCompanyCodeListController();
                        DataTable dt = companyCodeList.GetPassword();

                        //update datagrid
                        dgvList.Rows[i].Cells["colPASSWORD_"].Value = dt.Rows[0]["PASSWORD"].ToString();
                        dgvList.Rows[i].Cells["colPASSWORD_SET_DATE"].Value = dt.Rows[0]["PASSWORD_SET_DATE"].ToString();
                        dgvList.Rows[i].Cells["colPASSWORD_EXPIRATION_DATE"].Value = dt.Rows[0]["PASSWORD_EXPIRATION_DATE"].ToString();
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

        #region Send Mail
        private async void BtnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = uIUtility.GetCheckedValuesForMail();
                if (dt.Rows.Count > 0)
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + "メール送信しますか？", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.OK)
                    {
                        //Show mail progress message
                        Thread mailthread = new Thread(new ThreadStart(ShowMailLoading));
                        mailthread.Start();
                        //call mail send method from web service
                        frmCompanyCodeListController companyCodeList = new frmCompanyCodeListController();
                        DataTable result = await companyCodeList.SendMail(dt);

                        //update data grid view
                        uIUtility.UpdateReturnedresults(result);

                        //close mail dialog
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

        #region ShowMailLoading
        private void ShowMailLoading()
        {
            Application.Run(new frmMailLoading());
        }
        #endregion
        #endregion

        #region DataErrorEvent
        private void DgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        #endregion

    }
}
