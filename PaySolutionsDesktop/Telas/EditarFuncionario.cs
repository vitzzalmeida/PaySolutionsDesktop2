using MySql.Data.MySqlClient;
using PaySolutionsDesktop.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaySolutionsDesktop.Telas
{
    public partial class EditarFuncionario : Form
    {
        private long idFuncionario;

        public EditarFuncionario(long idFuncionario)
        {
            InitializeComponent();
            this.idFuncionario = idFuncionario;

            // Carregue os dados do funcionário para edição
            CarregarDadosParaEdicao();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AtualizarDadosNoBanco();
        }


        private void CarregarDadosParaEdicao()
        {
            using (Conexao con = new Conexao())
            {
                try
                {
                    // Comando SQL para obter os dados do funcionário com base no ID
                    string query = "SELECT *" +
                                    "FROM funcionario f " +
                                    "JOIN endereco e ON f.id = e.id_funcionario " +
                                    "JOIN banco b ON f.id = b.id_funcionario " +
                                    "WHERE f.id = @idFuncionario";

                    using (MySqlCommand cmd = new MySqlCommand(query, con.Conectar()))
                    {
                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preencha os TextBoxes com os dados recuperados do banco de dados
                                txtNomeFuncionario.Text = reader["nome"].ToString();
                                txtCpf.Text = reader["cpf"].ToString();
                                txtRg.Text = reader["rg"].ToString();
                                txtTelefone.Text = reader["telefone"].ToString();
                                DateTime dataNascimento = Convert.ToDateTime(reader["data_nascimento"]);
                                txtDataNascimento.Text = dataNascimento.ToString("dd/MM/yyyy");
                                cmbEstadoCivil.Text = reader["estado_civil"].ToString();
                                cmbSexo.Text = reader["sexo"].ToString();
                                txtCnh.Text = reader["cnh"].ToString();
                                txtCarteiraTrabalho.Text = reader["carteira_de_trabalho"].ToString();
                                txtPis.Text = reader["pis"].ToString();
                                txtNacionalidade.Text = reader["nacionalidade"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtSalario.Text = reader["salario"].ToString();

                                // Dados de Endereço
                                txtEndereco.Text = reader["endereco"].ToString();
                                cmbUf.Text = reader["uf"].ToString();
                                txtCidade.Text = reader["cidade"].ToString();
                                txtBairro.Text = reader["bairro"].ToString();
                                txtCep.Text = reader["cep"].ToString();
                                txtPais.Text = reader["pais"].ToString();

                                // Dados do Banco
                                txtBanco.Text = reader["nome_banco"].ToString();
                                txtAgencia.Text = reader["agencia"].ToString();
                                txtConta.Text = reader["numero_conta"].ToString();

                                

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados para edição: " + ex.Message);
                    this.Close();  // Fecha a tela de edição em caso de erro
                }
            }
        }

        private void AtualizarDadosNoBanco()
        {
            using (Conexao con = new Conexao())
            {
                try
                {
                    // Comando SQL para atualizar os dados do funcionário, banco e endereço no banco de dados
                    string query = "UPDATE funcionario f " +
                                   "JOIN endereco e ON f.id = e.id_funcionario " +
                                   "JOIN banco b ON f.id = b.id_funcionario " +
                                   "SET f.nome = @nome, f.cpf = @cpf, f.rg = @rg, f.telefone = @telefone, " +
                                   "f.data_nascimento = @data_nascimento, f.estado_civil = @estado_civil, " +
                                   "f.sexo = @sexo, f.cnh = @cnh, f.carteira_de_trabalho = @carteira_de_trabalho, " +
                                   "f.pis = @pis, f.nacionalidade = @nacionalidade, f.email = @email, " +
                                   "f.salario = @salario, e.endereco = @endereco, e.uf = @uf, " +
                                   "e.cidade = @cidade, e.bairro = @bairro, e.cep = @cep, e.pais = @pais, " +
                                   "b.nome_banco = @nome_banco, b.agencia = @agencia, b.numero_conta = @numero_conta " +
                                   "WHERE f.id = @idFuncionario";

                    using (MySqlCommand cmd = new MySqlCommand(query, con.Conectar()))
                    {
                        // Adicione os parâmetros com os valores dos TextBoxes
                        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        cmd.Parameters.AddWithValue("@nome", txtNomeFuncionario.Text);
                        cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                        cmd.Parameters.AddWithValue("@rg", txtRg.Text);
                        cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                        DateTime dataNascimento = DateTime.ParseExact(txtDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@estado_civil", cmbEstadoCivil.Text);
                        cmd.Parameters.AddWithValue("@sexo", cmbSexo.Text);
                        cmd.Parameters.AddWithValue("@cnh", txtCnh.Text);
                        cmd.Parameters.AddWithValue("@carteira_de_trabalho", txtCarteiraTrabalho.Text);
                        cmd.Parameters.AddWithValue("@pis", txtPis.Text);
                        cmd.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@salario", txtSalario.Text);

                        // Parâmetros de Endereço
                        cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                        cmd.Parameters.AddWithValue("@uf", cmbUf.Text);
                        cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                        cmd.Parameters.AddWithValue("@bairro", txtBairro.Text);
                        cmd.Parameters.AddWithValue("@cep", txtCep.Text);
                        cmd.Parameters.AddWithValue("@pais", txtPais.Text);

                        // Parâmetros do Banco
                        cmd.Parameters.AddWithValue("@nome_banco", txtBanco.Text);
                        cmd.Parameters.AddWithValue("@agencia", txtAgencia.Text);
                        cmd.Parameters.AddWithValue("@numero_conta", txtConta.Text);

                        // Executa o comando SQL
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Alterações salvas com sucesso!");
                        this.Close();  // Fecha a tela de edição após salvar
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar alterações: " + ex.Message);
                }
            }
        }

    }
}
