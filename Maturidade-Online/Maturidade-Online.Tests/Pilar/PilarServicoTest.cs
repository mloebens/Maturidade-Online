using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Tests.Core;
using System.Collections.Generic;

namespace Maturidade_Online.Tests.Pilar
{
    [TestClass]
    public class PilarServicoTest
    {
        [TestMethod]
        public void PilarServicoAdicionarPilar()
        {
            PilarServico pilarServico = ServicoDeDependencia.CriarPilarServico();
            PilarEntidade pilar = new PilarEntidade() { Id = 0, Titulo = "teste" };

            int quantidadeDePilares = ((IList<PilarEntidade>)pilarServico.Listar()).Count;
            pilarServico.Persistir(pilar);

            Assert.AreEqual(quantidadeDePilares + 1, ((IList<PilarEntidade>)pilarServico.Listar()).Count);
        }

        [TestMethod]
        public void PilarServicoEditarPilar()
        {
            PilarServico pilarServico = ServicoDeDependencia.CriarPilarServico();
            PilarEntidade pilar = new PilarEntidade() { Id = 10, Titulo = "teste" };

            int quantidadeDePilares = ((IList<PilarEntidade>)pilarServico.Listar()).Count;
            pilarServico.Persistir(pilar);

            Assert.AreEqual(quantidadeDePilares, ((IList<PilarEntidade>)pilarServico.Listar()).Count);
        }

        [TestMethod]
        public void PilarServicoListarPilares()
        {
            PilarServico pilarServico = ServicoDeDependencia.CriarPilarServico();
            Assert.AreEqual(3, ((IList<PilarEntidade>)pilarServico.Listar()).Count);
        }


        [TestMethod]
        public void PilarServicoRemoverPilar()
        {
            PilarServico pilarServico = ServicoDeDependencia.CriarPilarServico();
            pilarServico.Remover(new PilarEntidade() { Id = 2, Titulo = "Qualidade" });

            Assert.AreEqual(2, ((IList<PilarEntidade>)pilarServico.Listar()).Count);
        }
    }
}
