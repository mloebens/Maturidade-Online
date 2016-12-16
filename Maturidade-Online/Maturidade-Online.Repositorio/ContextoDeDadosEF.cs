using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Dominio;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Dominio.Usuario;
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

        public DbSet<PilarEntidade> Pilar { get; set; }
        public DbSet<SubtopicoEntidade> Subtopico { get; set; }
        public DbSet<UsuarioEntidade> Usuario { get; set; }
        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Caracteristica>()
                .HasMany(p => p.Subtopicos)
                .WithMany(s => s.Caracteristicas)
                .Map(c =>
                {
                    c.MapLeftKey("CaracteristicaId");
                    c.MapRightKey("SubtopicoId");
                    c.ToTable("CaracteristicaSubtopico");
                });

            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Subtopicos)
                .WithMany(s => s.Projetos)
                .Map(c =>
                {
                    c.MapLeftKey("ProjetoId");
                    c.MapRightKey("SubtopicoId");
                    c.ToTable("ProjetoSubtopico");
                });

            modelBuilder.Entity<Projeto>()
               .HasMany(p => p.Caracteristicas)
               .WithMany(s => s.Projetos)
               .Map(c =>
               {
                   c.MapLeftKey("ProjetoId");
                   c.MapRightKey("CaracteristicaId");
                   c.ToTable("ProjetoCaracteristica");
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
