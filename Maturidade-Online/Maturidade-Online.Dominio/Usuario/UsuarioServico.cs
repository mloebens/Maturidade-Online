using Maturidade_Online.Dominio.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Usuario
{
    public class UsuarioServico
    {

        private IUsuarioRepositorio usuarioRepositorio;
        private IServicoDeCriptografia servicoCriptografia;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IServicoDeCriptografia servicoCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public UsuarioEntidade BuscarPorAutenticacao(UsuarioEntidade usuario)
        {
            UsuarioEntidade usuarioEncontrado = this.usuarioRepositorio.BuscarPorEmail(usuario);
            string senhaCriptografada = this.servicoCriptografia.Criptografar(usuario.Senha);

            if(usuarioEncontrado != null && usuarioEncontrado.Senha.Equals(senhaCriptografada))
            {
                return usuarioEncontrado;
            }

            return null;
        }

        public UsuarioEntidade BuscarPorEmail(UsuarioEntidade usuario)
        {
            return this.usuarioRepositorio.BuscarPorEmail(usuario);
        }

    }
}
