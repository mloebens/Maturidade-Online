using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Filter;
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
        [Autorizador]
        public ActionResult Novo()
        {
            var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico();


            IEnumerable<SubtopicoEntidade> subtopicos = subtopicoServico.Listar();

            return View("NovoProjeto");
        }
    }
}