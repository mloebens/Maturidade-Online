namespace Maturidade_Online.Repositorio.Migrations
{
    using Dominio;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Maturidade_Online.Repositorio.ContextoDeDadosEF>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Maturidade_Online.Repositorio.ContextoDeDadosEF context)
        {

            Usuario usuario1 = new Usuario { Nome = "Victor", Email = "victor.eduardo@cwi.com.br", Permissao = Permissao.ADMINISTRADOR, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };
            Usuario usuario2 = new Usuario { Nome = "Maicon", Email = "maicon.loebens@cwi.com.br", Permissao = Permissao.ADMINISTRADOR, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };
            Usuario usuario3 = new Usuario { Nome = "Normal", Email = "usuario@normal.com.br", Permissao = Permissao.USUARIO, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };

            context.Usuario.AddOrUpdate(
                p => p.Nome,
                usuario1,
                usuario2,
                usuario3
                );

            context.Pilar.AddOrUpdate(
                    p => p.Titulo,
                    new Pilar { Id = 1, Titulo = "Infraestrutura" },
                    new Pilar { Id = 2, Titulo = "Gestão" },
                    new Pilar { Id = 3, Titulo = "Qualidade" }
                );


            Subtopico subtopico1 = new Subtopico
            {
                Id = 1,
                Nome = "subtopico1",
                Descricao = "Nenhuma",
                Pontuacao = 3,
                PilarId = 1
            };
            Subtopico subtopico2 = new Subtopico
            {
                Id = 2,
                Nome = "subtopico2",
                Descricao = "Nenhuma",
                Pontuacao = 5,
                PilarId = 1
            };

            Subtopico subtopico3 = new Subtopico
            {
                Id = 3,
                Nome = "subtopico3",
                Descricao = "Nenhuma",
                Pontuacao = 3,
                PilarId = 2
            };

            Subtopico subtopico4 = new Subtopico
            {
                Id = 4,
                Nome = "subtopico4",
                Descricao = "Nenhuma",
                Pontuacao = 5,
                PilarId = 3
            };

            context.Subtopico.AddOrUpdate(
                p => p.Nome,
                subtopico1,
                subtopico2,
                subtopico3,
                subtopico4
            );

            var caracteristica1subtopico = new List<Subtopico>() { subtopico1, subtopico2 };
            var caracteristica2subtopico = new List<Subtopico>() { subtopico3, subtopico4 };

            Caracteristica caracteristica1 = new Caracteristica()
            {
                Id = 1,
                Nome = "Caracteristica1",
                Subtopicos = caracteristica1subtopico
            };

            Caracteristica caracteristica2 = new Caracteristica()
            {
                Id = 2,
                Nome = "Caracteristica2",
                Subtopicos = caracteristica2subtopico
            };

            context.Caracteristica.AddOrUpdate(
                p => p.Nome,
                caracteristica1,
                caracteristica2
            );

            var projeto1Caracteristicas = new List<Caracteristica>() { caracteristica1, caracteristica2 };
            var projeto1subtopicos = new List<Subtopico>() { subtopico1, subtopico2, subtopico3, subtopico4 };

            Projeto projeto1 = new Projeto()
            {
                Id = 1,
                Nome = "Projeto1",
                Caracteristicas = projeto1Caracteristicas,
                Subtopicos = projeto1subtopicos,
                Usuario = usuario1
            };

            context.Projeto.AddOrUpdate(
                p => p.Nome,
                projeto1
            );
        }
    }
}
