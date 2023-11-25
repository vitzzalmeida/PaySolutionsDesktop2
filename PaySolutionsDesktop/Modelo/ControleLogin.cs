using PaySolutionsDesktop.DAO;
using System;

namespace PaySolutionsDesktop.Modelo
{
    public class ControleLogin
    {
        public bool Acessar(string usuario, string senha)
        {
            LoginDAO loginDAO = new LoginDAO();
            bool confirmado = loginDAO.VerificarLogin(usuario, senha);

            if (!string.IsNullOrEmpty(loginDAO.Mensagem))
            {
                Console.WriteLine(loginDAO.Mensagem);
            }

            return confirmado;
        }
    }
}
