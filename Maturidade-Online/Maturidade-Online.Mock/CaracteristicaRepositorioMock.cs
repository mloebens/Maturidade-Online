using Maturidade_Online.Dominio.Caracteristica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Mock
{
    public class CaracteristicaRepositorioMock : ICaracteristicaRepositorio
    {
        IList<CaracteristicaEntidade> caracteristicaes = new List<CaracteristicaEntidade>()
        {
            new CaracteristicaEntidade() { Id = 1, Nome = "Teste 1" },
            new CaracteristicaEntidade() { Id = 2, Nome = "Teste 2" },
            new CaracteristicaEntidade() { Id = 3, Nome = "Teste 3" }
        };

        public void Criar(CaracteristicaEntidade entidade)
        {
            this.caracteristicaes.Add(entidade);
        }

        public void Editar(CaracteristicaEntidade entidade)
        {

        }

        public IEnumerable<CaracteristicaEntidade> Listar()
        {
            return caracteristicaes;
        }

        public void Remover(CaracteristicaEntidade entidade)
        {
            CaracteristicaEntidade itemSalvo = this.caracteristicaes.First(i => i.Id == entidade.Id);
            this.caracteristicaes.Remove(itemSalvo);
        }
    }
}
