using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Caracteristica
{
    public class CaracteristicaServico
    {
        private ICaracteristicaRepositorio caracteristicaRepositorio;

        public CaracteristicaServico(ICaracteristicaRepositorio caracteristicaRepositorio)
        {
            this.caracteristicaRepositorio = caracteristicaRepositorio;
        }

        public IEnumerable<CaracteristicaEntidade> Listar()
        {
            return caracteristicaRepositorio.Listar();
        }

        public void Persistir(CaracteristicaEntidade pilar)
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

        public void Remover(CaracteristicaEntidade pilar)
        {
            caracteristicaRepositorio.Remover(pilar);
        }
    }
}
