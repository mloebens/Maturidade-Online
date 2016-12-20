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
    public class CaracteristicaController : Controller
    {

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
        public ActionResult Listar()
        {
            var caracteristicaViewModel = new List<CaracteristicaViewModel>();
            
            using (var contexto = new ContextoDeDados())
            {
                var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                var caracteristicasDaBase = caracteristicaServico.Listar();
                caracteristicaViewModel = Mapper.Map<IEnumerable<Caracteristica>, List<CaracteristicaViewModel>>(caracteristicasDaBase);
            }
            return View("ListarCaracteristicas", caracteristicaViewModel);
        }
    }
}