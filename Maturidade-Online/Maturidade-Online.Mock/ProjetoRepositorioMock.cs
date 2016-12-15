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
        IList<ProjetoEntidade> projetoes = new List<ProjetoEntidade>()
        {
            new ProjetoEntidade() { Id = 1 },
            new ProjetoEntidade() { Id = 2 },
            new ProjetoEntidade() { Id = 3 }
        };

        public void Criar(ProjetoEntidade entidade)
        {
            this.projetoes.Add(entidade);
        }

        public void Editar(ProjetoEntidade entidade)
        {

        }

        public IEnumerable<ProjetoEntidade> Listar()
        {
            return projetoes;
        }

        public void Remover(ProjetoEntidade entidade)
        {
            ProjetoEntidade itemSalvo = this.projetoes.First(i => i.Id == entidade.Id);
            this.projetoes.Remove(itemSalvo);
        }
    }
}
