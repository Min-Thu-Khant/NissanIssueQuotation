using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Forms.Jimugo.ApplicationApproval
{
    public partial class frmErrrorNotification : Form
    {
        #region Declare
        private DataTable dtCurrent;
        private DataTable dtChange;
        #endregion

        #region Constructor
        public frmErrrorNotification()
        {
            InitializeComponent();
        }

        public frmErrrorNotification(DataTable dtCurrent, DataTable dtChange) : this()
        {
            this.dtCurrent = dtCurrent;
            this.dtChange = dtChange;
        }
        #endregion

        #region FormLoad
        private void FrmErrrorNotification_Load(object sender, EventArgs e)
        {
            //theme
            this.dgvCurrent.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvCurrent.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.dgvChange.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvChange.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.dgvCurrent.DataSource = this.dtCurrent;
            this.dgvChange.DataSource = this.dtChange;
        }
        #endregion

        #region BtnOK
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
