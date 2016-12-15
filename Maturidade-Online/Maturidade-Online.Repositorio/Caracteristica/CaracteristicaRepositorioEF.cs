using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio.Caracteristica
{
    public class CaracteristicaRepositorioEF : RepositorioAbstratoEF<CaracteristicaEntidade>, ICaracteristicaRepositorio
    {
        public override IEnumerable<CaracteristicaEntidade> Listar()
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                contexto.Configuration.ProxyCreationEnabled = false;
                return contexto.Caracteristica.Include("Subtopicos").ToList();
            }
        }
    }
}
