using LojaDeItens.Dominio.Configuracao;
using LojaDeItens.Web.Servicos;
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

        public static UsuarioServico MontarUsuarioServico(ContextoDeDados contexto)
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio(contexto),
                    new ServicoDeCriptografia());
            return usuarioServico;
        }


        public static SubtopicoServico MontarSubtopicoServico(ContextoDeDados contexto)
        {
            SubtopicoServico subtopicoServico =
                new SubtopicoServico(
                    new SubtopicoRepositorio(contexto));
            return subtopicoServico;
        }

        public static PilarServico MontarPilarServico(ContextoDeDados contexto)
        {
            PilarServico pilarServico =
                new PilarServico(
                    new PilarRepositorio(contexto));
            return pilarServico;
        }

        public static CaracteristicaServico MontarCaracteristicaServico(ContextoDeDados contexto)
        {
            CaracteristicaServico caracteristicaServico =
                new CaracteristicaServico(
                    new CaracteristicaRepositorio(contexto));
            return caracteristicaServico;
        }

         public static ProjetoServico MontarProjetoServico(ContextoDeDados contexto)
        {
            ProjetoServico projetoServico =
                new ProjetoServico(
                    new ProjetoRepositorio(contexto),
                    new UsuarioRepositorio(contexto));
            return projetoServico;
        }

        public static IServicoDeConfiguracao MontarConfiguracaoServico()
        {
            return new ServicoDeConfiguracao();
        }

    }
}