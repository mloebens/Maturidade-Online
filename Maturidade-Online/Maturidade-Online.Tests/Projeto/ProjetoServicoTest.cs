using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Tests.Core;
using Maturidade_Online.Dominio.Projeto;
using System.Collections.Generic;
using Maturidade_Online.Dominio.Usuario;

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
            UsuarioServico usuarioServico = ServicoDeDependencia.CriarUsuarioServico();
            ProjetoEntidade projeto = new ProjetoEntidade() { Id = 0 };
            int quantidadeDeProjetoes = ((IList<ProjetoEntidade>)projetoServico.Listar()).Count;
            projetoServico.Persistir(projeto, "victor.eduardo@cwi.com.br");

            Assert.AreEqual(quantidadeDeProjetoes + 1, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }

        /* Não da para testar pois verifica o usuario autenticado
        [TestMethod]
        public void ProjetoServicoEditarProjeto()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            UsuarioServico usuarioServico = ServicoDeDependencia.CriarUsuarioServico();
            ProjetoEntidade projeto = new ProjetoEntidade() { Id = 1, Usuario = new UsuarioEntidade() { Id = 1, Email = "victor.eduardo@cwi.com.br", Permissao = Permissao.USUARIO } };
            int quantidadeDeProjetoes = ((IList<ProjetoEntidade>)projetoServico.Listar()).Count;
            projetoServico.Persistir(projeto, "victor.eduardo@cwi.com.br");

            Assert.AreEqual(quantidadeDeProjetoes, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }*/

        [TestMethod]
        public void ProjetoServicoListarProjetoes()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            Assert.AreEqual(3, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }

        /* Não da para testar pois verifica o usuario autenticado
        [TestMethod]
        public void ProjetoServicoRemoverProjeto()
        {
            ProjetoServico projetoServico = ServicoDeDependencia.CriarProjetoServico();
            projetoServico.Remover(new ProjetoEntidade() { Id = 1, Usuario = new UsuarioEntidade() { Id = 1, Email = "victor.eduardo@cwi.com.br", Permissao Permissao.USUARIO } }, "victor.eduardo@cwi.com.br");

            Assert.AreEqual(2, ((IList<ProjetoEntidade>)projetoServico.Listar()).Count);
        }*/
    }
}
