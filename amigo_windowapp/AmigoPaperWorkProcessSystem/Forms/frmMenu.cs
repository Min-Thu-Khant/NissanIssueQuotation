using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AmigoPaperWorkProcessSystem.Forms
{
    public partial class frmMenu : MetroFramework.Forms.MetroForm
    {
        #region Constructor
        public frmMenu()
        {
            InitializeComponent();

            setOptimalDimentions();
        }

        #endregion

        #region FormLoad
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //theme
            this.Style = Properties.Settings.Default.Style;
            this.Theme = Properties.Settings.Default.Theme;

            // check the config folder
            Utility.CheckAndCreateConfigFolder();

            //get credentials from command line
            Utility.GetUserIdAndPasswordFromCommandLine();

            int status = Utility.CheckLogIn(Utility.Id, Utility.Password).Result;
            if (status==1)
            {
                btnControls_Enable_Disable(true);
                txtID.Text = Utility.Id;
                txtPwd.Text = Utility.Password;
            }
            else
            {
                btnControls_Enable_Disable(false);
                if (Utility.Id!=null)  //opened normally
                {
                    MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.UserNameAndPasswordDoNotMatch, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //check if 3A and 3B are running
            CheckBatchProcess();

        }
        #endregion

        #region CheckIfBatchProcessAreRunning
        private void CheckBatchProcess()
        {
            bool isRunning_3A = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3A");
            if (isRunning_3A)
            {
                //set status lable to run date
                lblStatus.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString() + " バッチ処理起動中";
                //show status lable
                prgStatus.Visible = true;
                lblStatus.Visible = true;
                //start timer to check process every 10 seconds
                tmr3A.Start();
            }

            bool isRunning_3B = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3B");
            if (isRunning_3B)
            {
                //set status lable to run date
                lblStatus.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString() + " バッチ処理起動中";
                //show status lable
                lblStatus.Visible = true;
                prgStatus.Visible = true;
                //start timer to check process every 10 seconds
                tmr3B.Start();
            }

           

        }
        #endregion

        #region setOptimalDimentions
        private void setOptimalDimentions()
        {
            this.Size = Properties.Settings.Default.DefaultDimentions;
        }
        #endregion

        #region ExitButton
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Utility.ExitApp();
        }
        #endregion

        #region EnableOrDisableControls
        protected void btnControls_Enable_Disable(bool blAction)
        {
            btn3_1.Enabled = blAction;
            btn3_4.Enabled = blAction;
            btn3_5.Enabled = blAction;
            btn3_6.Enabled = blAction;
            btn3_7.Enabled = blAction;
            btn3_8.Enabled = blAction;
            btn3_A.Enabled = blAction;
            btn3_B.Enabled = blAction;
            btnLogin.Enabled = !blAction;
            txtID.Enabled = !blAction;
            txtPwd.Enabled = !blAction;
        }
        #endregion

        #region LoginButton
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtPwd.Text != "")
            {
                int status = Utility.CheckLogIn(txtID.Text, txtPwd.Text).Result;

                if (status == 1)
                {
                    btnControls_Enable_Disable(true);
                }
                else
                {
                    btnControls_Enable_Disable(false);
                    MetroMessageBox.Show(this, "\n" + Messages.DepositConfirmationMenu.UserNameAndPasswordDoNotMatch, "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnControls_Enable_Disable(false);
        }
        #endregion

        #region 3_AButton

        #region 3_AButtonClick
        private void Btn3_A_Click(object sender, EventArgs e)
        {
            try
            {
                //check if batch process 3-A is already running
                bool isRunning = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3A");
                if (isRunning)
                {
                    MessageBox.Show(Messages.DepositConfirmationMenu.ProcessAlreadyRunning);
                }
                else
                {
                    //set status lable to run date
                    lblStatus.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString() + " バッチ処理起動中";
                    //show status lable
                    prgStatus.Visible = true;
                    lblStatus.Visible = true;
                    //start batch process exe
                    Process.Start(Application.StartupPath + "\\AmigoPaperWorkProcessSystem.3A.exe", Utility.Id + " " + Utility.Password);
                    //start timer to check process every 10 seconds
                    tmr3A.Start();
                }
                //disable the button
                btn3_A.Enabled = false;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoProgramFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 3_ATimer
        private void Tmr3A_Tick(object sender, EventArgs e)
        {
            bool isRunning = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3A");
            if (!isRunning)
            {
                //hide the status lable
                lblStatus.Text = "";
                lblStatus.Visible = false;
                prgStatus.Visible = false;
                //re-enable the button if logged in
                if (!btnLogin.Enabled)
                {
                    btn3_A.Enabled = true;
                }
                tmr3A.Stop();
            }
        }
        #endregion

        #endregion

        #region 3_Button

        #region 3B_ButtonClick
        private void Btn3_B_Click(object sender, EventArgs e)
        {
            try
            {
                //check if batch process 3-B is already running
                bool isRunning = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3B");
                if (isRunning)
                {
                    MessageBox.Show(Messages.DepositConfirmationMenu.ProcessAlreadyRunning);
                }
                else
                {
                    //set status lable to run date
                    lblStatus.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString() + " バッチ処理起動中";
                    //show status lable
                    lblStatus.Visible = true;
                    prgStatus.Visible = true;
                    //start batch process exe
                    Process.Start(Application.StartupPath + "\\AmigoPaperWorkProcessSystem.3B.exe", Utility.Id + " " + Utility.Password);
                    //start timer to check process every 10 seconds
                    tmr3B.Start();
                }
                //disable the button
                btn3_B.Enabled = false;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MetroMessageBox.Show(this, "\n" + Messages.General.NoProgramFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MetroMessageBox.Show(this, "\n" + Messages.General.ThereWasAnError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 3_BTimer
        private void Tmr3B_Tick(object sender, EventArgs e)
        {
            bool isRunning = Utility.CheckIfProcessIsRunning("AmigoPaperWorkProcessSystem.3B");
            if (!isRunning)
            {
                //hide the status lable
                lblStatus.Text = "";
                lblStatus.Visible = false;
                prgStatus.Visible = false;
                //re-enable the button if logged in
                if (!btnLogin.Enabled)
                {
                    btn3_B.Enabled = true;
                }
                tmr3B.Stop();
            }
        }
        #endregion

        #endregion

        #region 3_1Button
        private void Btn3_1_Click(object sender, EventArgs e)
        {
            frm31 frm = new frm31();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            this.BringToFront();
        }
        #endregion

        #region 3_4Button
        private void Btn3_4_Click(object sender, EventArgs e)
        {
            frm34 frm = new frm34();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            this.BringToFront();
        }
        #endregion

        #region 3_5Button
        private void Btn3_5_Click(object sender, EventArgs e)
        {
            frm35 frm = new frm35();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            this.BringToFront();
        }
        #endregion

        #region 3_6Button
        private void Btn3_6_Click(object sender, EventArgs e)
        {
            frm36 frm = new frm36();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            this.BringToFront();
        }
        #endregion

        #region 3_7Button
        private void Btn3_7_Click(object sender, EventArgs e)
        {
            frm37 frm = new frm37();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            this.BringToFront();
        }
        #endregion

        #region 38Button
        private void Btn3_8_Click(object sender, EventArgs e)
        {
            frm38 frm = new frm38();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            this.BringToFront();
        }
        #endregion

    }
}
