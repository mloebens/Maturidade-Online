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
using System.Web;
using System.Web.Mvc;

namespace Maturidade_Online.Controllers
{
    public class PilarController : Controller
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
            var pilarViewModel = new PilarViewModel();
            using (var contexto = new ContextoDeDados())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);

                if (id.HasValue && id.Value > 0)
                {
                    var pilar = new Pilar() { Id = id.Value };
                    var pilarDaBase = pilarServico.BuscarPorId(pilar);
                    pilarViewModel = Mapper.Map<Pilar, PilarViewModel>(pilarDaBase);

                    var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                    pilarViewModel.Subtopicos = subtopicoServico.Listar(pilar);
                }

            }

            return View("Pilar", pilarViewModel);
        }

        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Salvar(PilarViewModel pilarModel)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new ContextoDeDados())
                {
                    //Adicionar no projeto
                    var pilar = new Pilar();
                    if (pilarModel.Id.HasValue)
                    {
                        pilar.Id = pilarModel.Id.Value;
                    }
                    pilar.Titulo = pilarModel.Titulo;

                    var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);

                    try
                    {
                        pilarServico.Persistir(pilar);
                    }
                    catch (UsuarioException e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }

                    if (pilarModel.Id != null && pilarModel.Id.Value > 0)
                    {
                        TempData["MensagemSucesso"] = "Pilar alterado com sucesso.";
                    }
                    else
                    {
                        TempData["MensagemSucesso"] = "Pilar cadastrado com sucesso.";
                    }
                }

                return RedirectToAction("Manter");
            }

            return RedirectToAction("Manter");
        }

        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Listar()
        {
            return View("ListarPilares");
        }


        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult Excluir(int id)
        {
            using (var contexto = new ContextoDeDados())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                var pilar = new Pilar() { Id = id };
                pilar = pilarServico.BuscarPorId(pilar);

                pilarServico.Remover(pilar);
            }
            return RedirectToAction("Listar");
        }


        [Autorizador(Roles = "ADMINISTRADOR")]
        public ActionResult PesquisarPilares(int[] id)
        {

            using (var contexto = new ContextoDeDados())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var lista = subtopicoServico.ListarPorPilar(id.FirstOrDefault());
                var listaTotal = subtopicoServico.Listar();

                // TODO: consultar banco
                if (lista.Count < 1) return PartialView("_Subtopicos");

                return PartialView("_Pilares", lista);
            }
        }

        [Autorizador(Roles = "ADMINISTRADOR")]
        public PartialViewResult CarregarLista(int pagina)
        {
            var model = new PilarListagemViewModel();

            using (var contexto = new ContextoDeDados())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                var quantidadePorPagina = configuracaoServico.QuantidadeDeCaracteristicasPorPagina;
                var pilaresDaBase = pilarServico.Listar(pagina, quantidadePorPagina);

                model = CriarListagemDeCaracteristicas(contexto, pilaresDaBase, pagina);
            }

            return PartialView("_ListagemDePilares", model);
        }

        private PilarListagemViewModel CriarListagemDeCaracteristicas(ContextoDeDados contexto, ICollection<Pilar> pilares, int? pagina = null)
        {
            //var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
            var model = new PilarListagemViewModel();
            var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
            var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);

            model.Pilares = Mapper.Map<IEnumerable<Pilar>, List<PilarViewModel>>(pilares);

            foreach (var pilar in model.Pilares)
            {
                pilar.Subtopicos = subtopicoServico.Listar(new Pilar { Id = pilar.Id.Value });
            }

            if (pagina.HasValue)
            {
                model.PaginaAtual = pagina.Value;
            }

            int quantidadeTotal = pilarServico.QuantidadeTotal();
            model.QuantidadeTotal = quantidadeTotal;
            model.QuantidadePorPagina = configuracaoServico.QuantidadeDeCaracteristicasPorPagina;

            return model;
        }
    }
}