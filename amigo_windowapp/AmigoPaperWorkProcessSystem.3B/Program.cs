using AmigoPaperWorkProcessSystem._3B.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem._3B
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

            Mutex mutex = new Mutex(true, "AmigoPaperWorkProcessSystem.3B", out notrun);

            if (!notrun)
            {
                //app is already running! Exiting the application  
                MessageBox.Show(AmigoPaperWorkProcessSystem.Core.Messages.General.ProgramIsAlreadyRunning, "Warning");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
