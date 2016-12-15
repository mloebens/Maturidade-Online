using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Dominio.Subtopico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Projeto
{
    [Table("Projeto")]
    public class ProjetoEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<CaracteristicaEntidade> Caracteristicas { get; set; }
        public virtual ICollection<SubtopicoEntidade> Subtopicos { get; set; }

        public ProjetoEntidade()
        {
            this.Subtopicos = new HashSet<SubtopicoEntidade>();
            this.Caracteristicas = new HashSet<CaracteristicaEntidade>();
        }
    }
}