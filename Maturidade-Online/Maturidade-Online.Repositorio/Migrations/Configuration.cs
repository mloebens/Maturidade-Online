namespace Maturidade_Online.Repositorio.Migrations
{
    using Dominio.Pilar;
    using Dominio.Subtopico;
    using Dominio.Usuario;
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

            context.Usuario.AddOrUpdate(
                p => p.Nome,
                new UsuarioEntidade { Nome = "Victor", Email = "victor.eduardo@cwi.com.br", Permissao = Permissao.ADMINISTRADOR, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" },
                new UsuarioEntidade { Nome = "Maicon", Email = "maicon.loebens@cwi.com.br", Permissao = Permissao.ADMINISTRADOR, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" },
                new UsuarioEntidade { Nome = "Normal", Email = "usuario@normal.com.br", Permissao = Permissao.USUARIO, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" }
                );

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
