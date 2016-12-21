using AutoMapper;
using LojaDeItens.Dominio.Configuracao;
using Maturidade_Online.Dominio;
using Maturidade_Online.Filter;
using Maturidade_Online.Models;
using Maturidade_Online.Repositorio;
using Maturidade_Online.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Maturidade_Online.Controllers
{
    public class SubtopicoController : Controller
    {

        private IServicoDeConfiguracao configuracaoServico = ServicoDeDependencia.MontarConfiguracaoServico();

        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Manter(int? id)
        {
            var subtopicoViewModel = new SubtopicoViewModel();
            using (var contexto = new ContextoDeDados())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);

                if (id.HasValue && id.Value > 0)
                {
                    var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                    var subtopicoDaBase = subtopicoServico.BuscarPorId(new Subtopico { Id = id.Value });

                    if (subtopicoDaBase != null)
                    {
                        subtopicoViewModel = Mapper.Map<Subtopico, SubtopicoViewModel>(subtopicoDaBase);
                    }
                }
                subtopicoViewModel.Pilares = (ICollection<Pilar>)pilarServico.Listar();
            }
            return View("Subtopico", subtopicoViewModel);
        }

        [Autorizador]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(SubtopicoViewModel subtopicoViewModel)
        {

            using (var contexto = new ContextoDeDados())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);

                if (ModelState.IsValid)
                {
                    var subtopico = Mapper.Map<SubtopicoViewModel, Subtopico>(subtopicoViewModel);
                   
                    try
                    {
                        subtopicoServico.Persistir(subtopico);
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Falha ao tentar cadastrar os dados no Banco de Dados.");
                        subtopicoViewModel.Pilares = (ICollection<Pilar>)pilarServico.Listar();
                        return View("Subtopico", subtopicoViewModel);
                    }

                    if (subtopicoViewModel.Id > 0)
                    {
                        TempData["MensagemSucesso"] = "Subtópico alterado com sucesso.";
                    }
                    else
                    {
                        TempData["MensagemSucesso"] = "Subtópico cadastrado com sucesso.";
                    }

                    return RedirectToAction("Manter");

                }
                
                subtopicoViewModel.Pilares = (ICollection<Pilar>)pilarServico.Listar();
            }

            return View("Subtopico", subtopicoViewModel);
        }

        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Excluir(int id)
        {

            using (var contexto = new ContextoDeDados())
            {
                if (id > 0)
                {
                    var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                    subtopicoServico.Remover(new Subtopico { Id = id });
                }
            }
            return RedirectToAction("Listar");
        }


        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Listar()
        {
            return View("ListarSubtopicos");
        }



        // Partial View
        [Autorizador]
        public ActionResult PesquisarSubtopicos(int[] idsCaracteristicas)
        {

            if (idsCaracteristicas == null) return PartialView("_Subtopicos");

            using (var contexto = new ContextoDeDados())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var caracteristicas = idsCaracteristicas.Select(c => new Caracteristica() { Id = c }).ToList();
                var subtopicosDaBase = subtopicoServico.ListarComPilar(caracteristicas);

                return PartialView("_Subtopicos", subtopicosDaBase);
            }
        }

        [Autorizador(Roles = "ADMINISTRADOR")]
        public PartialViewResult CarregarLista(int pagina)
        {
            var model = new SubtopicoListagemViewModel();

            using (var contexto = new ContextoDeDados())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var quantidadePorPagina = configuracaoServico.QuantidadeDeCaracteristicasPorPagina;
                var subtopicoDaBase = subtopicoServico.Listar(pagina, quantidadePorPagina);

                model = CriarListagemDeCaracteristicas(contexto, subtopicoDaBase, pagina);
            }

            return PartialView("_ListagemDeSubtopicos", model);
        }

        private SubtopicoListagemViewModel CriarListagemDeCaracteristicas(ContextoDeDados contexto, ICollection<Subtopico> subtopico, int? pagina = null)
        {
            var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
            var model = new SubtopicoListagemViewModel();
            model.Subtopicos = Mapper.Map<IEnumerable<Subtopico>, List<SubtopicoViewModel>>(subtopico);

            if (pagina.HasValue)
            {
                model.PaginaAtual = pagina.Value;
            }
            int quantidadeTotal = subtopicoServico.QuantidadeTotal();
            model.QuantidadeTotal = quantidadeTotal;
            model.QuantidadePorPagina = configuracaoServico.QuantidadeDeCaracteristicasPorPagina;

            return model;
        }
    }
}