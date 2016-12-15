using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Dominio.Subtopico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Mock
{
    public class SubtopicoRepositorioMock : ISubtopicoRepositorio
    {
        IList<SubtopicoEntidade> pilares = new List<SubtopicoEntidade>()
        {
            new SubtopicoEntidade() { Id = 1, Nome = "Teste 1", Descricao = "bla bla", PilarEntidadeId = 1, Pontuacao = 20  },
            new SubtopicoEntidade() { Id = 2, Nome = "Teste 2", Descricao = "bla bla", PilarEntidadeId = 2, Pontuacao = 20  },
            new SubtopicoEntidade() { Id = 3, Nome = "Teste 3", Descricao = "bla bla", PilarEntidadeId = 1, Pontuacao = 20  }
        };

        public void Criar(SubtopicoEntidade entidade)
        {
            this.pilares.Add(entidade);
        }

        public void Editar(SubtopicoEntidade entidade)
        {
            
        }

        public IEnumerable<SubtopicoEntidade> Listar()
        {
            return pilares;
        }

        public void Remover(SubtopicoEntidade entidade)
        {
            SubtopicoEntidade itemSalvo = this.pilares.First(i => i.Id == entidade.Id);
            this.pilares.Remove(itemSalvo);
        }
    }
}
