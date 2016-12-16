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
    public class ProjetoRepositorioEF : RepositorioAbstratoEF<Projeto>, IProjetoRepositorio
    {
        public Projeto BuscarPorId(Projeto projeto)
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                return contexto.Projeto
                    .Include("caracteristicas")
                    .Include("subtopicos")
                 .FirstOrDefault(p => p.Id == projeto.Id);
            }
        }

        public override void Criar(Projeto projeto)
        {
            using (var contexto = new ContextoDeDadosEF())
            {

                //vincula os valore dos relacionamentos com os já existentes na base
                //evitando a criação de novos valores
                foreach (var caracteristica in projeto.Caracteristicas)
                {
                    contexto.Caracteristica.Attach(caracteristica);
                }
                foreach (var subtopico in projeto.Subtopicos)
                {
                    contexto.Subtopico.Attach(subtopico);
                }

                contexto.Entry<Projeto>(projeto).State = EntityState.Added;
                contexto.SaveChanges();
            }
        }

        public override void Editar(Projeto projeto)
        {
            ProjetoRepositorio repositorio = new ProjetoRepositorio();
            repositorio.AlterarVinculos(projeto);
            base.Editar(projeto);
        }
    }
}
