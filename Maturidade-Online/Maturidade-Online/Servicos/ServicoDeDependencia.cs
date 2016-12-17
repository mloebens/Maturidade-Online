using Maturidade_Online.Dominio;
using Maturidade_Online.Infraestrutura;
using Maturidade_Online.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Servicos
{
    public class ServicoDeDependencia
    {

        public static UsuarioServico MontarUsuarioServico(ContextoDeDadosEF contexto)
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio(contexto),
                    new ServicoDeCriptografia());
            return usuarioServico;
        }


        public static SubtopicoServico MontarSubtopicoServico(ContextoDeDadosEF contexto)
        {
            SubtopicoServico subtopicoServico =
                new SubtopicoServico(
                    new SubtopicoRepositorioEF(contexto));
            return subtopicoServico;
        }

        public static CaracteristicaServico MontarCaracteristicaServico(ContextoDeDadosEF contexto)
        {
            CaracteristicaServico caracteristicaServico =
                new CaracteristicaServico(
                    new CaracteristicaRepositorioEF(contexto));
            return caracteristicaServico;
        }

         public static ProjetoServico MontarProjetoServico(ContextoDeDadosEF contexto)
        {
            ProjetoServico projetoServico =
                new ProjetoServico(
                    new ProjetoRepositorioEF(contexto),
                    new UsuarioRepositorio(contexto));
            return projetoServico;
        }

        public static PilarServico MontarPilarServico(ContextoDeDadosEF contexto)
        {
            PilarServico pilarServico = 
            new PilarServico(
                new PilarRepositorioEF(contexto));

            return pilarServico;
        }
    }
}