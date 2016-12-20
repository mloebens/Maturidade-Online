using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class ProjetoListarPilarViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal? Percentual { get; set; }

        public string cor
        {
            get
            {
                if (this.Percentual < 26)
                {
                    return "progress-bar-danger";
                }
                if (this.Percentual >= 76)
                {
                    return "progress-bar-success";
                }
                return "progress-bar-warning";
            }
        }
    }
}