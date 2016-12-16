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
            return projetoRepositorio.BuscarPorId(projeto.Id);
        }

        public IEnumerable<ProjetoEntidade> Listar()
        {
            return projetoRepositorio.Listar();
        }

        public void Persistir(ProjetoEntidade projeto, string usuarioLogadoEmail)
        {
           
            if (projeto.Id == 0)
            {
                var usuarioLogado = usuarioRepositorio.BuscarPorEmail(usuarioLogadoEmail);
                projeto.Usuario = usuarioLogado;
                projetoRepositorio.Criar(projeto);
            }
            else
            {

                this.verificarPermissao(projeto, usuarioLogadoEmail);
                projetoRepositorio.Editar(projeto);
            }
        }

        public void Remover(ProjetoEntidade projeto, string usuarioLogadoEmail)
        {
            this.verificarPermissao(projeto, usuarioLogadoEmail);
            projetoRepositorio.Remover(projeto);
        }

        private void verificarPermissao(ProjetoEntidade projeto, string usuarioLogadoEmail)
        {
            var usuarioLogado = usuarioRepositorio.BuscarPorEmail(usuarioLogadoEmail);
            var projetoDaBase = projetoRepositorio.BuscarPorId(projeto.Id);
            var usuarioPodeEditar = usuarioLogado.Id == projetoDaBase.UsuarioId || usuarioLogado.Permissao == Permissao.ADMINISTRADOR;
            if (!usuarioPodeEditar)
            {
                throw new UsuarioException("Você não possuí permissão para realizar esta operação!");
            }
        }
    }
}
