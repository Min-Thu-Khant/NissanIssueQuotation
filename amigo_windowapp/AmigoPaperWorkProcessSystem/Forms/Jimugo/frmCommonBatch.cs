using AmigoPaperWorkProcessSystem.Core;
using MetroFramework;
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
    public partial class frmCommonBatch : Form
    {
        #region Declare
        private string programID = "";
        private string programName = "";
        private string program = "";
        #endregion

        #region Constructors
        public frmCommonBatch()
        {
            InitializeComponent();
        }

        public frmCommonBatch(string programID, string programName) :this()
        {
            this.programID = programID;
            this.programName = programName;
            //get program exe name
            this.program = getProgramEXE(programID);
        }
        #endregion

        #region FormLoad
        private void FrmCommonBatch_Load(object sender, EventArgs e)
        {
            //Theme
            this.pTitle.BackColor = Properties.Settings.Default.JimugoBgColor;
            this.lblMenu.ForeColor = Properties.Settings.Default.jimugoForeColor;

            //set title
            this.lblMenu.Text = this.programName;
        }
        #endregion

        #region RunButton
        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                //check if batch process is already running
                bool isRunning = Utility.CheckIfProcessIsRunning(program);
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
                    //start batch process exe
                    Process.Start(Application.StartupPath + "\\" + program + ".exe", Utility.Id + " " + Utility.Password);
                    //start timer to check process every 10 seconds
                    tmrBatch.Start();
                }
                //disable the button
                btnRun.Enabled = false;
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

        #region BatchTimer
        private void TmrBatch_Tick(object sender, EventArgs e)
        {
            bool isRunning = Utility.CheckIfProcessIsRunning(program);
            if (!isRunning)
            {
                //hide the status lable
                lblStatus.Text = "";
                lblStatus.Visible = false;
                //prgStatus.Visible = false;
                btnRun.Enabled = true;
                tmrBatch.Stop();
            }
        }
        #endregion

        #region getProgramEXE
        private string getProgramEXE(string programID)
        {
            switch (programID)
            {
                case "CBN010":
                    return "AmigoPaperWorkProcessSystem.3A";
                case "CBN020":
                    return "AmigoPaperWorkProcessSystem.3B";
                default:
                    return "";
            }
        }
        #endregion
    }
}
