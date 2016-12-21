using AutoMapper;
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
    public class SubtopicoController : Controller
    {

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

        [Autorizador(Roles = "ADMINISTRADOR")]
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

            var subtopicoViewModel = new List<SubtopicoViewModel>();

            using (var contexto = new ContextoDeDados())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var subtopicosDaBase = subtopicoServico.Listar();
                subtopicoViewModel  = Mapper.Map<IEnumerable<Subtopico>, List<SubtopicoViewModel>>(subtopicosDaBase);
            }

            return View("ListarSubtopicos", subtopicoViewModel);
        }



        // Partial View
        [Autorizador(Roles = "ADMINISTRADOR")]
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
    }
}