using MySql.Data.MySqlClient;
using PaySolutionsDesktop.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaySolutionsDesktop.Telas
{
    public partial class ConsultarFuncionario : Form
    {
        private long idFuncionario;

        // Construtor que aceita o ID do funcionário como parâmetro
        public ConsultarFuncionario(long idFuncionario)
        {
            InitializeComponent();
            this.idFuncionario = idFuncionario;

            // Chame o método de consulta ao carregar o formulário
            CarregarDadosDoFuncionario();
        }

        private void CarregarDadosDoFuncionario()
        {
            using (Conexao con = new Conexao())
            {
                try
                {
                    // Consulta para obter os dados do funcionário com base no ID
                    string query = "SELECT f.*, e.*, b.*, c.nome_cargo, c.admissao " +
                                    "FROM funcionario f " +
                                    "JOIN endereco e ON f.id = e.id_funcionario " +
                                    "JOIN banco b ON f.id = b.id_funcionario " +
                                    "JOIN cargo c ON f.id_cargo = c.id " +
                                    "WHERE f.id = @idFuncionario";

                    using (MySqlCommand cmd = new MySqlCommand(query, con.Conectar()))
                    {

                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preencha as Labels com os dados recuperados do banco de dados
                                lblNome.Text = reader["nome"].ToString();
                                lblCpf.Text = reader["cpf"].ToString();
                                lblRg.Text = reader["rg"].ToString();
                                lblTelefone.Text = reader["telefone"].ToString();
                                DateTime dataNascimento = Convert.ToDateTime(reader["data_nascimento"]);
                                lblDataNascimento.Text = dataNascimento.ToString("dd/MM/yyyy");
                                lblEstadoCivil.Text = reader["estado_civil"].ToString();
                                lblSexo.Text = reader["sexo"].ToString();
                                lblCnh.Text = reader["cnh"].ToString();
                                lblCarteiraTrabalho.Text = reader["carteira_de_trabalho"].ToString();
                                lblPis.Text = reader["pis"].ToString();
                                lblNacionalidade.Text = reader["nacionalidade"].ToString();
                                lblEmail.Text = reader["email"].ToString();
                                lblSalario.Text = reader["salario"].ToString();
                                lblEndereco.Text = reader["endereco"].ToString();
                                lblUf.Text = reader["uf"].ToString();
                                lblCidade.Text = reader["cidade"].ToString();
                                lblBairro.Text = reader["bairro"].ToString();
                                lblCep.Text = reader["cep"].ToString();
                                lblPais.Text = reader["pais"].ToString();
                                lblBanco.Text = reader["nome_banco"].ToString();
                                lblAgencia.Text = reader["agencia"].ToString();
                                lblConta.Text = reader["numero_conta"].ToString();
                                lblCargo.Text = reader["nome_cargo"].ToString();
                                DateTime admissao = Convert.ToDateTime(reader["admissao"]);
                                lblAdmissao.Text = admissao.ToString("dd/MM/yyyy");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


    }
}
