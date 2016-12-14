using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Dominio.Pilar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Subtopico
{
    [Table("Subtopico")]
    public class SubtopicoEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Pontuacao { get; set; }
        public int PilarEntidadeId { get; set; }
        public PilarEntidade MyProperty { get; set; }
        public virtual ICollection<CaracteristicaEntidade> Caracteristicas { get; set; }

        public SubtopicoEntidade()
        {
            this.Caracteristicas = new HashSet<CaracteristicaEntidade>();
        }
    }
}
