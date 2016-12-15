using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Tests.Core;
using System.Collections.Generic;

namespace Maturidade_Online.Tests.Subtopico
{
    [TestClass]
    public class SubtopicoServicoTest
    {
        [TestMethod]
        public void SubtopicoServicoAdicionarSubtopico()
        {
            SubtopicoServico subtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();
            SubtopicoEntidade subtopico = new SubtopicoEntidade() { Id = 0, Nome = "teste" };
            int quantidadeDeSubtopicoes = ((IList<SubtopicoEntidade>)subtopicoServico.Listar()).Count;
            subtopicoServico.Persistir(subtopico);

            Assert.AreEqual(quantidadeDeSubtopicoes + 1, ((IList<SubtopicoEntidade>)subtopicoServico.Listar()).Count);
        }

        [TestMethod]
        public void SubtopicoServicoEditarSubtopico()
        {
            SubtopicoServico subtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();
            SubtopicoEntidade subtopico = new SubtopicoEntidade() { Id = 10, Nome = "Teste 3", Descricao = "bla bla", Pontuacao = 20  };
            int quantidadeDeSubtopicoes = ((IList<SubtopicoEntidade>)subtopicoServico.Listar()).Count;
            subtopicoServico.Persistir(subtopico);

            Assert.AreEqual(quantidadeDeSubtopicoes, ((IList<SubtopicoEntidade>)subtopicoServico.Listar()).Count);
        }

        [TestMethod]
        public void SubtopicoServicoListarSubtopicoes()
        {
            SubtopicoServico subtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();
            Assert.AreEqual(3, ((IList<SubtopicoEntidade>)subtopicoServico.Listar()).Count);
        }


        [TestMethod]
        public void SubtopicoServicoRemoverSubtopico()
        {
            SubtopicoServico subtopicoServico = ServicoDeDependencia.CriarSubtopicoServico();
            subtopicoServico.Remover(new SubtopicoEntidade() { Id = 1, Nome = "Teste 1", Descricao = "bla bla", PilarEntidadeId = 1, Pontuacao = 20 });

            Assert.AreEqual(2, ((IList<SubtopicoEntidade>)subtopicoServico.Listar()).Count);
        }
    }
}
