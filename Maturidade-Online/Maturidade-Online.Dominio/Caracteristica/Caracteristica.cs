using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class Caracteristica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Subtopico> Subtopicos { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }

        public Caracteristica()
        {
            this.Subtopicos = new HashSet<Subtopico>();
            this.Projetos = new HashSet<Projeto>();
        }
    }
}
