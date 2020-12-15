using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.UserControls
{
    public partial class DisplayItemLabel : UserControl
    {
        public DisplayItemLabel()
        {
            InitializeComponent();
        }

        private string labelValue;

        public string LabelText
        {
            get { return labelValue; }
            set { labelValue = value; lbl.Text = value; }
        }

    }
}
