using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio;
using System.Collections.Generic;
using FakeItEasy;

namespace Maturidade_Online.Tests
{
    [TestClass]
    public class PilarServicoTest
    {
        [TestMethod]
        public void PilarServicoPersistirIdZeroDeveAdicionar()
        {
            var repositorioFake = A.Fake<IPilarRepositorio>();

            var servico = new PilarServico(repositorioFake);
            var pilar = A.Fake<Pilar>();

            servico.Persistir(pilar);

            A.CallTo(() => repositorioFake.Criar(pilar))
                .MustHaveHappened();
        }

        [TestMethod]
        public void PilarServicoPersistirIdUmDeveEditar()
        {
            var repositorioFake = A.Fake<IPilarRepositorio>();

            var servico = new PilarServico(repositorioFake);
            var pilar = new Pilar() { Id = 1 };

            servico.Persistir(pilar);

            A.CallTo(() => repositorioFake.Editar(pilar))
                .MustHaveHappened();
        }

        [TestMethod]
        public void PilarServicoListarPilares()
        {
            var repositorioFake = A.Fake<IPilarRepositorio>();
            var servico = new PilarServico(repositorioFake);

            servico.Listar();

            A.CallTo(() => repositorioFake.Listar())
                .MustHaveHappened();
        }


        [TestMethod]
        public void PilarServicoRemoverPilar()
        {
            var repositorioFake = A.Fake<IPilarRepositorio>();

            var servico = new PilarServico(repositorioFake);
            var pilar = A.Fake<Pilar>();

            servico.Remover(pilar);

            A.CallTo(() => repositorioFake.Remover(pilar))
                .MustHaveHappened();

        }
    }
}
