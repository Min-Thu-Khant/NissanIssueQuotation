using AmigoPaperWorkProcessSystem.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmigoPaperWorkProcessSystem._3A.Controllers;
using AmigoPaperWorkProcessSystem.Controllers;

namespace AmigoPaperWorkProcessSystem._3A.Forms
{
    public partial class frmMain : Form
    {
        #region Declare
        _3AController controller = new _3AController();
        #endregion

        #region Constructer
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region FormLoad
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //check directory for operation
            Utility.CheckAndCreateConfigFolder();

            //read user id and password from commandline
            Utility.GetUserIdAndPasswordFromCommandLine();

            int login_status = Utility.CheckLogIn(Utility.Id, Utility.Password).Result;

            try
            {
                //username and password valid
                if (login_status == 1)
                {
                    // execute batch process 3A
                    bool status = controller.ExecuteBatchProcessAsync().Result;
                    if (status)
                    {
                        MessageBox.Show(Messages.ImportBankDepositData.ImportSuccess);
                        Utility.ExitApp();
                    }
                    else
                    {
                        MessageBox.Show(Messages.General.ThereWasAnError);
                        Utility.ExitApp();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.DepositConfirmationMenu.UserNameAndPasswordDoNotMatch);
                    Utility.ExitApp();
                }
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                MessageBox.Show(Messages.General.ThereWasAnError);
                Utility.ExitApp();
            }
        }
        #endregion
    }
}
