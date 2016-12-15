namespace Maturidade_Online.Repositorio.Migrations
{
    using Dominio.Caracteristica;
    using Dominio.Pilar;
    using Dominio.Projeto;
    using Dominio.Subtopico;
    using Dominio.Usuario;
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

            UsuarioEntidade usuario1 = new UsuarioEntidade { Nome = "Victor", Email = "victor.eduardo@cwi.com.br", Permissao = Permissao.ADMINISTRADOR, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };
            UsuarioEntidade usuario2 = new UsuarioEntidade { Nome = "Maicon", Email = "maicon.loebens@cwi.com.br", Permissao = Permissao.ADMINISTRADOR, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };
            UsuarioEntidade usuario3 = new UsuarioEntidade { Nome = "Normal", Email = "usuario@normal.com.br", Permissao = Permissao.USUARIO, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };

            context.Usuario.AddOrUpdate(
                p => p.Nome,
                usuario1,
                usuario2,
                usuario3
                );

            context.Pilar.AddOrUpdate(
                    p => p.Titulo,
                    new PilarEntidade { Id = 1, Titulo = "Infraestrutura" },
                    new PilarEntidade { Id = 2, Titulo = "Gestão" },
                    new PilarEntidade { Id = 3, Titulo = "Qualidade" }
                );


            SubtopicoEntidade subtopico1 = new SubtopicoEntidade
            {
                Id = 1,
                Nome = "subtopico1",
                Descricao = "Nenhuma",
                Pontuacao = 3,
                PilarEntidadeId = 1
            };
            SubtopicoEntidade subtopico2 = new SubtopicoEntidade
            {
                Id = 2,
                Nome = "subtopico2",
                Descricao = "Nenhuma",
                Pontuacao = 5,
                PilarEntidadeId = 1
            };

            SubtopicoEntidade subtopico3 = new SubtopicoEntidade
            {
                Id = 3,
                Nome = "subtopico3",
                Descricao = "Nenhuma",
                Pontuacao = 3,
                PilarEntidadeId = 2
            };

            SubtopicoEntidade subtopico4 = new SubtopicoEntidade
            {
                Id = 4,
                Nome = "subtopico4",
                Descricao = "Nenhuma",
                Pontuacao = 5,
                PilarEntidadeId = 3
            };

            context.Subtopico.AddOrUpdate(
                p => p.Nome,
                subtopico1,
                subtopico2,
                subtopico3,
                subtopico4
            );

            var caracteristica1subtopico = new List<SubtopicoEntidade>() { subtopico1, subtopico2 };
            var caracteristica2subtopico = new List<SubtopicoEntidade>() { subtopico3, subtopico4 };

            CaracteristicaEntidade caracteristica1 = new CaracteristicaEntidade()
            {
                Id = 1,
                Nome = "Caracteristica1",
                Subtopicos = caracteristica1subtopico
            };

            CaracteristicaEntidade caracteristica2 = new CaracteristicaEntidade()
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

            var projeto1Caracteristicas = new List<CaracteristicaEntidade>() { caracteristica1, caracteristica2 };
            var projeto1subtopicos = new List<SubtopicoEntidade>() { subtopico1, subtopico2, subtopico3, subtopico4 };

            ProjetoEntidade projeto1 = new ProjetoEntidade()
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
