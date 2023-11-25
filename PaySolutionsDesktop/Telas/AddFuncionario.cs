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
    public partial class AddFuncionario : Form
    {
        public AddFuncionario()
        {
            InitializeComponent();
        }

        private void btnAdd_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnAdd.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnAdd.Width - borderRadius * 2, btnAdd.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnAdd.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnAdd.Region = new Region(buttonPath);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdicionarDadosNoBanco();
        }

        private void AdicionarDadosNoBanco()
        {
            using (Conexao con = new Conexao())
            {
                if (txtNomeFuncionario.Text != "" && txtCpf.Text != "" && txtTelefone.Text != "" && txtRg.Text != "" && txtDataNascimento.Text != "" &&
                    cmbEstadoCivil.Text != "" && txtPis.Text != "" && txtCarteiraTrabalho.Text != "" && cmbSexo.Text != "" && txtCnh.Text != "" &&
                    txtAdmissao.Text != "" && txtNacionalidade.Text != "" && txtEndereco.Text != "" && txtBairro.Text != "" && cmbUf.Text != "" &&
                    txtCidade.Text != "" && txtCep.Text != "" && txtPais.Text != "" && txtBanco.Text != "" && txtAgencia.Text != "" && txtConta.Text != "" && txtEmail.Text != "")
                {
                    try
                    {
                        MySqlCommand cmdCargo = new MySqlCommand(
                        "INSERT INTO cargo(nome_cargo, admissao) VALUES (@nome_cargo, @admissao)", con.Conectar());

                        cmdCargo.Parameters.AddWithValue("@nome_cargo", cmbCargo.Text);
                        cmdCargo.Parameters.AddWithValue("@admissao", DateTime.ParseExact(txtAdmissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        cmdCargo.ExecuteNonQuery();

                        long idCargo = cmdCargo.LastInsertedId;


                        // Inserir dados na tabela 'funcionario'
                        MySqlCommand cmdFuncionario = new MySqlCommand(
                            "INSERT INTO funcionario(nome, cpf, rg, telefone, data_nascimento, estado_civil, sexo, cnh, carteira_de_trabalho, pis, nacionalidade, email, salario, id_cargo)" +
                            " VALUES (@nome, @cpf, @rg, @telefone, @data_nascimento, @estado_civil, @sexo, @cnh, @carteira_de_trabalho, @pis, @nacionalidade, @email, @salario, @id_cargo)",
                            con.Conectar());

                        cmdFuncionario.Parameters.AddWithValue("@nome", txtNomeFuncionario.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@cpf", txtCpf.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@rg", txtRg.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                        DateTime dataNascimento = DateTime.ParseExact(txtDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        cmdFuncionario.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                        cmdFuncionario.Parameters.AddWithValue("@estado_civil", cmbEstadoCivil.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@sexo", cmbSexo.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@cnh", txtCnh.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@carteira_de_trabalho", txtCarteiraTrabalho.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@pis", txtPis.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@email", txtEmail.Text.ToUpper());
                        cmdFuncionario.Parameters.AddWithValue("@salario", txtSalario.Text.ToLower());
                        cmdFuncionario.Parameters.AddWithValue("@id_cargo", idCargo);
                        cmdFuncionario.ExecuteNonQuery();

                        // Recuperar o ID do último funcionário inserido
                        long idFuncionario = cmdFuncionario.LastInsertedId;

                        // Inserir dados na tabela 'endereco'
                        MySqlCommand cmdEndereco = new MySqlCommand(
                            "INSERT INTO endereco(id_funcionario, endereco, uf, cidade, bairro, cep, pais) VALUES (@id_funcionario, @endereco, @uf, @cidade, @bairro, @cep, @pais)",
                            con.Conectar());

                        cmdEndereco.Parameters.AddWithValue("@id_funcionario", idFuncionario);
                        cmdEndereco.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                        cmdEndereco.Parameters.AddWithValue("@uf", cmbUf.Text.ToUpper());
                        cmdEndereco.Parameters.AddWithValue("@cidade", txtCidade.Text.ToUpper());
                        cmdEndereco.Parameters.AddWithValue("@bairro", txtBairro.Text.ToUpper());
                        cmdEndereco.Parameters.AddWithValue("@cep", txtCep.Text.ToUpper());
                        cmdEndereco.Parameters.AddWithValue("@pais", txtPais.Text.ToLower());
                        cmdEndereco.ExecuteNonQuery();

                        // Inserir dados na tabela 'banco'
                        MySqlCommand cmdBanco = new MySqlCommand(
                            "INSERT INTO banco(id_funcionario, nome_banco, agencia, numero_conta) VALUES (@id_funcionario, @nome_banco, @agencia, @numero_conta)",
                            con.Conectar());

                        cmdBanco.Parameters.AddWithValue("@id_funcionario", idFuncionario);
                        cmdBanco.Parameters.AddWithValue("@nome_banco", txtBanco.Text.ToUpper());
                        cmdBanco.Parameters.AddWithValue("@agencia", txtAgencia.Text.ToUpper());
                        cmdBanco.Parameters.AddWithValue("@numero_conta", txtConta.Text.ToLower());
                        cmdBanco.ExecuteNonQuery();

                        MessageBox.Show("Registro concluído com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                    finally
                    {
                        con.Dispose();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Informe todos os dados requeridos");
                }
            }
        }
    }
}
