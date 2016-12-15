using AutoMapper;
using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Dominio.Projeto;
using Maturidade_Online.Dominio.Subtopico;
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

                var projeto = new ProjetoEntidade() { Id = id.Value };
                var projetoDaBase = projetoServico.BuscarPorId(projeto);
                if (projetoDaBase != null)
                {
                    projetoModel = Mapper.Map<ProjetoEntidade, ProjetoModel>(projetoDaBase);
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
                var projeto = Mapper.Map<ProjetoModel, ProjetoEntidade>(projetoModel);
                var usuarioService = ServicoDeDependencia.MontarUsuarioServico();

                var usuarioAutenticadoEmail = ServicoDeAutenticacao.UsuarioLogado.Login;
                var usuarioLogado = usuarioService.BuscarPorEmail(usuarioAutenticadoEmail);
                
                projetoServico.Persistir(projeto, usuarioLogado);
            }

            return View("Projeto");
        }
    }
}