using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Tests.Core;
using Maturidade_Online.Dominio.Usuario;
using Maturidade_Online.Mock;

namespace Maturidade_Online.Tests.UsuarioTest
{
    [TestClass]
    public class UsuarioServicoTest
    {
        [TestMethod]
        public void BuscarPorUsuarioLoginFuncionando()
        {

            UsuarioServico usuarioServico = ServicoDeDependencia.CriarUsuarioServico();
            UsuarioRepositorioMock usuarioRepositorio = new UsuarioRepositorioMock();

            string email = "carlos@cwi.com.br";
            string senha = "crescer";

            UsuarioEntidade usuarioMockado = usuarioRepositorio.BuscarPorEmail(email);
            UsuarioEntidade usuarioEncontrado = usuarioServico.BuscarPorAutenticacao(email, senha);

            Assert.AreEqual(usuarioMockado.Id, usuarioEncontrado.Id);
            Assert.AreEqual(usuarioMockado.Permissao, usuarioEncontrado.Permissao);
        }

        [TestMethod]
        public void BuscarPorUsuarioLoginRejeitado()
        {

            UsuarioServico usuarioServico = ServicoDeDependencia.CriarUsuarioServico();

            string email = "carlos@cwi.com.br";
            string senha = "teste";

            UsuarioEntidade usuarioEncontrado = usuarioServico.BuscarPorAutenticacao(email, senha);

            Assert.IsNull(usuarioEncontrado);

        }

        [TestMethod]
        public void BuscarPorEmail()
        {
            UsuarioServico usuarioServico = ServicoDeDependencia.CriarUsuarioServico();
            UsuarioRepositorioMock usuarioRepositorio = new UsuarioRepositorioMock();

            string email = "carlos@cwi.com.br";
            UsuarioEntidade usuarioMockado = usuarioRepositorio.BuscarPorEmail(email);

            Assert.IsNotNull(usuarioMockado);

        }


    }

}
