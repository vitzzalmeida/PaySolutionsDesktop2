using PaySolutionsDesktop.Modelo;
using PaySolutionsDesktop.Telas;
using System.Threading;
using System.Windows.Forms;

namespace PaySolutionsDesktop
{
    public partial class Login : Form
    {
        Thread t1;
        public Login()
        {
            InitializeComponent();
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(btnLogin, new EventArgs());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ControleLogin controle = new ControleLogin();
            bool confirmado = controle.Acessar(txtUsuario.Text, txtSenha.Text);

            if (confirmado)
            {
                MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                t1 = new Thread(abrirJanela);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
            else
            {
                MessageBox.Show("Usuário ou senha estão incorretos.");
            }
        }

        private void abrirJanela(object obj)
        {
            Application.Run(new TelaPrincipal());
        }

    }
}
