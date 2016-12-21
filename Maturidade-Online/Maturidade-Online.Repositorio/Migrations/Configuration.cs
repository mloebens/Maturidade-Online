namespace Maturidade_Online.Repositorio.Migrations
{
    using Dominio;
    using System;
    using System.Collections.Generic;
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

            Permissao administrador = new Permissao(){ Id = 1, Nome = "ADMINISTRADOR"};
            Permissao usuario = new Permissao() { Id = 1, Nome = "USUARIO" };

            context.Permissao.AddOrUpdate(
               p => p.Nome,
               administrador,
               usuario
               );


            Usuario usuario1 = new Usuario { Nome = "Victor", Email = "victor.eduardo@cwi.com.br", Permissao = administrador, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };
            Usuario usuario2 = new Usuario { Nome = "Maicon", Email = "maicon.loebens@cwi.com.br", Permissao = administrador, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };
            Usuario usuario3 = new Usuario { Nome = "Normal", Email = "usuario@normal.com.br", Permissao = usuario, Senha = "6f1d81c734062fe646d96eb97dfd1d9c" };

            context.Usuario.AddOrUpdate(
                p => p.Nome,
                usuario1,
                usuario2,
                usuario3
                );

            context.Pilar.AddOrUpdate(
                    p => p.Titulo,
                    new Pilar { Id = 1, Titulo = "Gerência de Configuração" },
                    new Pilar { Id = 2, Titulo = "Geração de Pacote" },
                    new Pilar { Id = 3, Titulo = "Testes" },
                    new Pilar { Id = 4, Titulo = "Performance" },
                    new Pilar { Id = 5, Titulo = "Segurança" },
                    new Pilar { Id = 6, Titulo = "Arquitetura" },
                    new Pilar { Id = 7, Titulo = "UX" },
                    new Pilar { Id = 8, Titulo = "Código" },
                    new Pilar { Id = 9, Titulo = "Banco de Dados" }
                );

            var subtopicos = new List<Subtopico>() {
                new Subtopico
                    {
                        Id = 1,
                        Nome = "Ferramentas de Controle de Versão",
                        Descricao = "",
                        Pontuacao = 1,
                        PilarId = 1
                    },
                new Subtopico
                {
                    Id = 2,
                    Nome = "Estratégia de Brenches bem Definida",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 1
                },
                new Subtopico
                {
                    Id = 3,
                    Nome = "Tags/Labels",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 1
                },
                new Subtopico
                {
                    Id = 4,
                    Nome = "Comentários em Commits",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 1
                },
                new Subtopico
                {
                    Id = 5,
                    Nome = "Commits por Funcionalidades",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 1
                },
                new Subtopico
                {
                    Id = 6,
                    Nome = "Publicação Automatizada",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 2
                },
                new Subtopico
                {
                    Id = 7,
                    Nome = "Deploys de Baixo Risco",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 2
                },
                new Subtopico
                {
                    Id = 8,
                    Nome = "Validações Automáticas",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 2
                },
                new Subtopico
                {
                    Id = 9,
                    Nome = "Fontes Integrados a cada Commit",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 2
                },
                new Subtopico
                {
                    Id = 10,
                    Nome = "Automatizados",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 3
                },
                new Subtopico
                {
                    Id = 11,
                    Nome = "Cobertura Plena na Camada de Domínio ",
                    Descricao = "",
                    Pontuacao = 4,
                    PilarId = 3
                },
                new Subtopico
                {
                    Id = 12,
                    Nome = "Execução via IC",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 3
                },
                new Subtopico
                {
                    Id = 13,
                    Nome = "Independência de Ambiente",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 3
                },
                new Subtopico
                {
                    Id = 14,
                    Nome = "Novo Teste a cada Bug ",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 3
                },
                new Subtopico
                {
                    Id = 15,
                    Nome = "Escritos em BDD",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 3
                },
                new Subtopico
                {
                    Id = 16,
                    Nome = "Testes de Stress",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 4
                },
                new Subtopico
                {
                    Id = 17,
                    Nome = "Como Requisito",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 4
                },
                new Subtopico
                {
                    Id = 18,
                    Nome = "Execução automatizada dos testes de Performance",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 4
                },
                new Subtopico
                {
                    Id = 19,
                    Nome = "Monitoramento de CPUs e Memória",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 4
                },
                new Subtopico
                {
                    Id = 20,
                    Nome = "Alerta de Riscos",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 4
                },
                new Subtopico
                {
                    Id = 21,
                    Nome = "OWASP Top 10",
                    Descricao = "",
                    Pontuacao = 5,
                    PilarId = 5
                },
                new Subtopico
                {
                    Id = 22,
                    Nome = "Testes automatizados de segurança",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 5
                },
                new Subtopico
                {
                    Id = 23,
                    Nome = "EVIL User nos cenários",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 5
                },
                new Subtopico
                {
                    Id = 24,
                    Nome = "Como requisito",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 5
                },
                new Subtopico
                {
                    Id = 25,
                    Nome = "Evolutiva",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 6
                },
                new Subtopico
                {
                    Id = 26,
                    Nome = "Modularizada",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 6
                },
                new Subtopico
                {
                    Id = 27,
                    Nome = "Escalável",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 6
                },
                new Subtopico
                {
                    Id = 28,
                    Nome = "Templates",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 6
                },
                new Subtopico
                {
                    Id = 29,
                    Nome = "Responsivo à Medições",
                    Descricao = "",
                    Pontuacao = 4,
                    PilarId = 7
                },
                new Subtopico
                {
                    Id = 30,
                    Nome = "Sob Medida",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 7
                },
                new Subtopico
                {
                    Id = 31,
                    Nome = "Templates",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 7
                },
                new Subtopico
                {
                    Id = 32,
                    Nome = "Prototipação",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 7
                },
                new Subtopico
                {
                    Id = 33,
                    Nome = "Code Review",
                    Descricao = "",
                    Pontuacao = 4,
                    PilarId = 8
                },
                new Subtopico
                {
                    Id = 34,
                    Nome = "Validações Automáticas - Complexidade e número de linhas",
                    Descricao = "",
                    Pontuacao = 3,
                    PilarId = 8
                },
                new Subtopico
                {
                    Id = 35,
                    Nome = "Validações Automáticas - Estilos e Boas Práticas",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 8
                },
                new Subtopico
                {
                    Id = 36,
                    Nome = "Padrões",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 8
                },
                new Subtopico
                {
                    Id = 37,
                    Nome = "Propriedade Coletiva",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 8
                },
                new Subtopico
                {
                    Id = 38,
                    Nome = "Logs e Políticas de Tratamento de Erros",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 8
                },
                new Subtopico
                {
                    Id = 39,
                    Nome = "Evitar Lógica de Negócio",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 9
                },
                new Subtopico
                {
                    Id = 40,
                    Nome = "Atualizado via IC",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 9
                },
                new Subtopico
                {
                    Id = 41,
                    Nome = "Integridade",
                    Descricao = "",
                    Pontuacao = 1,
                    PilarId = 9
                },
                new Subtopico
                {
                    Id = 42,
                    Nome = "Boas Práticas de ORM",
                    Descricao = "",
                    Pontuacao = 2,
                    PilarId = 9
                },
                new Subtopico
                {
                    Id = 43,
                    Nome = "Análise de Performance",
                    Descricao = "",
                    Pontuacao = 4,
                    PilarId = 9
                }
        };


            subtopicos.ForEach(s => context.Subtopico.AddOrUpdate(p => p.Nome, s ));

            var caracteristica1subtopico = new List<Subtopico>() { subtopicos[0], subtopicos[1] };
            var caracteristica2subtopico = new List<Subtopico>() { subtopicos[2], subtopicos[3] };

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
            var projeto1subtopicos = new List<Subtopico>() { caracteristica1subtopico[0], caracteristica1subtopico[1], caracteristica2subtopico[0], caracteristica2subtopico[1] };

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
