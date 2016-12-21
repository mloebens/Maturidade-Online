using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class CaracteristicaViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        public ICollection<Subtopico> Subtopicos { get; set; }

        public ICollection<Subtopico> ListaDeSubtopicos { get; set; }

        public ICollection<int> IdsSubtopicos { get; set; }
    }
}