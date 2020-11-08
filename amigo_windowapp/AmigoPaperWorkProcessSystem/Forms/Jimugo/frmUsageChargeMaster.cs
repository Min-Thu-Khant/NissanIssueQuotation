using AmigoPaperWorkProcessSystem.Controllers;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frmUsageChargeMaster : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private string programID = "";
        private string programName = "";

        private List<Validate> Insertable = new List<Validate>{
                new Validate{ Name = "colFEE_STRUCTURE", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 255, },
                new Validate{ Name = "colCONTRACT_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = true, Require = true, Max = 7},
                new Validate{ Name = "colCONTRACT_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 50 },
                new Validate{ Name = "colCONTRACT_QTY", Type = Utility.DataType.MINIMUM, Edit=true, Require = true, Initial="1", Min = 1 ,},
                new Validate{ Name = "colCONTRACT_QTY", Type = Utility.DataType.HALF_NUMBER, Edit=true, Require = true, Initial="1", Max = 3},
                new Validate{ Name = "colCONTRACT_UNIT", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 20},
                new Validate{ Name = "colADOPTION_DATE", Type = Utility.DataType.DATE, Edit = true, Require = true, Max = 10},
                new Validate{ Name = "colINITIAL_COST", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Initial="0", Max = 9},
                new Validate{ Name = "colMONTHLY_COST", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Initial="0", Max = 255 },
                new Validate{ Name = "colINPUT_TYPE", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 255},
                new Validate{ Name = "colNUMBER_DEFAULT", Type = Utility.DataType.INPUT_TYPE, Data1="colINPUT_TYPE", Data2="colNUMBER_DEFAULT", Edit = true, Require = false, Max = 3},
                new Validate{ Name = "colNUMBER_DEFAULT", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = false, Max = 3},
                new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 255},
                new Validate{ Name = "colDISPLAY_ORDER", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Max = 2},
                };

        private List<Validate> Copyable = new List<Validate>{
                new Validate{ Name = "colFEE_STRUCTURE", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Initial="copy", Max = 255, },
                new Validate{ Name = "colCONTRACT_CODE", Type = Utility.DataType.HALF_ALPHA_NUMERIC, Edit = false, Require = false, Initial="copy", Max = 7},
                new Validate{ Name = "colCONTRACT_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Initial="copy", Max = 50 },
                new Validate{ Name = "colCONTRACT_QTY", Type = Utility.DataType.MINIMUM, Edit=true, Require = true, Initial="copy", Min = 1 },
                new Validate{ Name = "colCONTRACT_QTY", Type = Utility.DataType.HALF_NUMBER, Edit=true, Require = true, Initial="copy", Max = 3},
                new Validate{ Name = "colCONTRACT_UNIT", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Initial="copy", Max = 20, Min=0},
                new Validate{ Name = "colADOPTION_DATE", Type = Utility.DataType.DATE, Edit = true, Require = true, Initial="copy", Max = 10},
                new Validate{ Name = "colINITIAL_COST", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Initial="copy", Max = 9},
                new Validate{ Name = "colMONTHLY_COST", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Initial="copy", Max = 255 },
                new Validate{ Name = "colINPUT_TYPE", Type = Utility.DataType.TEXT, Edit = true, Require = true, Initial="copy", Max = 255},
                new Validate{ Name = "colNUMBER_DEFAULT", Type = Utility.DataType.INPUT_TYPE, Data1="colINPUT_TYPE", Data2="colNUMBER_DEFAULT", Edit = true, Require = false, Initial="copy", Max = 3},
                new Validate{ Name = "colNUMBER_DEFAULT", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = false, Initial="copy", Max = 3},
                new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Initial="copy", Max = 255},
                new Validate{ Name = "colDISPLAY_ORDER", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Initial="copy", Max = 2},
                };

        private List<Validate> Modifiable = new List<Validate>{
                new Validate{ Name = "colFEE_STRUCTURE", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 255, },
                new Validate{ Name = "colCONTRACT_NAME", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 50 },
                new Validate{ Name = "colCONTRACT_QTY", Type = Utility.DataType.MINIMUM, Edit=true, Require = true, Min = 1 ,},
                new Validate{ Name = "colCONTRACT_QTY", Type = Utility.DataType.HALF_NUMBER, Edit=true, Require = true, Max = 3},
                new Validate{ Name = "colCONTRACT_UNIT", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = true, Max = 20, Min=0},
                new Validate{ Name = "colINITIAL_COST", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Max = 9},
                new Validate{ Name = "colMONTHLY_COST", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Max = 255 },
                new Validate{ Name = "colINPUT_TYPE", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 255},
                new Validate{ Name = "colNUMBER_DEFAULT", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Max = 3},
                new Validate{ Name = "colNUMBER_DEFAULT", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = false, Max = 3},
                new Validate{ Name = "colMEMO", Type = Utility.DataType.FULL_WIDTH, Edit = true, Require = false, Max = 255},
                new Validate{ Name = "colDISPLAY_ORDER", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Max = 2},
                };

        private string[] dummyColumns = {
            "NO",
            "CK",
            "MK",
            "FEE_STRUCTURE",
            "CONTRACT_CODE",
            "CONTRACT_NAME",
            "CONTRACT_QTY",
            "CONTRACT_UNIT",
            "ADOPTION_DATE",
            "INITIAL_COST",
            "MONTHLY_COST",
            "INPUT_TYPE",
            "NUMBER_DEFAULT",
            "MEMO",
            "DISPLAY_ORDER",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "UPDATED_AT_RAW",
            "ROW_ID"
        };

        #endregion

        #region Constructors
        public frmUsageChargeMaster()
        {
            InitializeComponent();

            setOptimalDimentions();
        }

        public frmUsageChargeMaster(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }


        #endregion

        #region FormLoad
        private void FrmUsageChargeMaster_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;

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
        }
        #endregion

        #region setOptimalDimentions
        private void setOptimalDimentions()
        {
            this.Size = Properties.Settings.Default.DefaultDimentions;
        }
        #endregion

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit); //search filter
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
                string company_no_box = txtCONTRACT_CODE.Text;
                string company_name = txtCONSTRACT_NAME.Text;
                //string email = txtEmail.Text;

                if (CheckUtility.SearchConditionCheck(this, txtCONTRACT_CODE.Text, false, Utility.DataType.HALF_ALPHA_NUMERIC, 10, 0) &&
                    CheckUtility.SearchConditionCheck(this, txtCONSTRACT_NAME.Text, false, Utility.DataType.FULL_WIDTH, 80, 0)
                    )
                {

                    frmUsageChargeMasterController oController = new frmUsageChargeMasterController();

                    DataTable dt = oController.GetUsageChargeMaster(company_no_box, company_name, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData);
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

        #region ClearLabel
        private void LblClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        #endregion

        #region ClearSearchCondition
        private void ClearSearch()
        {
            txtCONTRACT_CODE.Text = "";
            txtCONSTRACT_NAME.Text = "";
            cboLimit.SelectedIndex = 0;
            uIUtility.ClearDataGrid();
            lblTotalRecords.Text = "";
            lblTotalPages.Text = "0";
            lblcurrentPage.Text = "0";
        }



        #endregion

        #region FormSizedChanged
        private void FrmUsageChargeMaster_SizeChanged(object sender, EventArgs e)
        {
            //uIUtility.ResetCheckBoxSize();
        }
        #endregion

        #region SetDefaultColumnWidths
        private void SetDefaultColumnWidths()
        {
            uIUtility.ResetCheckBoxSize();
            dgvList.Columns["colFEE_STRUCTURE"].Width = 110;
            dgvList.Columns["colCONTRACT_CODE"].Width = 80;
            dgvList.Columns["colCONTRACT_NAME"].Width = 155;
            dgvList.Columns["colCONTRACT_QTY"].Width = 40;
            dgvList.Columns["colCONTRACT_UNIT"].Width = 40;
            dgvList.Columns["colADOPTION_DATE"].Width = 100;
            dgvList.Columns["colINITIAL_COST"].Width = 100;
            dgvList.Columns["colMONTHLY_COST"].Width = 100;
            dgvList.Columns["colINPUT_TYPE"].Width = 100;
            dgvList.Columns["colNUMBER_DEFAULT"].Width = 50;
            dgvList.Columns["colMEMO"].Width = 200;
            dgvList.Columns["colDISPLAY_ORDER"].Width = 60;
            dgvList.Columns["colUPDATED_AT"].Width = 145;
            dgvList.Columns["colUPDATED_BY"].Width = 120;
            dgvList.Columns["colUPDATE_MESSAGE"].Width = 350;
        }
        #endregion

        #region DrawColumnHeaders

        private void Add_Contract_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void Add_Charge_Header(PaintEventArgs e, int index, int count, string text)
        {
            UIUtility.Merge_Header(e, index, count, text, dgvList);
        }

        private void DgvList_Paint(object sender, PaintEventArgs e)
        {
            Add_Contract_Header(e, 5, 3, "契約");
            Add_Charge_Header(e, 9, 2, "料金");
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
        }

        #endregion

        #region CopyButton
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            CommonGridManage("C");
        }

        #endregion

        #region DataSourceChanged_HandlePaginationButtons
        private void DgvList_DataSourceChanged(object sender, EventArgs e)
        {
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);

            //check for disable flag
            //CheckForDisableField();
        }
        #endregion

        #region CheckForDisableFiled
        private void CheckForDisableField()
        {
            //check for disable flag
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                string disable_flg = dgvList.Rows[i].Cells["colDISABLED_FLG"].Value.ToString();
                string ck_value = dgvList.Rows[i].Cells["colCK"].Value == null ? "" : dgvList.Rows[i].Cells["colCK"].Value.ToString();
                if (disable_flg == "1" && ck_value.Trim() == "")
                {
                    uIUtility.ChangeToDisableColor(dgvList.Rows[i]);
                }
            }
        }


        #endregion

        #region SubmitButton
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //get column values where MK not null or empty
            DataTable dt = uIUtility.SubmitChanges();

            //send to web service
            frmUsageChargeMasterController oController = new frmUsageChargeMasterController();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DataTable result = oController.Submit(dt, out uIUtility.MetaData);

                    //update data grid view
                    uIUtility.UpdateReturnedresults(result);
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
            //commit changes
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            #region close
            //if (uIUtility.checkSelectedRow())
            //{
            //    for (int i = 0; i < dgvList.Rows.Count; i++)
            //    {
            //        string originalvalue = dgvList.Rows[i].Cells["colMK"].Value == null ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString();
            //        string checkvalue = dgvList.Rows[i].Cells["colCK"].Value.ToString().Trim();

            //        if (String.IsNullOrEmpty(checkvalue) ? false : true)
            //        {
            //            switch (operation)
            //            {
            //                case "I":
            //                    uIUtility.InsertMode(operation, dgvList.Rows[i], true);
            //                    i++;
            //                    break;
            //                case "M":
            //                    if (originalvalue == "D" || String.IsNullOrEmpty(originalvalue == null ? null : originalvalue.Trim()))
            //                    {
            //                        dgvList.Rows[i].Cells["colMK"].Value = operation;
            //                    }
            //                    break;
            //                case "D":
            //                    if (originalvalue == "I" || originalvalue == "C")
            //                    {
            //                        uIUtility.dtList.Rows[i].Delete(); //delete row
            //                        i--;
            //                    }
            //                    else
            //                    {
            //                        dgvList.Rows[i].Cells["colMK"].Value = operation;
            //                    }
            //                    break;
            //                case "C":
            //                    uIUtility.CopyMode(operation, dgvList.Rows[i], true);
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //}

            ////if there is no row in datagrid view and insert button is clicked

            //if (dgvList.Rows.Count <= 0 && operation == "I")
            //{
            //    uIUtility.InsertInitialRow(operation);
            //}
            #endregion

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
                                if (originalvalue != "D" || String.IsNullOrEmpty(originalvalue == null ? null : originalvalue.Trim()) || originalvalue == "O" || originalvalue == "X")
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
                if ((operation != "I"))
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

        #region UnCheckAll
        private void BtnUnCheck_Click(object sender, EventArgs e)
        {
            uIUtility.CheckAll(false);
        }

        #endregion

        private void CboLimit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region EditControlShowingEvent
        private void DgvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            uIUtility.setComboAlignCenter(e);
        }
        #endregion
    }
}
