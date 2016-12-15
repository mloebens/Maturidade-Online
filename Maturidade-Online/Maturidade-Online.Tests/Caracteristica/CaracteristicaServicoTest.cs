using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Tests.Core;
using System.Collections.Generic;

namespace Maturidade_Online.Tests.Caracteristica
{
    [TestClass]
    public class CaracteristicaServicoTest
    {
        [TestMethod]
        public void CaracteristicaServicoAdicionarCaracteristica()
        {
            CaracteristicaServico caracteristicaServico = ServicoDeDependencia.CriarCaracteristicaServico();
            CaracteristicaEntidade caracteristica = new CaracteristicaEntidade() { Id = 0, Nome = "teste" };
            int quantidadeDeCaracteristicaes = ((IList<CaracteristicaEntidade>)caracteristicaServico.Listar()).Count;
            caracteristicaServico.Persistir(caracteristica);

            Assert.AreEqual(quantidadeDeCaracteristicaes + 1, ((IList<CaracteristicaEntidade>)caracteristicaServico.Listar()).Count);
        }

        [TestMethod]
        public void CaracteristicaServicoEditarCaracteristica()
        {
            CaracteristicaServico caracteristicaServico = ServicoDeDependencia.CriarCaracteristicaServico();
            CaracteristicaEntidade caracteristica = new CaracteristicaEntidade() { Id = 10, Nome = "Teste 4", };
            int quantidadeDeCaracteristicaes = ((IList<CaracteristicaEntidade>)caracteristicaServico.Listar()).Count;
            caracteristicaServico.Persistir(caracteristica);

            Assert.AreEqual(quantidadeDeCaracteristicaes, ((IList<CaracteristicaEntidade>)caracteristicaServico.Listar()).Count);
        }

        [TestMethod]
        public void CaracteristicaServicoListarCaracteristicaes()
        {
            CaracteristicaServico caracteristicaServico = ServicoDeDependencia.CriarCaracteristicaServico();
            Assert.AreEqual(3, ((IList<CaracteristicaEntidade>)caracteristicaServico.Listar()).Count);
        }


        [TestMethod]
        public void CaracteristicaServicoRemoverCaracteristica()
        {
            CaracteristicaServico caracteristicaServico = ServicoDeDependencia.CriarCaracteristicaServico();

            caracteristicaServico.Remover(new CaracteristicaEntidade() { Id = 1, Nome = "Teste 1" });

            Assert.AreEqual(2, ((IList<CaracteristicaEntidade>)caracteristicaServico.Listar()).Count);
        }
    }
}
