using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class CaracteristicaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Subtopico> Subtopicos { get; set; }
    }
}