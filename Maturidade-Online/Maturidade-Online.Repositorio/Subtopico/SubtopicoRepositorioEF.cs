using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class SubtopicoRepositorioEF : RepositorioAbstratoEF<Subtopico>, ISubtopicoRepositorio
    {
        public SubtopicoRepositorioEF(ContextoDeDadosEF contexto) : base(contexto)
        {
        }

        public override IEnumerable<Subtopico> Listar()
        {
            contexto.Configuration.ProxyCreationEnabled = false;
            return contexto.Subtopico.Include("Pilares").ToList();

        }


        public override void Editar(Subtopico subtopico)
        {
            SubtopicoRepositorio repositorio = new SubtopicoRepositorio();
            repositorio.AlterarVinculos(subtopico);
            base.Editar(subtopico);
        }
    }
}
