using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Dominio;
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
        public PilarEntidade Pilares { get; set; }
        public virtual ICollection<Caracteristica> Caracteristicas { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }

        public SubtopicoEntidade()
        {
            this.Caracteristicas = new HashSet<Caracteristica>();
            this.Projetos = new HashSet<Projeto>();
        }
    }
}
