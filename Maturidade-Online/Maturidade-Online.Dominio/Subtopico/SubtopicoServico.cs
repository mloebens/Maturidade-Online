using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Subtopico
{
    public class SubtopicoServico
    {
        private ISubtopicoRepositorio subtopicoRepositorio;

        public SubtopicoServico(ISubtopicoRepositorio subtopicoRepositorio)
        {
            this.subtopicoRepositorio = subtopicoRepositorio;
        }

        public IEnumerable<SubtopicoEntidade> Listar()
        {
            return subtopicoRepositorio.Listar();
        }

        public void Persistir(SubtopicoEntidade pilar)
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

        public void Remover(SubtopicoEntidade pilar)
        {
            subtopicoRepositorio.Remover(pilar);
        }
    }
}
