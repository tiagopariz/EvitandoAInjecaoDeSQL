using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EvitandoAInjecaoDeSQL.Web.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string senha)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VendasDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            // Código com a vunerabilidade devido a concatenação
            //var consulta = "SELECT COUNT(*) FROM Usuario WHERE Usuario = '" + usuario + "' AND Senha = '" + senha + "'";

            // Forma mais segura, montando o SELECT que espera os parâmetros @usuario e @senha
            var consulta = "SELECT COUNT(*) " +
                                "FROM Usuario " +
                                "WHERE " +
                                    "Usuario = @usuario AND " +
                                    "Senha = @senha;";

            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    using (SqlCommand comando = new SqlCommand(consulta, conexao))
                    {
                        // Passando os parâmetros de SQL sem a necessidade de concatenar
                        comando.Parameters.Add(new SqlParameter("@usuario", usuario));
                        comando.Parameters.Add(new SqlParameter("@senha", senha));

                        var resultado = (int)comando.ExecuteScalar();
                        if (resultado > 0)
                            ViewBag.Mensagem = "Login efetuado com sucesso";
                        else
                            ViewBag.Mensagem = "Falha no login";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View();
        }
    }
}