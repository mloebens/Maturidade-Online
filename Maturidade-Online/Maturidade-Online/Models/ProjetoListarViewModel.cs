using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class ProjetoListarViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public IList<ProjetoListarPilarViewModel> Pilares { get; set; }
        public int CriadorId { get; set; }

    }
}