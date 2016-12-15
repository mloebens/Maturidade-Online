using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Models
{
    public class UsuarioModel
    {

        public string Login { get; private set; }

        public UsuarioModel(string nome)
        {
            this.Login = nome;
        }

    }
}