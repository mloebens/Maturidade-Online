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
    public class ProjetoRepositorio : RepositorioAbstrato<Projeto>, IProjetoRepositorio
    {
        public ProjetoRepositorio(ContextoDeDados contexto) : base(contexto)
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
            CaracteristicaRepositorio caracteristicaRepositorio = new CaracteristicaRepositorio(contexto);
            SubtopicoRepositorio subtopicoRepositorio = new SubtopicoRepositorio(contexto);

            var subtopicosParaRemover = subtopicoRepositorio.Listar(projeto);
            var caracteristicasParaRemover = caracteristicaRepositorio.Listar(projeto);

            
            var projetoDaBase = this.BuscarPorId(projeto);

            foreach (var subtopico in subtopicosParaRemover)
            {
                projetoDaBase.Subtopicos.Remove(subtopico);
            }

            foreach (var caracteristica in caracteristicasParaRemover)
            {
                projetoDaBase.Caracteristicas.Remove(caracteristica);
            }

            var caracteristicasDaBase = caracteristicaRepositorio.Listar(projeto.Caracteristicas);
            var subtopicosDaBase = subtopicoRepositorio.Listar(projeto.Subtopicos);

            projetoDaBase.Nome = projeto.Nome;
            projetoDaBase.Subtopicos = subtopicosDaBase;
            projetoDaBase.Caracteristicas = caracteristicasDaBase;

            base.Editar(projetoDaBase);
        }

        public override IEnumerable<Projeto> Listar()
        {
            return contexto.Projeto
                .Include(i => i.Subtopicos.Select(s => s.Pilar))
                .ToList();
        }
    }
}
