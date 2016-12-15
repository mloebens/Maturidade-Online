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

        //public ActionResult Salvar(ProjetoModel projetoModel)
        public ActionResult Salvar()
        {
            //Injeção - Somente para teste

            var caracteristicas = new List<CaracteristicaEntidade>()
            {
                new CaracteristicaEntidade() { Id = 2 }
            };

            var subtopicos = new List<SubtopicoEntidade>()
            {
                new SubtopicoEntidade() { Id = 4 }
            };


            var projetoModelInjetado = new ProjetoModel()
            {
                Nome = "Projeto2",
                caracteristicas = caracteristicas,
                subtopicos = subtopicos

            };

            //Injeção

            var projeto = Mapper.Map<ProjetoModel, ProjetoEntidade>(projetoModelInjetado);
            projetoServico.Persistir(projeto);

            return View("Projeto");
        }
    }
}