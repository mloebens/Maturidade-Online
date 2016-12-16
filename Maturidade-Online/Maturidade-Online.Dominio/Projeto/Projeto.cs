using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    [Table("Projeto")]
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Caracteristica> Caracteristicas { get; set; }
        public virtual ICollection<SubtopicoEntidade> Subtopicos { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntidade Usuario { get; set; }

        public Projeto()
        {
            this.Subtopicos = new HashSet<SubtopicoEntidade>();
            this.Caracteristicas = new HashSet<Caracteristica>();
        }
    }
}