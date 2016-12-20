using Maturidade_Online.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class UsuarioLogadoModel
    {
        public int Id { get; set; }
        public string Email { get; private set; }

        public Permissao Permissao { get; set; }

        public UsuarioLogadoModel(int id, string email, Permissao permissao)
        {
            this.Email = email;
            this.Id = id;
            this.Permissao = Permissao;
        }

    }
}