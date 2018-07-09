using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EvitandoAInjecaoDeSQL.Web.Models;
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
            var consulta = "SELECT COUNT(*) FROM Usuario WHERE Usuario = '" + usuario + "' AND Senha = '" + senha + "'";

            try
            {
                using (var conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();

                    using (SqlCommand comando = new SqlCommand(consulta, conexao))
                    {
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