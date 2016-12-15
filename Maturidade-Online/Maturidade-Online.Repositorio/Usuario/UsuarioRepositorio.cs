using Maturidade_Online.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        
        public UsuarioEntidade BuscarPorEmail(string email)
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                return contexto.Usuario.FirstOrDefault(u => u.Email.Equals(email));
            }
        }

    }
}
