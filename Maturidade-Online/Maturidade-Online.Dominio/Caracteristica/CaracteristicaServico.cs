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

        public void Persistir(Caracteristica pilar)
        {
            if (pilar.Id == 0)
            {
                caracteristicaRepositorio.Criar(pilar);
            }
            else
            {
                caracteristicaRepositorio.Editar(pilar);
            }
        }

        public void Remover(Caracteristica pilar)
        {
            caracteristicaRepositorio.Remover(pilar);
        }
    }
}
