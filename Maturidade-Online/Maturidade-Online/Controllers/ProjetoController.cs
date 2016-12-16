using AutoMapper;
using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Dominio.Usuario;
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

        //[Autorizador]
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
            projetoModel.listaDeCaracteristicas = caracteristicas;
            projetoModel.listaDeSubtopicos = subtopicos;

            return View("Projeto", projetoModel);
        }

        public ActionResult Salvar(ProjetoModel projetoModel)
        {
            if (ModelState.IsValid)
            {
                var projeto = Mapper.Map<ProjetoModel, Projeto>(projetoModel);
                var usuarioService = ServicoDeDependencia.MontarUsuarioServico();
                var usuarioAutenticado = new UsuarioEntidade() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };
                try
                {
                    projetoServico.Persistir(projeto, usuarioAutenticado);
                }
                catch (UsuarioException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View("Projeto");
        }


        public ActionResult Excluir(int id)
        {
            var usuarioAutenticado = new UsuarioEntidade() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };
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
    }
}