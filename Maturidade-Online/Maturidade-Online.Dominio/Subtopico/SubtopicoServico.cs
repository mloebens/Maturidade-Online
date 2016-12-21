using LojaDeItens.Dominio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class SubtopicoServico
    {
        private ISubtopicoRepositorio subtopicoRepositorio;

        public SubtopicoServico(ISubtopicoRepositorio subtopicoRepositorio)
        {
            this.subtopicoRepositorio = subtopicoRepositorio;
        }

        public IEnumerable<Subtopico> Listar()
        {
            return subtopicoRepositorio.Listar();
        }

        public void Persistir(Subtopico subtopico)
        {
            if (subtopico.Id == 0)
            {
                subtopicoRepositorio.Criar(subtopico);
            }
            else
            {
                subtopicoRepositorio.Editar(subtopico);
            }
        }

        public void Remover(Subtopico pilar)
        {
            subtopicoRepositorio.Remover(pilar);
        }

        ICollection<Subtopico> Listar(ICollection<Subtopico> subtopico)
        {
            return subtopicoRepositorio.Listar(subtopico);
        }
        public ICollection<Subtopico> ListarComPilar(ICollection<Caracteristica> caracteristica)
        {
            return subtopicoRepositorio.ListarComPilar(caracteristica);
        }

        public ICollection<Subtopico> Listar(ICollection<Caracteristica> caracteristica)
        {
            return subtopicoRepositorio.Listar(caracteristica);
        }

        public ICollection<Subtopico> ListarPorPilar(int id)
        {
            return subtopicoRepositorio.ListarPorPilar(id);
        }

        public Subtopico BuscarPorId(Subtopico subtopico)
        {
            return subtopicoRepositorio.BuscarPorId(subtopico);
        }

        public ICollection<Subtopico> Listar(Caracteristica caracteristica)
        {
            return subtopicoRepositorio.Listar(caracteristica);
        }

        public ICollection<Subtopico> Listar(Projeto projeto)
        {
            return subtopicoRepositorio.Listar(projeto);
        }

        public ICollection<Subtopico> Listar(Pilar pilar)
        {
            return subtopicoRepositorio.Listar(pilar);
        }

        public ICollection<Subtopico> Listar(int pagina, int quantidadePorPagina)
        {
            var paginacao = new Paginacao()
            {
                PaginaDesejada = pagina,
                QuantidadePorPagina = quantidadePorPagina
            };
            return this.subtopicoRepositorio.Listar(paginacao);
        }

        public int QuantidadeTotal()
        {
            return this.subtopicoRepositorio.QuantidadeTotal();
        }
    }
}
