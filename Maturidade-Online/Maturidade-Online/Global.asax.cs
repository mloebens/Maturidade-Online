using AutoMapper;
using Maturidade_Online.Dominio;
using Maturidade_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Maturidade_Online
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<PilarViewModel, Pilar>();
                cfg.CreateMap<Pilar, PilarViewModel>();
                cfg.CreateMap<ProjetoModel, Projeto>();
                cfg.CreateMap<Projeto, ProjetoModel>();
                cfg.CreateMap<UsuarioModel, Usuario>();
                cfg.CreateMap<SubtopicoViewModel, Subtopico>();
                cfg.CreateMap<Subtopico, SubtopicoViewModel>();
                cfg.CreateMap<Caracteristica, CaracteristicaViewModel>();
                cfg.CreateMap<CaracteristicaViewModel, Caracteristica>()
                    .ForMember(destino => destino.Subtopicos, opcao => opcao.MapFrom(origem => origem.IdsSubtopicos.Select(id => new Subtopico { Id = id})));
            });

        }
    }
}
