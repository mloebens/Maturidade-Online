using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Projeto
{
    public class ProjetoServico
    {
        private IProjetoRepositorio projetoRepositorio;

        public ProjetoServico(IProjetoRepositorio projetoRepositorio)
        {
            this.projetoRepositorio = projetoRepositorio;
        }

        public IEnumerable<ProjetoEntidade> Listar()
        {
            return projetoRepositorio.Listar();
        }

        public void Persistir(ProjetoEntidade pilar)
        {
            if (pilar.Id == 0)
            {
                projetoRepositorio.Criar(pilar);
            }
            else
            {
                projetoRepositorio.Editar(pilar);
            }
        }

        public void Remover(ProjetoEntidade pilar)
        {
            projetoRepositorio.Remover(pilar);
        }
    }
}
