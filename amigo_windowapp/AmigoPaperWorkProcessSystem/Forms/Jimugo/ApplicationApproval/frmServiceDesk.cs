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
    public partial class frmServiceDesk : Form
    {
        #region Declare
        private DataTable dtCurrent;
        private DataTable dtChange;
        #endregion

        #region Contructor
        public frmServiceDesk()
        {
            InitializeComponent();
        }

        public frmServiceDesk(DataTable dtCurrent, DataTable dtChange): this()
        {
            this.dtCurrent = dtCurrent;
            this.dtChange = dtChange;
        }

        #endregion

        #region BtnOK
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FormLoad
        private void FrmServiceDesk_Load(object sender, EventArgs e)
        {
            //theme
            this.dgvCurrent.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvCurrent.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.dgvChange.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.GridHeaderColor;
            this.dgvChange.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.GridHeaderFontColor;

            this.Font = Properties.Settings.Default.jimugoFont;

            this.dgvCurrent.DataSource = this.dtCurrent;
            this.dgvChange.DataSource = this.dtChange;
        }
        #endregion
    }
}
