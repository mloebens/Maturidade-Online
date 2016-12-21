using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeItens.Dominio.Configuracao
{
    public class Paginacao
    {
        public int PaginaDesejada { get; set; }
        public int QuantidadePorPagina { get; set; }
    }
}