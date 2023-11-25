using MySql.Data.MySqlClient;
using System;

namespace PaySolutionsDesktop.DAO
{
    public class Conexao : IDisposable
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=paysolutions2;Uid=root;Pwd=VouEndoidar*;");

        public MySqlConnection Conectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }

        
    }
}
