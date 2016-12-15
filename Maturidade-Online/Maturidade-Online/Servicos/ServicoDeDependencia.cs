using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Dominio.Usuario;
using Maturidade_Online.Infraestrutura;
using Maturidade_Online.Repositorio;
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
    }
}