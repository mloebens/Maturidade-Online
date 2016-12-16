using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class Subtopico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Pontuacao { get; set; }
        public int PilarId { get; set; }
        public Pilar Pilares { get; set; }
        public virtual ICollection<Caracteristica> Caracteristicas { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }

        public Subtopico()
        {
            this.Caracteristicas = new HashSet<Caracteristica>();
            this.Projetos = new HashSet<Projeto>();
        }
    }
}
