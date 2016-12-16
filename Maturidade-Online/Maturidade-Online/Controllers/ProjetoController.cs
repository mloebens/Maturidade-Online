using AutoMapper;
using Maturidade_Online.Dominio;
using Maturidade_Online.Filter;
using Maturidade_Online.Models;
using Maturidade_Online.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maturidade_Online.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoServico projetoServico = ServicoDeDependencia.MontarProjetoServico();

        [Autorizador]
        public ActionResult Manter(int? id)
        {
            var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico();
            var subtopicosServico = ServicoDeDependencia.MontarSubtopicoServico();
            var caracteristicas = caracteristicaServico.Listar();
            var subtopicos = subtopicosServico.Listar();
            var projetoModel = new ProjetoModel();

            if (id.HasValue && id.Value > 0)
            {

                var projeto = new Projeto() { Id = id.Value };
                var projetoDaBase = projetoServico.BuscarPorId(projeto);
                if (projetoDaBase != null)
                {
                    projetoModel = Mapper.Map<Projeto, ProjetoModel>(projetoDaBase);
                }
            }
            projetoModel.ListaDeCaracteristicas = caracteristicas;
            projetoModel.ListaDeSubtopicos = subtopicos;

            return View("Projeto", projetoModel);
        }

        [Autorizador]
        public ActionResult Salvar(ProjetoModel projetoModel)
        {
            if (ModelState.IsValid)
            {
                var projeto = Mapper.Map<ProjetoModel, Projeto>(projetoModel);
                var usuarioService = ServicoDeDependencia.MontarUsuarioServico();
                var usuarioAutenticado = new Usuario() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };
                try
                {
                    projetoServico.Persistir(projeto, usuarioAutenticado);
                }
                catch (UsuarioException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            //return View("Projeto");
            return RedirectToAction("Manter");
        }

        [Autorizador]
        public ActionResult Excluir(int id)
        {
            var usuarioAutenticado = new Usuario() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };
            var projeto = new Projeto() { Id = id };
            var projetoDaBase = projetoServico.BuscarPorId(projeto);

            try
            {
                projetoServico.Remover(projetoDaBase, usuarioAutenticado);
            }
            catch (UsuarioException e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View("Projeto");
        }


        // Partial View
        [Autorizador]
        public ActionResult PesquisarSubtopicos(int[] idsCaracteristicas)
        {
            // TODO: consultar banco
            var subtopicos = new[]{
                new Subtopico() { Id = 1, Pontuacao = 5, Nome = "Subtópico 1" },
                new Subtopico() { Id = 2, Pontuacao = 7, Nome = "Subtópico 2" }
            };

            return PartialView("_Subtopicos", subtopicos);
        }


    }
}