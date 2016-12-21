using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class PilarListagemViewModel
    {

        public int PaginaAtual { get; set; }
        public int QuantidadePorPagina { get; set; }

        public int QuantidadeTotal { get; set; }

        public List<PilarViewModel> Pilares { get; set; }

        public bool UltimaPagina
        {
            get
            {
                return QuantidadeTotal - (this.QuantidadePorPagina * (this.PaginaAtual + 1)) <= 0;
            }
        }
    }
}