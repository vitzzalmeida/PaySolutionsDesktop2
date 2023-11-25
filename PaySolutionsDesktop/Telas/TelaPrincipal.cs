using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaySolutionsDesktop.Telas
{
    public partial class TelaPrincipal : Form
    {

        public TelaPrincipal()
        {
            InitializeComponent();
        }


        private void btnFunc_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnFunc.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnFunc.Width - borderRadius * 2, btnFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnFunc.Region = new Region(buttonPath);
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            GerenciarFuncionario gerenciarFuncionario = new GerenciarFuncionario();
            gerenciarFuncionario.Show();
        }

        private void btnHol_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnHol.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnHol.Width - borderRadius * 2, btnHol.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnHol.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnHol.Region = new Region(buttonPath);
        }

        private void btnContrato_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnContrato.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnContrato.Width - borderRadius * 2, btnContrato.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnContrato.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnContrato.Region = new Region(buttonPath);
        }

        private void btnRel_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnRel.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnRel.Width - borderRadius * 2, btnRel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnRel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnRel.Region = new Region(buttonPath);
        }

        private void btnSup_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnSup.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnSup.Width - borderRadius * 2, btnSup.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnSup.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnSup.Region = new Region(buttonPath);
        }

        private void btnHol_Click(object sender, EventArgs e)
        {
            GerarHolerite gerarHolerite = new GerarHolerite();
            gerarHolerite.Show();
        }
    }
}
