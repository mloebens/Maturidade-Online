using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class PilarRepositorioEF : RepositorioAbstratoEF<Pilar>, IPilarRepositorio
    {
        public PilarRepositorioEF(ContextoDeDadosEF contexto) : base(contexto)
        {
        }
    }
}
