using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class SubtopicoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(60)]
        public string Nome { get; set; }

        [MaxLength(4000)]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Pontuação")]
        public int Pontuacao { get; set; }

        [Required]
        public int PilarId { get; set; }

        public Pilar Pilar { get; set; }

        public ICollection<Pilar> Pilares { get; set; }
    }
}