using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio.Usuario;
using FakeItEasy;
using Maturidade_Online.Dominio.Infraestrutura;
using Maturidade_Online.Infraestrutura;
using System.Collections.Generic;

namespace Maturidade_Online.Tests.UsuarioTest
{
    [TestClass]
    public class UsuarioServicoTest
    {
        [TestMethod]
        public void UsuarioBuscarPorAutenticacao()
        {

            var repositorio = A.Fake<IUsuarioRepositorio>();
            var usuario = A.Fake<UsuarioEntidade>();
            var criptografia = new ServicoDeCriptografia();
            var servico = new UsuarioServico(repositorio, criptografia);

            usuario.Email = "teste@cwi.com.br";
            usuario.Senha = "teste";

            A.CallTo(() => repositorio.BuscarPorEmail(usuario)).Returns(new UsuarioEntidade {Email = "teste@cwi.com.br", Senha = "698dc19d489c4e4db73e28a713eab07b" } );

            var usuarioLogado = servico.BuscarPorAutenticacao(usuario);

            A.CallTo(() => repositorio.BuscarPorEmail(usuario)).MustHaveHappened();
            Assert.IsNotNull(usuarioLogado);
        }

        [TestMethod]
        public void BuscarPorUsuarioAutenticadoFalhando()
        {
            var repositorio = A.Fake<IUsuarioRepositorio>();
            var usuario = A.Fake<UsuarioEntidade>();
            var criptografia = new ServicoDeCriptografia();
            var servico = new UsuarioServico(repositorio, criptografia);

            usuario.Email = "teste@cwi.com.br";
            usuario.Senha = "teste1";

            A.CallTo(() => repositorio.BuscarPorEmail(usuario)).Returns(new UsuarioEntidade { Email = "teste@cwi.com.br", Senha = "698dc19d489c4e4db73e28a713eab07b" });

            var usuarioLogado = servico.BuscarPorAutenticacao(usuario);

            A.CallTo(() => repositorio.BuscarPorEmail(usuario)).MustHaveHappened();
            Assert.IsNull(usuarioLogado);

        }

        [TestMethod]
        public void UsuarioBuscarPorEmail()
        {
            var repositorio = A.Fake<IUsuarioRepositorio>();
            var usuario = A.Fake<UsuarioEntidade>();
            var criptografia = new ServicoDeCriptografia();
            var servico = new UsuarioServico(repositorio, criptografia);

            usuario.Email = "teste@cwi.com.br";

            A.CallTo(() => repositorio.BuscarPorEmail(usuario)).Returns(new UsuarioEntidade { Email = "teste@cwi.com.br" });

            var usuarioLogado = servico.BuscarPorEmail(usuario);

            A.CallTo(() => repositorio.BuscarPorEmail(usuario)).MustHaveHappened();
            Assert.IsNotNull(usuarioLogado);
        }
    }
}
