namespace Maturidade_Online.Repositorio.Migrations
{
    using Dominio.Pilar;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Maturidade_Online.Repositorio.ContextoDeDados>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Maturidade_Online.Repositorio.ContextoDeDados context)
        {

            context.Pilar.AddOrUpdate(
                    p => p.Titulo,
                    new PilarEntidade { Titulo = "Infraestrutura" },
                    new PilarEntidade { Titulo = "Gestão" },
                    new PilarEntidade { Titulo = "Qualidade"}
                );

        }
    }
}
