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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frmClientCertificateList : Form
    {
        #region Declare
        private UIUtility uIUtility;
        private string programID = "";
        private string programName = "";

        private string distributionStatus;

        private string fy;
        private string company_no_box;
        private string client_certificate_no;

        private List<Validate> Insertable = new List<Validate>{
            new Validate{ Name = "colFY", Type = Utility.DataType.HALF_NUMBER, Edit=true, Require = true, Max = 4  },
            new Validate{ Name = "colCLIENT_CERTIFICATE_NO", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 20},
            new Validate{ Name = "colPASSWORD", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 80 },
            new Validate{ Name = "colEXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = true, Max = 160 ,},
            new Validate{ Name = "colCOMPANY_NO_BOX", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 10}
        };

        private List<Validate> Copyable = new List<Validate>{
            new Validate{ Name = "colFY", Type = Utility.DataType.HALF_NUMBER, Edit = true, Require = true, Initial="copy", Max = 4, },
            new Validate{ Name = "colCLIENT_CERTIFICATE_NO", Type = Utility.DataType.TEXT, Edit = true, Require = true, Initial="copy", Max = 20},
            new Validate{ Name = "colPASSWORD", Type = Utility.DataType.TEXT, Edit = true, Require = true, Initial="copy", Max = 80 },
            new Validate{ Name = "colEXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = true, Initial="copy", Max = 160 ,},
            new Validate{ Name = "colCOMPANY_NO_BOX", Type = Utility.DataType.TEXT, Edit = true, Require = true, Initial="copy", Max = 10}
        };

        private List<Validate> Modifiable = new List<Validate>{
            new Validate{ Name = "colPASSWORD", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 80 },
            new Validate{ Name = "colEXPIRATION_DATE", Type = Utility.DataType.TIMESTAMP, Edit=true, Require = true, Max = 160 },
            new Validate{ Name = "colCOMPANY_NO_BOX", Type = Utility.DataType.TEXT, Edit = true, Require = true, Max = 10}
        };

        private string[] dummyColumns = {
            "NO",
            "CK",
            "MK",
            "FY",
            "CLIENT_CERTIFICATE_NO",
            "PASSWORD",
            "EXPIRATION_DATE",
            "COMPANY_NO_BOX",
            "COMPANY_NAME",
            "CLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS",
            "DISTRIBUTION_DATE",
            "UPDATED_AT",
            "UPDATED_BY",
            "UPDATE_MESSAGE",
            "UPDATED_AT_RAW",
            "ROW_ID"
        };

        #endregion

        #region Constructors
        public frmClientCertificateList()
        {
            InitializeComponent();
            this.distributionStatus = "全て";
        }

        public frmClientCertificateList(string YEAR,string COMPANY_NO_BOX,string programID,string programName):this()
        {
            this.fy = YEAR;
            txtFY.Text = YEAR;
            this.company_no_box = COMPANY_NO_BOX;
            txtCompanyNoBox.Text = COMPANY_NO_BOX;
            this.programID = programID;
            this.programName = programName;
        }

        public frmClientCertificateList(string programID, string programName) : this()
        {
            this.programID = programID;
            this.programName = programName;
        }
        #endregion

        #region FormLoad
        private void FrmClientCertificateList_Load(object sender, EventArgs e)
        {
            //set title
            lblMenu.Text = programName;
            this.Text = "["+ programID +"] " + programName;

            uIUtility = new UIUtility(dgvList, Insertable, Copyable, Modifiable, dummyColumns);
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);

            uIUtility.ResetCheckBoxSize();//adjust checkbox sizes
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

            rdoAll.Checked = true;

            #region FromRegisterCompleteNotificationScreen

            if(fy != null)
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
                    fy = txtFY.Text;
                    company_no_box = txtCompanyNoBox.Text;
                    client_certificate_no = txtClientCertificateNo.Text;

                    if (rdoAll.Checked)
                    {
                        distributionStatus = rdoAll.Text;
                    }
                    if (rdoProcessing.Checked)
                    {
                        distributionStatus = rdoProcessing.Text;
                    }
                    if (optComplete.Checked)
                    {
                        distributionStatus = optComplete.Text;
                    }

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
                fy = txtFY.Text;
                company_no_box = txtCompanyNoBox.Text;
                client_certificate_no = txtClientCertificateNo.Text;

                if (rdoAll.Checked)
                {
                    distributionStatus = rdoAll.Text;
                }
                if (rdoProcessing.Checked)
                {
                    distributionStatus = rdoProcessing.Text;
                }
                if (optComplete.Checked)
                {
                    distributionStatus = optComplete.Text;
                }

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
                if (CheckUtility.SearchConditionCheck(this, lblFY.Text, txtFY.Text, false, Utility.DataType.HALF_NUMBER, 4, 0) &&
                    CheckUtility.SearchConditionCheck(this, lblCompanyNoBox.Text, txtCompanyNoBox.Text, false, Utility.DataType.HALF_ALPHA_NUMERIC, 10, 0) &&
                    CheckUtility.SearchConditionCheck(this, lblClientCertificateNo.Text, txtClientCertificateNo.Text, false, Utility.DataType.HALF_ALPHA_NUMERIC, 7, 0)
                    )
                {

                    frmClientCertificateListController oController = new frmClientCertificateListController();

                    DataTable dt = oController.GetClientCertificateList(fy, company_no_box, client_certificate_no, distributionStatus, uIUtility.MetaData.Offset, uIUtility.MetaData.Limit, out uIUtility.MetaData);
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

        #region PopulateDropdowns
        private void PopulateDropdowns()
        {
            uIUtility.DisplayCountCombo(cboLimit); //search filter
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
            txtFY.Text = "";
            txtCompanyNoBox.Text = "";
            txtClientCertificateNo.Text = "";
            cboLimit.SelectedIndex = 0;
            
        }
        #endregion

        #region FormSizeChanged
        private void FrmClientCertificateList_SizeChanged(object sender, EventArgs e)
        {
            //uIUtility.ResetCheckBoxSize();
        }
        #endregion

        #region SetDefaultColumnWidths
        private void SetDefaultColumnWidths()
        {
            uIUtility.ResetCheckBoxSize();
            dgvList.Columns["colFY"].Width = 50;
            dgvList.Columns["colCLIENT_CERTIFICATE_NO"].Width = 150;
            dgvList.Columns["colPASSWORD"].Width = 100;
            dgvList.Columns["colEXPIRATION_DATE"].Width = 145;
            dgvList.Columns["colCOMPANY_NO_BOX"].Width = 110;
            dgvList.Columns["colCOMPANY_NAME"].Width = 100;
            dgvList.Columns["colCLIENT_CERTIFICATE_SEND_EMAIL_ADDRESS"].Width = 200;
            dgvList.Columns["colDISTRIBUTION_DATE"].Width = 145;
            dgvList.Columns["colUPDATED_AT"].Width = 145;
            dgvList.Columns["colUPDATED_BY"].Width = 120;
            dgvList.Columns["colUPDATE_MESSAGE"].Width = 350;
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

        #region CancelButton
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            uIUtility.CancelChanges();
            
        }

        #endregion

        #region DataSourceChanged_HandlePaginationButtons
        private void DgvList_DataSourceChanged(object sender, EventArgs e)
        {
            uIUtility.CheckPagination(btnFirst, btnPrev, btnNext, btnLast, lblcurrentPage.Text, lblTotalPages.Text);
        }

        #endregion

        #region SubmitButton
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //get column values where MK not null or empty
            DataTable dt = uIUtility.SubmitChanges();
            
            try
            {
                //send to web service
                frmClientCertificateListController oController = new frmClientCertificateListController();

                if (dt.Rows.Count > 0)
                {
                    DataTable result = oController.Submit(dt, out uIUtility.MetaData);

                    //update data grid view
                    uIUtility.UpdateReturnedresults(result);
                }
                
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
                uIUtility.MetaData.Offset = (int.Parse(lblTotalPages.Text.Replace("Pages", "").Trim()) - 1) * int.Parse(cboLimit.SelectedValue.ToString());
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

        #region SendMail
        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = uIUtility.GetCheckedValuesForMail();
                if (dt.Rows.Count > 0)
                {
                    var confirmResult = MetroMessageBox.Show(this, "\n" + JimugoMessages.I000ZZ019, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.OK)
                    {
                        //Show mail progress message
                        Thread mailthread = new Thread(new ThreadStart(ShowMailLoading));
                        mailthread.Start();
                        //call mail send method from web service
                        frmClientCertificateListController clientCertificateList = new frmClientCertificateListController();
                        DataTable result = clientCertificateList.SendMail(dt);

                        //update data grid view
                        uIUtility.UpdateReturnedresults(result);

                        //close mail dialog
                        mailthread.Abort();
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }
        }
        #endregion

        #region ShowMailLoading
        private void ShowMailLoading()
        {
            Application.Run(new frmMailLoading());
        }
        #endregion
    }
}

