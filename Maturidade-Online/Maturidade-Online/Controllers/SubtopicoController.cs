using Maturidade_Online.Dominio;
using Maturidade_Online.Filter;
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