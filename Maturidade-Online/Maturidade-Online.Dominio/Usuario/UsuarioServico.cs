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

        public UsuarioEntidade BuscarPorAutenticacao(string email, string senha)
        {
            UsuarioEntidade usuarioEncontrado = this.usuarioRepositorio.BuscarPorEmail(email);
            string senhaCriptografada = this.servicoCriptografia.Criptografar(senha);

            if(usuarioEncontrado != null && usuarioEncontrado.Senha.Equals(senhaCriptografada))
            {
                return usuarioEncontrado;
            }

            return null;
        }

    }
}
