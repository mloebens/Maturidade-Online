using LojaDeItens.Dominio.Configuracao;
using Maturidade_Online.Dominio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public interface IPilarRepositorio : IRepositorio<Pilar>
    {
        ICollection<PilarPontuacao> ListarPontuacaoTotal();
        Pilar BuscarPorId(Pilar pilar);
        int QuantidadeTotal();
        ICollection<Pilar> Listar(Paginacao paginacao);
    }
}
