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


        [Autorizador]
        public ActionResult Manter(int? id)
        {

            var subtopicoViewModel = new SubtopicoViewModel();
            using (var contexto = new ContextoDeDadosEF())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);

                if (id.HasValue && id.Value > 0)
                {
                    var subtopicosServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                    var subtopicoDaBase = subtopicosServico.BuscarPorId(new Subtopico { Id = id.Value });

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

            using (var contexto = new ContextoDeDadosEF())
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
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", "Falha ao tentar cadastrar os dados no Banco de Dados.");
                        subtopicoViewModel.Pilares = (ICollection<Pilar>)pilarServico.Listar();
                        return View("Subtopico", subtopicoViewModel);
                    }

                    if (subtopico.Id > 0)
                    {
                        TempData["MensagemSucesso"] = "Subtopico alterado com sucesso.";
                    }
                    else
                    {
                        TempData["MensagemSucesso"] = "Subtopico cadastrado com sucesso.";
                    }
                    return RedirectToAction("Manter");

                }
                
                subtopicoViewModel.Pilares = (ICollection<Pilar>)pilarServico.Listar();
            }

            return View("Subtopico", subtopicoViewModel);
        }

        [Autorizador]
        public ActionResult Excluir(int id)
        {

            using (var contexto = new ContextoDeDadosEF())
            {
                if (id > 0)
                {
                    var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                    subtopicoServico.Remover(new Subtopico { Id = id });
                }
            }
            return RedirectToAction("Listar");
        }


        [Autorizador]
        public ActionResult Listar()
        {

            var subtopicoViewModel = new List<SubtopicoViewModel>();

            using (var contexto = new ContextoDeDadosEF())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var subtopicosDaBase = subtopicoServico.Listar();
                subtopicoViewModel = subtopicosDaBase.Select(_ => new SubtopicoViewModel { Id = _.Id, Nome = _.Nome, Descricao = _.Descricao, Pontuacao = _.Pontuacao }).ToList();
            }

            return View("ListarSubtopicos", subtopicoViewModel);
        }



        // Partial View
        [Autorizador]
        public ActionResult PesquisarSubtopicos(int[] idsCaracteristicas)
        {
            if (idsCaracteristicas == null) return PartialView("_Subtopicos");

            using (var contexto = new ContextoDeDadosEF())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var caracteristicas = idsCaracteristicas.Select(c => new Caracteristica() { Id = c }).ToList();
                var subtopicosDaBase = subtopicoServico.Listar(caracteristicas);

                return PartialView("_Subtopicos", subtopicosDaBase);
            }
        }
    }
}