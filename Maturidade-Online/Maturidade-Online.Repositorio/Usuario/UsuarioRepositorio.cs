using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        
        public Usuario BuscarPorEmail(Usuario usuario)
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                return contexto.Usuario.FirstOrDefault(u => u.Email.Equals(usuario.Email));
            }
        }

    }
}
