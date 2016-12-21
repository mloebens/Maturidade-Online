using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class PilarViewModel
    {

        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        public ICollection<Subtopico> Subtopicos { get; set; }

    }
}