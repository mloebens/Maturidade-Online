using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio.Subtopico
{
    public class SubtopicoRepositorioEF : RepositorioAbstratoEF<SubtopicoEntidade>, ISubtopicoRepositorio
    {
        public override IEnumerable<SubtopicoEntidade> Listar()
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                contexto.Configuration.ProxyCreationEnabled = false;
                return contexto.Subtopico.Include("Pilares").ToList();
            }
        }


        public override void Editar(SubtopicoEntidade subtopico)
        {
            SubtopicoRepositorio repositorio = new SubtopicoRepositorio();
            repositorio.AlterarVinculos(subtopico);
            base.Editar(subtopico);
        }
    }
}
