using Maturidade_Online.Dominio.Usuario;
using Maturidade_Online.Models;
using Maturidade_Online.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maturidade_Online.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            if (Session["USUARIO_LOGADO_CHAVE"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(string email, string senha)
        {
            UsuarioServico usuarioServico = ServicoDeDependencia.MontarUsuarioServico();

            UsuarioEntidade usuario = usuarioServico.BuscarPorAutenticacao(email, senha);

            if (usuario != null)
            {
                ServicoDeAutenticacao.Autenticar(new UsuarioModel(
                    usuario.Email));
                return RedirectToAction("Index", "Home");
            }

            TempData["Email"] = "Usuário ou senha inválidos!";
            return RedirectToAction("Login");
        }


    }
}