using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaySolutionsDesktop.Telas
{
    public partial class ImprimirHolerite : Form
    {
        public ImprimirHolerite()
        {
            InitializeComponent();
        }

        private void btnImpHol_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnImpHol.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnImpHol.Width - borderRadius * 2, btnImpHol.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnImpHol.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnImpHol.Region = new Region(buttonPath);
        }
    }
}
