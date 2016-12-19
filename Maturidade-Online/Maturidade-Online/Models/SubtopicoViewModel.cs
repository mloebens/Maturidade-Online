using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class SubtopicoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Pontuacao { get; set; }

        [Required]
        public int PilarId { get; set; }

        public Pilar Pilar { get; set; }

        public ICollection<Pilar> Pilares { get; set; }
    }
}