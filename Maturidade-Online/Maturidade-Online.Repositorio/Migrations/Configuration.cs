namespace Maturidade_Online.Repositorio.Migrations
{
    using Dominio.Pilar;
    using Dominio.Subtopico;
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
                    new PilarEntidade { Titulo = "Qualidade" }
                );

            context.Subtopico.AddOrUpdate(
                p => p.Nome,
                new SubtopicoEntidade
                {
                    Nome = "teste1",
                    Descricao = "Nenhuma",
                    Pontuacao = 3,
                    PilarEntidadeId = 1
                },
                new SubtopicoEntidade
                {
                    Nome = "teste2",
                    Descricao = "Nenhuma",
                    Pontuacao = 5,
                    PilarEntidadeId = 1
                },
                new SubtopicoEntidade
                {
                    Nome = "teste3",
                    Descricao = "Nenhuma",
                    Pontuacao = 3,
                    PilarEntidadeId = 2
                },
                new SubtopicoEntidade
                {
                    Nome = "teste4",
                    Descricao = "Nenhuma",
                    Pontuacao = 5,
                    PilarEntidadeId = 3
                }
            );

        }
    }
}
