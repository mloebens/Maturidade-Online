using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio;
using System.Collections.Generic;
using FakeItEasy;

namespace Maturidade_Online.Tests
{
    [TestClass]
    public class SubtopicoServicoTest
    {
        [TestMethod]
        public void SubtopicoServicoAdicionarSubtopico()
        {
            var subtopicoRepositorio = A.Fake<ISubtopicoRepositorio>();
            var subtopicoServico = new SubtopicoServico(subtopicoRepositorio);
            var subtopico = A.Fake<Subtopico>();
            subtopico.Id = 0;
            subtopicoServico.Persistir(subtopico);
            
            A.CallTo(() => subtopicoRepositorio.Criar(subtopico)).MustHaveHappened();
        }

        [TestMethod]
        public void SubtopicoServicoEditarSubtopico()
        {
            var subtopicoRepositorio = A.Fake<ISubtopicoRepositorio>();
            var subtopicoServico = new SubtopicoServico(subtopicoRepositorio);
            var subtopico = A.Fake<Subtopico>();
            subtopico.Id = 1;
            subtopicoServico.Persistir(subtopico);

            A.CallTo(() => subtopicoRepositorio.Editar(subtopico)).MustHaveHappened();
        }

        [TestMethod]
        public void SubtopicoServicoListarSubtopicoes()
        {
            var subtopicoRepositorio = A.Fake<ISubtopicoRepositorio>();
            var subtopicoServico = new SubtopicoServico(subtopicoRepositorio);

            subtopicoServico.Listar();
            A.CallTo(() => subtopicoRepositorio.Listar()).MustHaveHappened();
        }


        [TestMethod]
        public void SubtopicoServicoRemoverSubtopico()
        {
            var subtopicoRepositorio = A.Fake<ISubtopicoRepositorio>();
            var subtopicoServico = new SubtopicoServico(subtopicoRepositorio);
            var subtopico = A.Fake<Subtopico>();
            subtopico.Id = 1;
            subtopicoServico.Remover(subtopico);

            A.CallTo(() => subtopicoRepositorio.Remover(subtopico)).MustHaveHappened();
        }
    }
}
