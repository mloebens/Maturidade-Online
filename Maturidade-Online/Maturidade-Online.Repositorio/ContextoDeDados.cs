using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class ContextoDeDados : DbContext
    {
        public ContextoDeDados() : base("MaturidadeOnlineMaiconCasa")
        {
        }

        public DbSet<Pilar> Pilar { get; set; }
        public DbSet<Subtopico> Subtopico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Permissao> Permissao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Pilar>()
                .Property(e => e.Id)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<Permissao>()
                .Property(e => e.Id)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Id)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<Projeto>()
                .Property(e => e.Id)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<Projeto>()
                .Property(e => e.UsuarioId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));


            modelBuilder.Entity<Subtopico>()
                .Property(e => e.Id)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<Subtopico>()
                .Property(e => e.PilarId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<Caracteristica>()
                .Property(e => e.Id)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));



            base.OnModelCreating(modelBuilder);
        }
    }
}
