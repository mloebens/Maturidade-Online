using Maturidade_Online.Dominio.Pilar;
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
    public class ContextoDeDados : DbContext
    {
        public ContextoDeDados() : base("MaturidadeOnlineCWI")
        {
        }

        public DbSet<PilarEntidade> Pilar { get; set; }
        public DbSet<SubtopicoEntidade> Subtopico { get; set; }
        public DbSet<UsuarioEntidade> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
