using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio;
using System.Collections.Generic;
using Maturidade_Online.Dominio.Usuario;
using FakeItEasy;

namespace Maturidade_Online.Tests
{
    [TestClass]
    public class ProjetoServicoTest
    {

        [TestMethod]
        public void ProjetoServicoBuscarProjetoPorId()
        {
            var repositorio = A.Fake<IProjetoRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var servico = A.Fake<ProjetoServico>((x => x.WithArgumentsForConstructor(() => new ProjetoServico(repositorio, usuarioRepositorio))));
            var projeto = A.Fake<Projeto>();

            var projetoEncontrado = servico.BuscarPorId(projeto);

            A.CallTo(() => repositorio.BuscarPorId(projeto)).MustHaveHappened();
        }

        [TestMethod]
        public void ProjetoServicoAdicionarProjeto()
        {
            var repositorio = A.Fake<IProjetoRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var servico = A.Fake<ProjetoServico>((x => x.WithArgumentsForConstructor(() => new ProjetoServico(repositorio, usuarioRepositorio))));
            var projeto = A.Fake<Projeto>();
            var usuario = A.Fake<UsuarioEntidade>();

            servico.Persistir(projeto, usuario);

            A.CallTo(() => repositorio.Criar(projeto)).MustHaveHappened();
        }

        [TestMethod]
        public void ProjetoServicoListarProjetoes()
        {
            var repositorio = A.Fake<IProjetoRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var servico = A.Fake<ProjetoServico>((x => x.WithArgumentsForConstructor(() => new ProjetoServico(repositorio, usuarioRepositorio))));
            var projeto = A.Fake<Projeto>();

            servico.Listar();

            A.CallTo(() => repositorio.Listar()).MustHaveHappened();
        }
    }
}
