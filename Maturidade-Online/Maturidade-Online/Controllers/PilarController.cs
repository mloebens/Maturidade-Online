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
    public class PilarController : Controller
    {
        // GET: Pilar
        public ActionResult Manter(int? id)
        {
            var pilarModel = new PilarModel();
            using (var contexto = new ContextoDeDadosEF())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                var pilares = pilarServico.Listar();

                if (id.HasValue && id.Value > 0)
                {
                    var pilar = new Pilar() { Id = id.Value };
                    var pilarDaBase = pilarServico.BuscarPorId(pilar);
                    if (pilarDaBase != null)
                    {
                        pilarModel.Id = pilarDaBase.Id;
                        pilarModel.Titulo = pilarDaBase.Titulo;
                        //pilarModel = Mapper.Map<Pilar, PilarModel>(pilarDaBase);
                    }
                }

            }

            return View("Pilar", pilarModel);
        }

        public ActionResult Salvar(PilarModel pilarModel)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new ContextoDeDadosEF())
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

                }

                return RedirectToAction("Manter");
            }

            return RedirectToAction("Manter");
        }


        // Partial View
        //[Autorizador]
        public ActionResult PesquisarPilares()
        {

            using (var contexto = new ContextoDeDadosEF())
            {
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);



                var lista = subtopicoServico.Listar();

                // TODO: consultar banco

                return PartialView("_Pilares", lista);
            }


        }
    }
}