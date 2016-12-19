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
            return contexto.Subtopico.Include("Pilar").ToList();

        }

        public ICollection<Subtopico> Listar(ICollection<Subtopico> subtopico)
        {
            var ids = subtopico.Select(_ => _.Id);

            return contexto.Subtopico.Where(c => ids.Any(id => id == c.Id)).ToList();
        }

        public ICollection<Subtopico> ListarComPilar(ICollection<Caracteristica> caracteristica)
        {
            var ids = caracteristica.Select(_ => _.Id);
            return contexto.Subtopico.Include("Pilar").Where(s => s.Caracteristicas.Any(c => ids.Any(i => i == c.Id))).ToList();
        }

        public ICollection<Subtopico> Listar(ICollection<Caracteristica> caracteristica)
        {
            var ids = caracteristica.Select(_ => _.Id);

            return contexto.Subtopico.Where(s => s.Caracteristicas.Any(c => ids.Any(i => i == c.Id))).ToList();
        }

        public ICollection<Subtopico> Listar(Caracteristica caracteristica)
        {
            return contexto.Subtopico.Where(s => s.Caracteristicas.Any(c => c.Id == caracteristica.Id)).ToList();
        }

        public ICollection<Subtopico> ListarPorPilar(int id)
        {
            return contexto.Subtopico.Where(s => s.PilarId == id).ToList();
        }

        public Subtopico BuscarPorId(Subtopico subtopico)
        {
            return contexto.Subtopico.FirstOrDefault(_ => _.Id == subtopico.Id);
        }

        public ICollection<Subtopico> Listar(Projeto projeto)
        {
            return contexto.Subtopico.Where(s => s.Projetos.Any(c => c.Id == projeto.Id)).ToList();
        }

        public ICollection<Subtopico> Listar(Pilar pilar)
        {
            return contexto.Subtopico.Where(s => s.PilarId == pilar.Id).ToList();
        }
    }
}
