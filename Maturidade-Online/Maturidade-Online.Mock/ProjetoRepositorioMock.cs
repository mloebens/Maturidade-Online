using Maturidade_Online.Dominio.Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Mock
{
    public class ProjetoRepositorioMock : IProjetoRepositorio
    {
        IList<ProjetoEntidade> projetos = new List<ProjetoEntidade>()
        {
            new ProjetoEntidade() { Id = 1 },
            new ProjetoEntidade() { Id = 2 },
            new ProjetoEntidade() { Id = 3 }
        };

        public ProjetoEntidade BuscarPorId(int id)
        {
            return this.projetos.FirstOrDefault(_ => _.Id == id);
        }

        public void Criar(ProjetoEntidade entidade)
        {
            this.projetos.Add(entidade);
        }

        public void Editar(ProjetoEntidade entidade)
        {

        }

        public IEnumerable<ProjetoEntidade> Listar()
        {
            return projetos;
        }

        public void Remover(ProjetoEntidade entidade)
        {
            ProjetoEntidade itemSalvo = this.projetos.First(i => i.Id == entidade.Id);
            this.projetos.Remove(itemSalvo);
        }
    }
}
