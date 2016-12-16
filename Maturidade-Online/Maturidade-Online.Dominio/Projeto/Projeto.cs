using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Caracteristica> Caracteristicas { get; set; }
        public virtual ICollection<Subtopico> Subtopicos { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Projeto()
        {
            this.Subtopicos = new HashSet<Subtopico>();
            this.Caracteristicas = new HashSet<Caracteristica>();
        }
    }
}