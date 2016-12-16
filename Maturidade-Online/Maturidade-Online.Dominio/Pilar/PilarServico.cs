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
    }
}
