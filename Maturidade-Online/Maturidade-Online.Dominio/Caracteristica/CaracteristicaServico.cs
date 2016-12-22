using LojaDeItens.Dominio.Configuracao;
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

        public void Remover(Caracteristica caracteristica)
        {
            var caracteristicaDaBase = caracteristicaRepositorio.BuscarPorId(caracteristica);

            if (caracteristicaDaBase.Projetos != null)
            {
                throw new CaracteristicaException("Não é posssivel excluir uma caracteristica já vinculada a um projeto.");
            }
            else
            {
                caracteristicaRepositorio.Remover(caracteristica);
            }
        }

        public ICollection<Caracteristica> Listar(ICollection<Caracteristica> caracteristicas)
        {
            return caracteristicaRepositorio.Listar(caracteristicas);
        }

        public Caracteristica BuscarPorId(Caracteristica caracteristica)
        {
            return caracteristicaRepositorio.BuscarPorId(caracteristica);
        }

        public ICollection<Caracteristica> Listar(Projeto projeto)
        {
            return caracteristicaRepositorio.Listar(projeto);
        }

        public ICollection<Caracteristica> Listar(int pagina, int quantidadePorPagina)
        {

            var paginacao = new Paginacao()
            {
                PaginaDesejada = pagina,
                QuantidadePorPagina = quantidadePorPagina
            };

            return this.caracteristicaRepositorio.Listar(paginacao);
        }

        public int QuantidadeTotal()
        {
            return this.caracteristicaRepositorio.QuantidadeTotal();
        }


    }
}
