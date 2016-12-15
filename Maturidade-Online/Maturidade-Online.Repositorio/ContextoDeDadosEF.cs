using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Dominio.Projeto;
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
        public ContextoDeDadosEF() : base("MaturidadeOnlineMaiconCasa")
        {
        }

        public DbSet<PilarEntidade> Pilar { get; set; }
        public DbSet<SubtopicoEntidade> Subtopico { get; set; }
        public DbSet<UsuarioEntidade> Usuario { get; set; }
        public DbSet<CaracteristicaEntidade> Caracteristica { get; set; }
        public DbSet<ProjetoEntidade> Projeto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CaracteristicaEntidade>()
                .HasMany(p => p.Subtopicos)
                .WithMany(s => s.Caracteristicas)
                .Map(c =>
                {
                    c.MapLeftKey("CaracteristicaId");
                    c.MapRightKey("SubtopicoId");
                    c.ToTable("CaracteristicaSubtopico");
                });

            modelBuilder.Entity<ProjetoEntidade>()
                .HasMany(p => p.Subtopicos)
                .WithMany(s => s.Projetos)
                .Map(c =>
                {
                    c.MapLeftKey("ProjetoId");
                    c.MapRightKey("SubtopicoId");
                    c.ToTable("ProjetoSubtopico");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
