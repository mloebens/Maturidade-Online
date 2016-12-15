using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Tests.Core;
using Maturidade_Online.Dominio.Projeto;
using System.Collections.Generic;

namespace Maturidade_Online.Tests.Projeto
{
    [TestClass]
    public class ProjetoServicoTest
    {

        [TestMethod]
        public void ProjetoServicoBuscarProjetoPorId()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            ProjetoEntidade projeto = new ProjetoEntidade() { Id = 1 };
            var projetoEncontrado = projetoServico.BuscarPorId(projeto);

            Assert.IsNotNull(projetoEncontrado);
        }

        [TestMethod]
        public void ProjetoServicoAdicionarProjeto()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            ProjetoEntidade projeto = new ProjetoEntidade() { Id = 0 };
            int quantidadeDeProjetoes = ((IList<ProjetoEntidade>)projetoServico.Listar()).Count;
            projetoServico.Persistir(projeto);

            Assert.AreEqual(quantidadeDeProjetoes + 1, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }

        [TestMethod]
        public void ProjetoServicoEditarProjeto()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            ProjetoEntidade projeto = new ProjetoEntidade() { Id = 10 };
            int quantidadeDeProjetoes = ((IList<ProjetoEntidade>)projetoServico.Listar()).Count;
            projetoServico.Persistir(projeto);

            Assert.AreEqual(quantidadeDeProjetoes, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }

        [TestMethod]
        public void ProjetoServicoListarProjetoes()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            Assert.AreEqual(3, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }


        [TestMethod]
        public void ProjetoServicoRemoverProjeto()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            projetoServico.Remover(new ProjetoEntidade() { Id = 1 });

            Assert.AreEqual(2, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }
    }
}
