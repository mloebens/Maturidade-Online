using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Pilar
{
    [Table("Pilar")]
    public class PilarEntidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}
