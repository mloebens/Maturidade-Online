using Maturidade_Online.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Mock
{
    public class UsuarioRepositorioMock : IUsuarioRepositorio
    {

        IList<UsuarioEntidade> usuarios = new List<UsuarioEntidade>()
        {
            new UsuarioEntidade()
            {
                Id = 1,
                Nome = "Carlos",
                Email = "carlos@cwi.com.br",
                Senha = "6f1d81c734062fe646d96eb97dfd1d9c",
                Permissao = Permissao.ADMINISTRADOR
            },

            new UsuarioEntidade()
            {
                Id = 2,
                Nome = "Normal",
                Email = "usuario@normal.com.br",
                Senha = "6f1d81c734062fe646d96eb97dfd1d9c",
                Permissao = Permissao.USUARIO
            }

        };


        public UsuarioEntidade BuscarPorEmail(string email)
        {
            return usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
