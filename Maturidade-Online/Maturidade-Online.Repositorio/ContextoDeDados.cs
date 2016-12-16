using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class ContextoDeDados
    {
        private readonly string connectionString;

        public ContextoDeDados()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MaturidadeOnlineMaiconCasa"].ConnectionString;
        }

        protected SqlConnection Conexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
