using LojaDeItens.Dominio.Configuracao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LojaDeItens.Web.Servicos
{
    public class ServicoDeConfiguracao : IServicoDeConfiguracao
    {
        public int QuantidadeDeCaracteristicasPorPagina
        {
            get
            {
                int quantidade = Convert.ToInt32(
                    ConfigurationManager.AppSettings["QuantidadeDeCaracteristicasPorPagina"]
                );

                return quantidade;
            }
        }
    }
}