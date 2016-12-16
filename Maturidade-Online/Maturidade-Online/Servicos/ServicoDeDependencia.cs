using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Dominio.Usuario;
using Maturidade_Online.Infraestrutura;
using Maturidade_Online.Repositorio;
using Maturidade_Online.Repositorio.Caracteristica;
using Maturidade_Online.Repositorio.Subtopico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Servicos
{
    public class ServicoDeDependencia
    {

        public static UsuarioServico MontarUsuarioServico()
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio(),
                    new ServicoDeCriptografia());
            return usuarioServico;
        }


        public static SubtopicoServico MontarSubtopicoServico()
        {
            SubtopicoServico subtopicoServico =
                new SubtopicoServico(
                    new SubtopicoRepositorioEF());
            return subtopicoServico;
        }

        public static CaracteristicaServico MontarCaracteristicaServico()
        {
            CaracteristicaServico caracteristicaServico =
                new CaracteristicaServico(
                    new CaracteristicaRepositorioEF());
            return caracteristicaServico;
        }

         public static ProjetoServico MontarProjetoServico()
        {
            ProjetoServico projetoServico =
                new ProjetoServico(
                    new ProjetoRepositorioEF(),
                    new UsuarioRepositorio());
            return projetoServico;
        }
    }
}