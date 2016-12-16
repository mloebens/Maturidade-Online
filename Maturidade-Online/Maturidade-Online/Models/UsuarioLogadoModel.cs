using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class UsuarioLogadoModel
    {

        public string Email { get; private set; }

        public UsuarioLogadoModel(string email)
        {
            this.Email = email;
        }

    }
}