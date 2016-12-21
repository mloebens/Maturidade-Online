using LojaDeItens.Dominio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class PilarServico
    {
        private IPilarRepositorio pilarRepositorio;

        public PilarServico(IPilarRepositorio pilarRepositorio)
        {
            this.pilarRepositorio = pilarRepositorio;
        }

        public IEnumerable<Pilar> Listar()
        {
            return pilarRepositorio.Listar();
        }

        public void Persistir(Pilar pilar)
        {
            if(pilar.Id == 0)
            {
                pilarRepositorio.Criar(pilar);
            }
            else
            {
                pilarRepositorio.Editar(pilar);
            }
        }
       
        public void Remover(Pilar pilar)
        {
            pilarRepositorio.Remover(pilar);
        }

        public ICollection<PilarPontuacao> ListarPontuacaoTotal()
        {
            return pilarRepositorio.ListarPontuacaoTotal();
        }

        public Pilar BuscarPorId(Pilar pilar)
        {
            return pilarRepositorio.BuscarPorId(pilar);

        }

        public ICollection<Pilar> Listar(int pagina, int quantidadePorPagina)
        {
            var paginacao = new Paginacao()
            {
                PaginaDesejada = pagina,
                QuantidadePorPagina = quantidadePorPagina
            };

            return this.pilarRepositorio.Listar(paginacao);
        }

        public int QuantidadeTotal()
        {
            return this.pilarRepositorio.QuantidadeTotal();
        }
    }
}
