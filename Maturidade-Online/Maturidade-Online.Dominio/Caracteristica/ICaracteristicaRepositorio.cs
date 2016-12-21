using LojaDeItens.Dominio.Configuracao;
using Maturidade_Online.Dominio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public interface ICaracteristicaRepositorio : IRepositorio<Caracteristica>
    {
        ICollection<Caracteristica> Listar(ICollection<Caracteristica> caracteristicas);
        ICollection<Caracteristica> Listar(Projeto projeto);

        ICollection<Caracteristica> Listar(Paginacao paginacao);
        Caracteristica BuscarPorId(Caracteristica caracteristica);

        int QuantidadeTotal();
    }
}
