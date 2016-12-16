using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio;
using System.Collections.Generic;
using FakeItEasy;

namespace Maturidade_Online.Tests
{
    [TestClass]
    public class CaracteristicaServicoTest
    {
        [TestMethod]
        public void CaracteristicaServicoAdicionarCaracteristica()
        {
            var repositorio = A.Fake<ICaracteristicaRepositorio>();
            var servico = new CaracteristicaServico(repositorio);
            var caracteristica = A.Fake<Caracteristica>();
            caracteristica.Id = 0;
            servico.Persistir(caracteristica);

            A.CallTo(() => repositorio.Criar(caracteristica)).MustHaveHappened();
        }

        [TestMethod]
        public void CaracteristicaServicoEditarCaracteristica()
        {
            var repositorio = A.Fake<ICaracteristicaRepositorio>();
            var servico = new CaracteristicaServico(repositorio);
            var caracteristica = A.Fake<Caracteristica>();
            caracteristica.Id = 1;

            servico.Persistir(caracteristica);

            A.CallTo(() => repositorio.Editar(caracteristica)).MustHaveHappened();
        }

        [TestMethod]
        public void CaracteristicaServicoListarCaracteristicaes()
        {
            var repositorio = A.Fake<ICaracteristicaRepositorio>();
            var servico = new CaracteristicaServico(repositorio);

            servico.Listar();
            A.CallTo(() => repositorio.Listar()).MustHaveHappened();
        }


        [TestMethod]
        public void CaracteristicaServicoRemoverCaracteristica()
        {
            var repositorio = A.Fake<ICaracteristicaRepositorio>();
            var servico = new CaracteristicaServico(repositorio);
            var subtopico = A.Fake<Caracteristica>();
            subtopico.Id = 1;
            servico.Remover(subtopico);

            A.CallTo(() => repositorio.Remover(subtopico)).MustHaveHappened();
        }
    }
}
