using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class ContextoDeDadosEF : DbContext
    {
        public ContextoDeDadosEF() : base("MaturidadeOnlineCWI")
        {
        }

        public DbSet<Pilar> Pilar { get; set; }
        public DbSet<Subtopico> Subtopico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
