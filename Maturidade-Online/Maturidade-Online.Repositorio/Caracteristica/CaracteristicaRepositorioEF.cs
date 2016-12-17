using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Maturidade_Online.Repositorio
{
    public class CaracteristicaRepositorioEF : RepositorioAbstratoEF<Caracteristica>, ICaracteristicaRepositorio
    {
        public CaracteristicaRepositorioEF(ContextoDeDadosEF contexto) : base(contexto)
        {
        }

        public override IEnumerable<Caracteristica> Listar()
        {
            contexto.Configuration.ProxyCreationEnabled = false;
            return contexto.Caracteristica.Include("Subtopicos").ToList();
        }

        public override void Editar(Caracteristica caracteristica)
        {
            CaracteristicaRepositorio repositorio = new CaracteristicaRepositorio();
            repositorio.AlterarVinculos(caracteristica);
            base.Editar(caracteristica);
        }

        public ICollection<Caracteristica> Listar(ICollection<Caracteristica> caracteristicas)
        {
            var ids = caracteristicas.Select(_ => _.Id);

            return contexto.Caracteristica.Include("Subtopicos").Where(c => ids.Any(id => id == c.Id)).ToList();
        }
    }
}
