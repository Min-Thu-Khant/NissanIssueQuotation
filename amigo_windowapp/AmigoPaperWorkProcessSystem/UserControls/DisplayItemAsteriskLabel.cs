using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.UserControls
{
    class DisplayItemAsteriskLabel : System.Windows.Forms.Label
    {
        protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                     Color.Gray, 0, ButtonBorderStyle.Solid,
                                     Color.Gray, 1, ButtonBorderStyle.Solid,
                                     Color.Gray, 1, ButtonBorderStyle.Solid,
                                     Color.Gray, 1, ButtonBorderStyle.Solid);
    }
}
}