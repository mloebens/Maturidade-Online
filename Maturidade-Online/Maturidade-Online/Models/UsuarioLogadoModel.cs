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

        public UsuarioLogadoModel(int id, string email)
        {
            this.Email = email;
            this.Id = id;
        }

    }
}