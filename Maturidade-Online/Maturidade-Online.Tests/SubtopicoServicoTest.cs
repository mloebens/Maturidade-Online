using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Tests.Core;
using System.Collections.Generic;

namespace Maturidade_Online.Tests
{
    [TestClass]
    public class SubtopicoServicoTest
    {
        [TestMethod]
        public void SubtopicoServicoAdicionarSubtopico()
        {
            SubtopicoServico SubtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();
            SubtopicoEntidade Subtopico = new SubtopicoEntidade() { Id = 0, Nome = "teste" };

            int quantidadeDeSubtopicoes = ((IList<SubtopicoEntidade>)SubtopicoServico.Listar()).Count;
            SubtopicoServico.Persistir(Subtopico);

            Assert.AreEqual(quantidadeDeSubtopicoes + 1, ((IList<SubtopicoEntidade>)SubtopicoServico.Listar()).Count);
        }

        [TestMethod]
        public void SubtopicoServicoEditarSubtopico()
        {
            SubtopicoServico SubtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();
            SubtopicoEntidade Subtopico = new SubtopicoEntidade() { Id = 10, Nome = "Teste 3", Descricao = "bla bla", Pontuacao = 20  };

            int quantidadeDeSubtopicoes = ((IList<SubtopicoEntidade>)SubtopicoServico.Listar()).Count;
            SubtopicoServico.Persistir(Subtopico);

            Assert.AreEqual(quantidadeDeSubtopicoes, ((IList<SubtopicoEntidade>)SubtopicoServico.Listar()).Count);
        }

        [TestMethod]
        public void SubtopicoServicoListarSubtopicoes()
        {
            SubtopicoServico SubtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();

            SubtopicoServico.Listar();

            Assert.AreEqual(3, ((IList<SubtopicoEntidade>)SubtopicoServico.Listar()).Count);
        }


        [TestMethod]
        public void SubtopicoServicoRemoverSubtopico()
        {
            SubtopicoServico SubtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();

            SubtopicoServico.Remover(new SubtopicoEntidade() { Id = 1, Nome = "Teste 1", Descricao = "bla bla", PilarEntidadeId = 1, Pontuacao = 20 });

            Assert.AreEqual(2, ((IList<SubtopicoEntidade>)SubtopicoServico.Listar()).Count);
        }
    }
}
