using Maturidade_Online.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Projeto
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

        public ProjetoEntidade BuscarPorId(ProjetoEntidade projeto)
        {
            return projetoRepositorio.BuscarPorId(projeto);
        }

        public IEnumerable<ProjetoEntidade> Listar()
        {
            return projetoRepositorio.Listar();
        }

        public void Persistir(ProjetoEntidade projeto, UsuarioEntidade usuarioLogado)
        {
           
            if (projeto.Id == 0)
            {
                var usuarioDaBase = usuarioRepositorio.BuscarPorEmail(usuarioLogado);
                projeto.Usuario = usuarioDaBase;
                projetoRepositorio.Criar(projeto);
            }
            else
            {
                this.verificarPermissao(projeto, usuarioLogado);
                projetoRepositorio.Editar(projeto);
            }
        }

        public void Remover(ProjetoEntidade projeto, UsuarioEntidade usuarioLogado)
        {
            this.verificarPermissao(projeto, usuarioLogado);
            projetoRepositorio.Remover(projeto);
        }

        private void verificarPermissao(ProjetoEntidade projeto, UsuarioEntidade usuarioLogado)
        {
            var usuarioDaBase = usuarioRepositorio.BuscarPorEmail(usuarioLogado);
            var projetoDaBase = projetoRepositorio.BuscarPorId(projeto);
            var usuarioPodeEditar = usuarioDaBase.Id == projetoDaBase.UsuarioId || usuarioDaBase.Permissao == Permissao.ADMINISTRADOR;
            if (!usuarioPodeEditar)
            {
                throw new UsuarioException("Você não possuí permissão para realizar esta operação!");
            }
        }
    }
}
