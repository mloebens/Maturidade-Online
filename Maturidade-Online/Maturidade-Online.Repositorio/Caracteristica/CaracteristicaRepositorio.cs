using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;
using LojaDeItens.Dominio.Configuracao;

namespace Maturidade_Online.Repositorio
{
    public class CaracteristicaRepositorio : RepositorioAbstrato<Caracteristica>, ICaracteristicaRepositorio
    {
        public CaracteristicaRepositorio(ContextoDeDados contexto) : base(contexto)
        {
        }

        public void Criar(Caracteristica caracteristica)
        {
            foreach (var subtopico in caracteristica.Subtopicos)
            {
                contexto.Subtopico.Attach(subtopico);
            }

            contexto.Entry<Caracteristica>(caracteristica).State = EntityState.Added;
            contexto.SaveChanges();
        }


        public override IEnumerable<Caracteristica> Listar()
        {
            contexto.Configuration.ProxyCreationEnabled = false;
            return contexto.Caracteristica.Include("Subtopicos").ToList();
        }

        public override void Editar(Caracteristica caracteristica)
        {
            var caracteristicaDaBase = this.BuscarPorId(caracteristica);
            //TODO injetar com inteface
            var subtopicoRepositorio = new SubtopicoRepositorio(contexto);
            var subtopicosParaRemover = subtopicoRepositorio.Listar(caracteristica);

            foreach (var subtopico in subtopicosParaRemover)
            {
                caracteristicaDaBase.Subtopicos.Remove(subtopico);
            }

            caracteristicaDaBase.Nome = caracteristica.Nome;
            var subtopicosDaBase = subtopicoRepositorio.Listar(caracteristica.Subtopicos);
            caracteristicaDaBase.Subtopicos = subtopicosDaBase;
            base.Editar(caracteristicaDaBase);
        }

        public ICollection<Caracteristica> Listar(ICollection<Caracteristica> caracteristicas)
        {
            var ids = caracteristicas.Select(_ => _.Id);

            return contexto.Caracteristica.Include("Subtopicos").Where(c => ids.Any(id => id == c.Id)).ToList();
        }

        public Caracteristica BuscarPorId(Caracteristica caracteristica)
        {
            return contexto.Caracteristica.FirstOrDefault(_ => _.Id == caracteristica.Id);
        }

        public ICollection<Caracteristica> Listar(Projeto projeto)
        {
            return contexto.Caracteristica.Where(s => s.Projetos.Any(c => c.Id == projeto.Id)).ToList();

        }

        public ICollection<Caracteristica> Listar(Paginacao paginacao)
        {
            return contexto.Caracteristica.OrderBy(_ => _.Nome).Skip((paginacao.PaginaDesejada * paginacao.QuantidadePorPagina)).Take(paginacao.QuantidadePorPagina).ToList();
        }

        public int QuantidadeTotal()
        {
            return contexto.Caracteristica.ToList().Count;
        }
    }
}
