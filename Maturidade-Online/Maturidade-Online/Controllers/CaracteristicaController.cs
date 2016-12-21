using AutoMapper;
using LojaDeItens.Dominio.Configuracao;
using LojaDeItens.Web.Servicos;
using Maturidade_Online.Dominio;
using Maturidade_Online.Filter;
using Maturidade_Online.Models;
using Maturidade_Online.Repositorio;
using Maturidade_Online.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maturidade_Online.Controllers
{
    public class CaracteristicaController : Controller
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
            var caracteristicaViewModel = new CaracteristicaViewModel();
            using (var contexto = new ContextoDeDados())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
 

                if (id.HasValue && id.Value > 0)
                {
                    var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                    var caracteristicaDaBase = caracteristicaServico.BuscarPorId(new Caracteristica { Id = id.Value });

                    if (caracteristicaDaBase != null)
                    {
                        caracteristicaViewModel = Mapper.Map<Caracteristica, CaracteristicaViewModel>(caracteristicaDaBase);
                    }
                }
                caracteristicaViewModel.ListaDeSubtopicos = (ICollection<Subtopico>)subtopicoServico.Listar();
            }
            return View("Caracteristica", caracteristicaViewModel);
        }


        [Autorizador(Roles = "ADMINISTRADOR")]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(CaracteristicaViewModel caracteristicaViewModel)
        {

            using (var contexto = new ContextoDeDados())
            {
                var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                if (ModelState.IsValid)
                {
                    var caracteristica = Mapper.Map<CaracteristicaViewModel, Caracteristica>(caracteristicaViewModel);

                    try
                    {
                        caracteristicaServico.Persistir(caracteristica);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", "Falha ao tentar cadastrar os dados no Banco de Dados.");
                        caracteristicaViewModel.ListaDeSubtopicos = (ICollection<Subtopico>)subtopicoServico.Listar();
                        return View("Caracteristica", caracteristicaViewModel);
                    }

                    if (caracteristicaViewModel.Id > 0)
                    {
                        TempData["MensagemSucesso"] = "Caracteristica alterada com sucesso.";
                    }
                    else
                    {
                        TempData["MensagemSucesso"] = "Caracteristica cadastrada com sucesso.";
                    }

                    return RedirectToAction("Manter");

                }

                caracteristicaViewModel.ListaDeSubtopicos = (ICollection<Subtopico>)subtopicoServico.Listar();
            }

            return View("Caracteristica", caracteristicaViewModel);
        }


        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Excluir(int id)
        {
            using (var contexto = new ContextoDeDados())
            {
                var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                var caracteristica = new Caracteristica() { Id = id };
                caracteristica = caracteristicaServico.BuscarPorId(caracteristica);

                caracteristicaServico.Remover(caracteristica);

            }

            return RedirectToAction("Listar");
        }


        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Listar()
        {

            return View("ListarCaracteristicas");
        }


        //[Autorizador(Roles = "ADMINISTRADOR")]
        public PartialViewResult CarregarCaracteristicas(int pagina)
        {
            var model = new CaracteristicaListagemViewModel();

            using (var contexto = new ContextoDeDados())
            {
                var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                var quantidadePorPagina = configuracaoServico.QuantidadeDeCaracteristicasPorPagina;
                var caracteristicasDaBase = caracteristicaServico.Listar(pagina, quantidadePorPagina);

                model = CriarListagemDeCaracteristicas(contexto, caracteristicasDaBase, pagina);
            }

            return PartialView("_ListagemDeCaracteristicas", model);
        }

        private CaracteristicaListagemViewModel CriarListagemDeCaracteristicas(ContextoDeDados contexto, ICollection<Caracteristica> caracteristicas, int? pagina = null)
        {
            var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
            var model = new CaracteristicaListagemViewModel();
            model.Caracteristicas = Mapper.Map<IEnumerable<Caracteristica>, List<CaracteristicaViewModel>>(caracteristicas);

            if (pagina.HasValue)
            {
                model.PaginaAtual = pagina.Value;
            }
            int quantidadeTotal = caracteristicaServico.QuantidadeTotal();
            model.QuantidadeTotal = quantidadeTotal;
            model.QuantidadePorPagina = configuracaoServico.QuantidadeDeCaracteristicasPorPagina;

            return model;
        }


    }
}