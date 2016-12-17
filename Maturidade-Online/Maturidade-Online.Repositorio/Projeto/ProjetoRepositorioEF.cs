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
        public ProjetoRepositorioEF(ContextoDeDadosEF contexto) : base(contexto)
        {
        }

        public Projeto BuscarPorId(Projeto projeto)
        {
            return contexto.Projeto
                .Include("caracteristicas")
                .Include("subtopicos")
             .FirstOrDefault(p => p.Id == projeto.Id);
        }

        public override void Criar(Projeto projeto)
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

        public override void Editar(Projeto projeto)
        {

            CaracteristicaRepositorioEF caracteristicaRepositorio = new CaracteristicaRepositorioEF(contexto);
            SubtopicoRepositorioEF subtopicoRepositorio = new SubtopicoRepositorioEF(contexto);
            var caracteristicasDaBase = caracteristicaRepositorio.Listar(projeto.Caracteristicas);
            var subtopicosDaBase = subtopicoRepositorio.Listar(projeto.Subtopicos);

            projeto.Subtopicos = subtopicosDaBase;
            projeto.Caracteristicas = caracteristicasDaBase;


            base.Editar(projeto);
        }
    }
}
