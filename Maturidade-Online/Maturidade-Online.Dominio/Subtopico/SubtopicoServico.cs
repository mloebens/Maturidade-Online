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

        public void Persistir(Subtopico pilar)
        {
            if (pilar.Id == 0)
            {
                subtopicoRepositorio.Criar(pilar);
            }
            else
            {
                subtopicoRepositorio.Editar(pilar);
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
    }
}
