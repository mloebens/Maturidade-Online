using LojaDeItens.Dominio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class ProjetoServico
    {
        private IProjetoRepositorio projetoRepositorio;
        private IUsuarioRepositorio usuarioRepositorio;

        public ProjetoServico(IProjetoRepositorio projetoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            this.projetoRepositorio = projetoRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public Projeto BuscarPorId(Projeto projeto)
        {
            return projetoRepositorio.BuscarPorId(projeto);
        }

        public IEnumerable<Projeto> Listar()
        {
            return projetoRepositorio.Listar();
        }

        public void Persistir(Projeto projeto, Usuario usuarioLogado)
        {
            if (projeto.Id == 0)
            {
                var usuarioDaBase = usuarioRepositorio.BuscarPorEmail(usuarioLogado);
                projeto.Usuario = usuarioDaBase;
                projetoRepositorio.Criar(projeto);
            }
            else
            {
                this.VerificarPermissao(projeto, usuarioLogado);
                projetoRepositorio.Editar(projeto);
            }
        }

        public void Remover(Projeto projeto, Usuario usuarioLogado)
        {
            this.VerificarPermissao(projeto, usuarioLogado);
            projetoRepositorio.Remover(projeto);
        }

        private void VerificarPermissao(Projeto projeto, Usuario usuarioLogado)
        {
            var usuarioDaBase = usuarioRepositorio.BuscarPorEmail(usuarioLogado);
            var projetoDaBase = projetoRepositorio.BuscarPorId(projeto);
            var usuarioPodeEditar = usuarioDaBase.Id == projetoDaBase.UsuarioId || "ADMINISTRADOR".Equals(usuarioDaBase.Permissao.Nome);
            if (!usuarioPodeEditar)
            {
                throw new UsuarioException("Você não possuí permissão para realizar esta operação!");
            }
        }

        public ICollection<Projeto> Listar(int pagina, int quantidadePorPagina)
        {
            var paginacao = new Paginacao()
            {
                PaginaDesejada = pagina,
                QuantidadePorPagina = quantidadePorPagina
            };

            return this.projetoRepositorio.Listar(paginacao);
        }

        public int QuantidadeTotal()
        {
            return this.projetoRepositorio.QuantidadeTotal();
        }

    }
}
