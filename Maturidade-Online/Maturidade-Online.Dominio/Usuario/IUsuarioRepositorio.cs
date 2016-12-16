using Maturidade_Online.Dominio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Usuario
{
    public interface IUsuarioRepositorio
    {

        UsuarioEntidade BuscarPorEmail(UsuarioEntidade usuario);

    }
}
