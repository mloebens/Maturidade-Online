using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maturidade_Online.Dominio.Abstrato;
using System.Data.Entity;

namespace Maturidade_Online.Repositorio.Abstrato
{
    public abstract class RepositorioAbstratoEF<T> : IRepositorio<T> where T : class
    {

        protected ContextoDeDadosEF contexto;

        public RepositorioAbstratoEF(ContextoDeDadosEF contexto)
        {
            this.contexto = contexto;
        }

        public virtual void Criar(T entidade)
        {
            contexto.Entry<T>(entidade).State = EntityState.Added;
            contexto.SaveChanges();
        }

        public virtual void Editar(T entidade)
        {
            contexto.Entry<T>(entidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public virtual IEnumerable<T> Listar()
        {
            return contexto.Set<T>().ToList();
        }

        public void Remover(T entidade)
        {
            contexto.Entry<T>(entidade).State = EntityState.Deleted;
            contexto.SaveChanges();
        }
    }
}
