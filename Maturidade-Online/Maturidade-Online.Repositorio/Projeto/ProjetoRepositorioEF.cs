using Maturidade_Online.Dominio.Projeto;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio.Projeto
{
    public class ProjetoRepositorioEF : RepositorioAbstratoEF<ProjetoEntidade>, IProjetoRepositorio
    {
    }
}
