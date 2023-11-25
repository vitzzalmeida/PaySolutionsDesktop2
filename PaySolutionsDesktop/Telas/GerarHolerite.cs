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
    public partial class GerarHolerite : Form
    {
        public GerarHolerite()
        {
            InitializeComponent();
        }

        private void btnGerHol_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnGerHol.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnGerHol.Width - borderRadius * 2, btnGerHol.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnGerHol.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnGerHol.Region = new Region(buttonPath);
        }

        private void btnGerHol_Click(object sender, EventArgs e)
        {
            this.Close();
            ImprimirHolerite imprimirHolerite = new ImprimirHolerite();
            imprimirHolerite.Show();
        }
    }
}
