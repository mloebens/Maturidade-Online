using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Subtopico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Caracteristica
{
    [Table("Caracteristica")]
    public class CaracteristicaEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<SubtopicoEntidade> Subtopicos { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }

        public CaracteristicaEntidade()
        {
            this.Subtopicos = new HashSet<SubtopicoEntidade>();
            this.Projetos = new HashSet<Projeto>();
        }
    }
}
