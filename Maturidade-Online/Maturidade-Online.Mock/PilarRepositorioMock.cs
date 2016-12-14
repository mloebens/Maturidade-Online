using Maturidade_Online.Dominio.Pilar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Mock
{
    public class PilarRepositorioMock : IPilarRepositorio
    {
        IList<PilarEntidade> pilares = new List<PilarEntidade>()
        {
            new PilarEntidade() { Id = 1, Titulo = "Infraestrutura" },
            new PilarEntidade() { Id = 2, Titulo = "Qualidade" },
            new PilarEntidade() { Id = 3, Titulo = "Gestão" }
        };

        public void Criar(PilarEntidade entidade)
        {
            this.pilares.Add(entidade);
        }

        public void Editar(PilarEntidade entidade)
        {
            
        }

        public IEnumerable<PilarEntidade> Listar()
        {
            return pilares;
        }

        public void Remover(PilarEntidade entidade)
        {
            PilarEntidade itemSalvo = this.pilares.First(i => i.Id == entidade.Id);
            this.pilares.Remove(itemSalvo);
        }
    }
}
