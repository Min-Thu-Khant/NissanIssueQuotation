using AmigoPapaerWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Forms.RegisterCompleteNotification;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo
{
    public partial class frmJimugo : Form
    {
        #region Constructor
        public frmJimugo()
        {
            InitializeComponent();
        }
        #endregion

        #region FormLoad
        private void FrmJimugo_Load(object sender, EventArgs e)
        {
            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;
        }
        #endregion

        #region EnableOrDisableControls
        protected void btnControls_Enable_Disable(bool blAction)
        {
            trvMenu.Enabled = blAction;
            btnLogin.Enabled = !blAction;
            txtID.Enabled = !blAction;
            txtPwd.Enabled = !blAction;
        }
        #endregion

        #region LoginButton
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text.Trim();
            string Password = txtPwd.Text.Trim();

            if (!CheckUtility.SearchConditionCheck(this,"ID", ID, false, Utility.DataType.HALF_ALPHA_NUMERIC, 6, 0))
            {
                return;
            }

            if (!CheckUtility.SearchConditionCheck(this,"Password", Password, false, Utility.DataType.HALF_ALPHA_NUMERIC, 20, 0))
            {
                return;
            }

            if (txtID.Text != "" && txtPwd.Text != "") //if both textboxes are not empty
            {
                int status = Utility.CheckLogIn(txtID.Text, txtPwd.Text).Result; //check credentials 

                if (status == 1) //success
                {
                    btnControls_Enable_Disable(true);
                    //get menu list from web service
                    GetMenu();
                }
                else //failed
                {
                    btnControls_Enable_Disable(false);
                    MetroMessageBox.Show(this, "\n" + JimugoMessages.E000WA001, "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                btnControls_Enable_Disable(false);
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.UserNameAndPasswordEmpty, "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CancelButton
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            txtPwd.Clear();
            txtID.Clear();
            trvMenu.Nodes.Clear();
            btnControls_Enable_Disable(false);
        }
        #endregion

        #region GetMenu
        private void GetMenu()
        {
            try
            {
                //get menu list from web service
                Controllers.frmJimugoMenuController jimugo = new Controllers.frmJimugoMenuController();
                DataTable result = jimugo.getTreeMenu();

                //each result
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    if (!trvMenu.Nodes.ContainsKey(result.Rows[i]["CATEGORY_ID"].ToString())) //if category is not already added to treeview yet
                    {
                        //assign parent node
                        TreeNode node = new TreeNode(result.Rows[i]["CATEGORY_NAME"].ToString());
                        node.Name = result.Rows[i]["CATEGORY_ID"].ToString();

                        //search program list with category ID
                        DataTable childNodes = getChildNodes(result, node.Name == "" ? "" : node.Name);

                        if (childNodes != null) //if program list is not empty for specific category
                        {
                            foreach (DataRow child in childNodes.Rows) // assign child nodes
                            {
                                TreeNode childNode = new TreeNode(child["PROGRAM_NAME"].ToString());
                                childNode.Name = child["PROGRAM_ID"].ToString().Trim();
                                node.Nodes.Add(childNode);
                            }
                        }
                        trvMenu.Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
            }
        }
        #endregion

        #region GetChildNodes
        private DataTable getChildNodes(DataTable data, string Key)
        {
            //search with category ID
            var query = from d in data.AsEnumerable()
                        where d.Field<string>("CATEGORY_ID") == Key
                        select d;
            DataTable boundTable;
            try
            {
                boundTable = query.CopyToDataTable<DataRow>();
            }
            catch (Exception ex)
            {
                boundTable = null;
                Utility.WriteErrorLog(ex.Message, ex, false);
            }

            return boundTable;
        }

        #endregion

        #region OpenForm
        private void openForm(string programID, string programName)
        {
            switch (programID)
            {
                case "CBN020"://3B
                    OpenBatchScreen(programID, programName);
                    break;
                case "CBN010"://3A
                    OpenBatchScreen(programID, programName);
                    break;
                case "CTN010"://31
                    Open31(programID, programName);
                    break;
                case "CTN040"://34
                    Open34(programID, programName);
                    break;
                case "CTN050"://35
                    Open35(programID, programName);
                    break;
                case "CTN060"://36
                    Open36(programID, programName);
                    break;
                case "CTN070"://37
                    Open37(programID, programName);
                    break;
                case "CMN010"://38
                    Open38(programID, programName);
                    break;
                case "CTS010"://company code list
                    OpenCompanCodeList(programID, programName);
                    break;
                case "CTS070": //usage reg list
                    OpenUsageRegistrationListScreen(programID, programName);
                    break;
                case "CTS080": //client certificate list
                    OpenClientCertificateScreen(programID, programName);
                    break;
                case "CMS020":
                    OpenUsageChargeMaster(programID, programName);
                    break;
                case "CTS020": // usage application list
                    OpenAppListScreen(programID, programName);
                    break;
                case "CMS010": // customer master maintence
                    OpenCustomerMasterMaintenance(programID, programName);
                    break;
                case "CTG010": // Monthly Sale Aggregation
                    OpenMonthlySaleAggregationList(programID, programName);
                    break;
                case "CTB010": // InvoiceList
                    OpenInvoiceList(programID, programName);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Payment
        private void Open31(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm31>().Count() == 1))
            {
                frm31 form31 = new frm31();
                form31.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open32(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm32>().Count() == 1))
            {
                frm32 form32 = new frm32();
                form32.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open33(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm33>().Count() == 1))
            {
                frm33 form33 = new frm33();
                form33.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open34(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm34>().Count() == 1))
            {
                frm34 form34 = new frm34();
                form34.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open35(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm35>().Count() == 1))
            {
                frm35 form35 = new frm35();
                form35.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open36(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm36>().Count() == 1))
            {
                frm36 form36 = new frm36();
                form36.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open37(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm37>().Count() == 1))
            {
                frm37 form37 = new frm37();
                form37.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        private void Open38(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frm38>().Count() == 1))
            {
                frm38 form38 = new frm38();
                form38.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }

        #endregion

        #region OpenBatchScreen
        private void OpenBatchScreen(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmCommonBatch>().Count() == 1))
            {
                frmCommonBatch batch = new frmCommonBatch(programID, programName);
                batch.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenCompanCodeList
        private void OpenCompanCodeList(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmCompanyCodeList>().Count() == 1))
            {
                frmCompanyCodeList form = new frmCompanyCodeList(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenUsageRegistrationListScreen
        private void OpenUsageRegistrationListScreen(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmUsageInfoRegistrationList>().Count() == 1))
            {
                frmUsageInfoRegistrationList form = new frmUsageInfoRegistrationList(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenAppListScreen
        private void OpenAppListScreen(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmUsageApplicationList>().Count() == 1))
            {
               frmUsageApplicationList IssueQuotation = new frmUsageApplicationList(programID, programName);
                IssueQuotation.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenClientCertificateScreen
        private void OpenClientCertificateScreen(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmClientCertificateList>().Count() == 1))
            {
                frmClientCertificateList form = new frmClientCertificateList(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenUsageChargeMaster
        private void OpenUsageChargeMaster(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmUsageChargeMaster>().Count() == 1))
            {
                frmUsageChargeMaster form = new frmUsageChargeMaster(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenCustomerMasterMaintenance
        private void OpenCustomerMasterMaintenance(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmCustomerMasterMaintenance>().Count() == 1))
            {
                frmCustomerMasterMaintenance form = new frmCustomerMasterMaintenance(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenMonthlySaleAggregationList
        private void OpenMonthlySaleAggregationList(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<FrmMonthlySaleAggregationList>().Count() == 1))
            {
                FrmMonthlySaleAggregationList form = new FrmMonthlySaleAggregationList(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region OpenInvoicedList
        private void OpenInvoiceList(string programID, string programName)
        {
            if (!(Application.OpenForms.OfType<frmInvoiceList>().Count() == 1))
            {
                frmInvoiceList form = new frmInvoiceList(programID, programName);
                form.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.ProcessAlreadyRunning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //need change after message list
            }
        }
        #endregion

        #region NodeDoubleClick
        private void TrvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            openForm(e.Node.Name, e.Node.Text);
        }
        #endregion
    }
}
