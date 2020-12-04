using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Forms;
using AmigoPaperWorkProcessSystem.Forms.Jimugo;
using AmigoPaperWorkProcessSystem.Forms.Jimugo.Issue_Quotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool notrun;

            Mutex mutex = new Mutex(true, "AmigoPaperWorkProcessSystem", out notrun);

            if (!notrun)
            {
                //app is already running! Exiting the application  
                MessageBox.Show(AmigoPaperWorkProcessSystem.Core.Messages.General.ProgramIsAlreadyRunning, "Warning");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Utility.Id = "00001";
            Utility.Password = "password";
            Application.Run(new frmJimugo());

            //Application.Run(new frmMonthlySaleComparisonList());

        }
    }
}
