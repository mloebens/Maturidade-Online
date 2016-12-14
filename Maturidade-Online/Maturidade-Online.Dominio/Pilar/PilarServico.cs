using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Pilar
{
    public class PilarServico
    {
        private IPilarRepositorio pilarRepositorio;

        public PilarServico(IPilarRepositorio pilarRepositorio)
        {
            this.pilarRepositorio = pilarRepositorio;
        }

        public IEnumerable<PilarEntidade> Listar()
        {
            return pilarRepositorio.Listar();
        }

        public void Persistir(PilarEntidade pilar)
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
       
        public void Remover(PilarEntidade pilar)
        {
            pilarRepositorio.Remover(pilar);
        }
    }
}
