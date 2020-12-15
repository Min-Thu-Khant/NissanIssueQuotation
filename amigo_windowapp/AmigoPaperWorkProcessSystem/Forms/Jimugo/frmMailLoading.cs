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

namespace AmigoPaperWorkProcessSystem.Jimugo
{
    public partial class frmMailLoading : Form
    {
        public frmMailLoading(string strMessage) : this()
        {
            lblMailMsg.Text = strMessage;
        }

        public frmMailLoading()
        {
            InitializeComponent();
            lblMailMsg.Text = JimugoMessages.I000ZZ020;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMailLoading_Load(object sender, EventArgs e)
        {

        }
    }
}
