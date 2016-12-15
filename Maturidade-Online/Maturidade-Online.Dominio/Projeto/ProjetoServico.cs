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

        public ProjetoServico(IProjetoRepositorio projetoRepositorio)
        {
            this.projetoRepositorio = projetoRepositorio;
        }

        public ProjetoEntidade BuscarPorId(ProjetoEntidade projeto)
        {
            return projetoRepositorio.BuscarPorId(projeto.Id);
        }

        public IEnumerable<ProjetoEntidade> Listar()
        {
            return projetoRepositorio.Listar();
        }

        public void Persistir(ProjetoEntidade projeto, UsuarioEntidade usuarioLogado)
        {
            if (projeto.Id == 0)
            {
                projeto.Usuario = usuarioLogado;
                projetoRepositorio.Criar(projeto);
            }
            else
            {
                projetoRepositorio.Editar(projeto);
            }
        }

        public void Remover(ProjetoEntidade projeto)
        {
            projetoRepositorio.Remover(projeto);
        }
    }
}
