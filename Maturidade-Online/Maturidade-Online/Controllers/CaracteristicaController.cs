using AutoMapper;
using Maturidade_Online.Dominio;
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
        public ActionResult Listar()
        {

            var caracteristicaViewModel = new List<CaracteristicaViewModel>();
            
            using (var contexto = new ContextoDeDadosEF())
            {

                var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                var caracteristicasDaBase = caracteristicaServico.Listar();

                caracteristicaViewModel = Mapper.Map<IEnumerable<Caracteristica>, List<CaracteristicaViewModel>>(caracteristicasDaBase);

            }


            return View("ListarCaracteristicas", caracteristicaViewModel);
        }
    }
}