using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class CaracteristicaRepositorioEF : RepositorioAbstratoEF<Caracteristica>, ICaracteristicaRepositorio
    {
        public override IEnumerable<Caracteristica> Listar()
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                contexto.Configuration.ProxyCreationEnabled = false;
                return contexto.Caracteristica.Include("Subtopicos").ToList();
            }
        }

        public override void Editar(Caracteristica caracteristica)
        {
            CaracteristicaRepositorio repositorio = new CaracteristicaRepositorio();
            repositorio.AlterarVinculos(caracteristica);
            base.Editar(caracteristica);
        }
    }
}
