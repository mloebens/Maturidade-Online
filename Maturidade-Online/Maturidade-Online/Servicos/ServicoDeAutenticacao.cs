using Maturidade_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maturidade_Online.Servicos
{
    public class ServicoDeAutenticacao
    {

        private const string USUARIO_LOGADO_CHAVE = "USUARIO_LOGADO_CHAVE";

        public static void Autenticar(UsuarioModel model)
        {
            HttpContext.Current.Session[USUARIO_LOGADO_CHAVE] = model;
        }

        public static UsuarioModel UsuarioLogado
        {
            get
            {
                return (UsuarioModel)HttpContext.Current.Session[USUARIO_LOGADO_CHAVE];
            }
        }

    }
}