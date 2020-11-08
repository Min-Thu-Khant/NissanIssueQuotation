using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmigoPaperWorkProcessSystem._3B.Controllers;
using AmigoPaperWorkProcessSystem.Core;

namespace AmigoPaperWorkProcessSystem._3B.Forms
{
    public partial class frmMain : Form
    {
        #region Declare
        _3BController controller = new _3BController();
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
            try
            {
                //read user id and password from commandline
                Utility.GetUserIdAndPasswordFromCommandLine();

                int login_status = Utility.CheckLogIn(Utility.Id, Utility.Password).Result;

                if (login_status == 1)
                {
                    int result = controller.ExecuteBatchProcess().Result;
                    if (result == 1)
                    {
                        MessageBox.Show(Messages.MatchToInvoice.MatchingSuccess);
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
            catch (Exception)
            {
                MessageBox.Show(Messages.General.ThereWasAnError);
                Utility.ExitApp();
            }
            
        }
        #endregion
    }
}
