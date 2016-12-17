using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class PilarRepositorioEF : RepositorioAbstratoEF<Pilar>, IPilarRepositorio
    {
        public PilarRepositorioEF(ContextoDeDadosEF contexto) : base(contexto)
        {
        }

        public override void Criar(Pilar pilar)
        {
            //base.Criar(entidade);
            contexto.Entry<Pilar>(pilar).State = EntityState.Added;
            contexto.SaveChanges();
        }

        public Pilar BuscarPorId(Pilar pilar)
        {
            return contexto.Pilar
                //.Include("caracteristicas")
                //.Include("subtopicos")
             .FirstOrDefault(p => p.Id == pilar.Id);
        }

    }
}
