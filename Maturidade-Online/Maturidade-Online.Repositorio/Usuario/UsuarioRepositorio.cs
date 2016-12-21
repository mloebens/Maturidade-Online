using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class UsuarioRepositorio : RepositorioAbstrato<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoDeDados contexto) : base(contexto)
        {
        }

        public Usuario BuscarPorEmail(Usuario usuario)
        {
            return contexto.Usuario.Include("Permissao").FirstOrDefault(u => u.Email.Equals(usuario.Email));
        }

    }
}
