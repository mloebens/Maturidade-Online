using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class CaracteristicaServico
    {
        private ICaracteristicaRepositorio caracteristicaRepositorio;

        public CaracteristicaServico(ICaracteristicaRepositorio caracteristicaRepositorio)
        {
            this.caracteristicaRepositorio = caracteristicaRepositorio;
        }

        public IEnumerable<Caracteristica> Listar()
        {
            return caracteristicaRepositorio.Listar();
        }

        public void Persistir(Caracteristica caracteristica)
        {
            if (caracteristica.Id == 0)
            {
                caracteristicaRepositorio.Criar(caracteristica);
            }
            else
            {
                caracteristicaRepositorio.Editar(caracteristica);
            }
        }

        public void Remover(Caracteristica pilar)
        {
            caracteristicaRepositorio.Remover(pilar);
        }

        public ICollection<Caracteristica> Listar(ICollection<Caracteristica> caracteristicas)
        {
            return caracteristicaRepositorio.Listar(caracteristicas);
        }

        public Caracteristica BuscarPorId(Caracteristica caracteristica)
        {
            return caracteristicaRepositorio.BuscarPorId(caracteristica);
        }
    }
}
