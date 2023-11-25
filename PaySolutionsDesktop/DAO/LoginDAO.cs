using MySql.Data.MySqlClient;
using System;

namespace PaySolutionsDesktop.DAO
{
    class LoginDAO
    {
        private string mensagem = "";

        public bool VerificarLogin(string usuario, string senha)
        {
            bool confirmado = false;

            using (Conexao con = new Conexao())
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM logins WHERE usuario = @usuario AND senha = @senha";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                try
                {
                    cmd.Connection = con.Conectar();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        confirmado = true;
                    }
                }
                catch (MySqlException ex)
                {
                    mensagem = "Erro com o banco de dados: " + ex.Message;
                    Console.WriteLine(mensagem);
                }
            }

            return confirmado;
        }

        public string Mensagem
        {
            get { return mensagem; }
        }
    }
}
