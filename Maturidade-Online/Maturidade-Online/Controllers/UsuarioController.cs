using AutoMapper;
using Maturidade_Online.Dominio;
using Maturidade_Online.Models;
using Maturidade_Online.Repositorio;
using Maturidade_Online.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Maturidade_Online.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            if (Session["USUARIO_LOGADO_CHAVE"] != null)
            {
                return RedirectToAction("Listar", "Projeto");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new ContextoDeDados())
                {
                    UsuarioServico usuarioServico = ServicoDeDependencia.MontarUsuarioServico(contexto);

                    var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);

                    Usuario usuarioEncontrado = usuarioServico.BuscarPorAutenticacao(usuario);

                    if (usuarioEncontrado != null)
                    {
                        ServicoDeAutenticacao.Autenticar(new UsuarioLogadoModel(usuarioEncontrado.Id,usuario.Email, usuarioEncontrado.Permissao));
                        return RedirectToAction("Listar", "Projeto");
                    }
                    
                }
                ViewData["MensagemErro"] = "Usuário ou Senha inválido.";
            }

            return View("Login");


        }

        public ActionResult Deslogar()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Login", "Usuario");
        }


    }
}