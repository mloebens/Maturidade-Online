using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class PesquisarSubtopicosRespostaViewModel
    {
        public Projeto Projeto { get; set; }
        public ICollection<Subtopico> listaDeSubtopicos { get; set; }
    }
}