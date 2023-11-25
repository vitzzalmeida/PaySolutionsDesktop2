using MySql.Data.MySqlClient;
using PaySolutionsDesktop.DAO;
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
    public partial class GerenciarFuncionario : Form
    {
        public GerenciarFuncionario()
        {
            InitializeComponent();
        }

        private void btnAddFunc_Click(object sender, EventArgs e)
        {
            AddFuncionario addFuncionario = new AddFuncionario();
            addFuncionario.ShowDialog();

            CarregarDadosNaListView();
        }

        private void btnConsFunc_Click(object sender, EventArgs e)
        {
            if (lvlFunc.SelectedItems.Count > 0)
            {
                // Obtém o ID do funcionário associado ao item selecionado
                long idFuncionario = ObterIdFuncionarioPorItemSelecionado();

                // Abre a tela de consulta passando o ID do funcionário
                ConsultarFuncionario telaConsulta = new ConsultarFuncionario(idFuncionario);
                telaConsulta.Show();
            }
        }

        private void btnEditFunc_Click(object sender, EventArgs e)
        {
            if (lvlFunc.SelectedItems.Count > 0)
            {
                long idFuncionario = ObterIdFuncionarioPorItemSelecionado();

                if (idFuncionario != -1)
                {
                    // Abrir a tela de edição com o ID do funcionário a ser editado
                    EditarFuncionario telaEdicao = new EditarFuncionario(idFuncionario);
                    telaEdicao.ShowDialog();

                    // Atualizar a ListView após a edição (se necessário)
                    CarregarDadosNaListView();
                }
                else
                {
                    MessageBox.Show("Erro ao obter o ID do funcionário.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um item na lista antes de abrir a tela de edição.");
            }
        }

        private void btnDelFunc_Click(object sender, EventArgs e)
        {
            if (lvlFunc.SelectedItems.Count > 0)
            {
                // Obtém o índice selecionado
                int indexSelecionado = lvlFunc.SelectedItems[0].Index;

                // Obtém o ID do funcionário associado ao item selecionado
                // Supondo que o ID do funcionário esteja na primeira coluna (0)
                long idFuncionario = ObterIdFuncionarioPorItemSelecionado();

                // Pergunta ao usuário se ele tem certeza de que deseja excluir o funcionário
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir esse funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Se o usuário confirmar a exclusão, chama o método para deletar o funcionário
                    DeletarFuncionario(idFuncionario);
                }
            }
            else
            {
                MessageBox.Show("Selecione um item na lista antes de excluir o funcionário.");
            }
        }

        private void GerenciarFuncionario_Load(object sender, EventArgs e)
        {

            CarregarDadosNaListView();

        }

        private void GerenciarFuncionario_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnAddFunc.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnAddFunc.Width - borderRadius * 2, btnAddFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnAddFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnAddFunc.Region = new Region(buttonPath);
        }

        private void btnConsFunc_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnConsFunc.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnConsFunc.Width - borderRadius * 2, btnConsFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnConsFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnConsFunc.Region = new Region(buttonPath);
        }

        private void btnEditFunc_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnEditFunc.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnEditFunc.Width - borderRadius * 2, btnEditFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnEditFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnEditFunc.Region = new Region(buttonPath);
        }

        private void btnDelFunc_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            buttonPath.AddArc(btnDelFunc.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            buttonPath.AddArc(btnDelFunc.Width - borderRadius * 2, btnDelFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            buttonPath.AddArc(0, btnEditFunc.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            btnDelFunc.Region = new Region(buttonPath);
        }


        private void CarregarDadosNaListView()
        {
            // Limpar a ListView antes de carregar os dados
            lvlFunc.Items.Clear();

            // Conectar ao banco de dados
            using (Conexao con = new Conexao())
            {
                try
                {
                    // Comando SQL para selecionar os dados da tabela no banco de dados
                    string query = "SELECT id, nome, cpf FROM funcionario";

                    // Criar o comando SQL e a conexão
                    using (MySqlCommand cmd = new MySqlCommand(query, con.Conectar()))
                    {
                        // Executar o comando e obter o leitor de dados
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Verificar se existem linhas no resultado
                            while (reader.Read())
                            {
                                // Criar um novo item da ListView
                                ListViewItem item = new ListViewItem(reader["id"].ToString());

                                item.Tag = reader["id"].ToString();

                                item.SubItems.Add(reader["nome"].ToString());

                                // Adicionar subitens com outras informações
                                item.SubItems.Add(reader["cpf"].ToString());

                                // Adicionar item à ListView
                                lvlFunc.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }

        private void DeletarFuncionario(long idFuncionario)
        {
            using (Conexao con = new Conexao())
            {
                try
                {
                    // Desativa a verificação de chave estrangeira temporariamente
                    DesativarVerificacaoChaveEstrangeira(con);

                    // Comando SQL para excluir registros associados na tabela 'banco'
                    string deleteBancoQuery = "DELETE FROM banco WHERE id_funcionario = @idFuncionario";

                    // Comando SQL para excluir registros associados na tabela 'endereco'
                    string deleteEnderecoQuery = "DELETE FROM endereco WHERE id_funcionario = @idFuncionario";

                    // Comando SQL para excluir o registro na tabela 'funcionario'
                    string deleteFuncionarioQuery = "DELETE FROM funcionario WHERE id = @idFuncionario";

                    using (MySqlCommand cmdBanco = new MySqlCommand(deleteBancoQuery, con.Conectar()))
                    using (MySqlCommand cmdEndereco = new MySqlCommand(deleteEnderecoQuery, con.Conectar()))
                    using (MySqlCommand cmdFuncionario = new MySqlCommand(deleteFuncionarioQuery, con.Conectar()))
                    {
                        // Adicione o parâmetro com o valor do ID do funcionário
                        cmdBanco.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        cmdEndereco.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                        cmdFuncionario.Parameters.AddWithValue("@idFuncionario", idFuncionario);

                        // Executa os comandos SQL na ordem correta
                        cmdBanco.ExecuteNonQuery();
                        cmdEndereco.ExecuteNonQuery();
                        cmdFuncionario.ExecuteNonQuery();

                        MessageBox.Show("Funcionário excluído com sucesso!");
                        CarregarDadosNaListView();  // Atualiza a ListView após a exclusão
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir funcionário: " + ex.Message);
                }
                finally
                {
                    // Ativa a verificação de chave estrangeira de volta
                    AtivarVerificacaoChaveEstrangeira(con);
                }
            }
        }

        private void DesativarVerificacaoChaveEstrangeira(Conexao con)
        {
            using (MySqlCommand cmd = new MySqlCommand("SET foreign_key_checks = 0;", con.Conectar()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void AtivarVerificacaoChaveEstrangeira(Conexao con)
        {
            using (MySqlCommand cmd = new MySqlCommand("SET foreign_key_checks = 1;", con.Conectar()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private long ObterIdFuncionarioPorItemSelecionado()
        {
            if (lvlFunc.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = lvlFunc.SelectedItems[0];

                // Obter o ID do Tag do item selecionado
                string idString = itemSelecionado.Tag.ToString();

                // Converte a string para long
                if (long.TryParse(idString, out long idFuncionario))
                {
                    return idFuncionario;
                }
            }

            // Se não houver item selecionado ou erro na conversão, retorna -1 ou trata conforme necessário
            return -1;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Limpe os itens existentes na ListView
            lvlFunc.Items.Clear();

            // Obtenha o texto da TextBox
            string filtro = txtBuscar.Text;

            using (Conexao con = new Conexao())
            {
                try
                {
                    // Consulta SQL para buscar funcionários pelo nome
                    string query = "SELECT id, nome, cpf FROM funcionario WHERE nome LIKE @filtro";

                    using (MySqlCommand cmd = new MySqlCommand(query, con.Conectar()))
                    {
                        // Adicione o parâmetro do filtro
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Itere sobre os resultados da consulta e adicione à ListView
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["id"].ToString());
                                item.SubItems.Add(reader["nome"].ToString());
                                item.SubItems.Add(reader["cpf"].ToString());
                                lvlFunc.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar funcionários: " + ex.Message);
                }
            }
        }
    }
}
