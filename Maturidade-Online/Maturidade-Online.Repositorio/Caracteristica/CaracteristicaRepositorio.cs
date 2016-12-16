using Maturidade_Online.Dominio.Caracteristica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Maturidade_Online.Repositorio.Caracteristica
{
    public class CaracteristicaRepositorio : ContextoDeDados
    {
        public void AlterarVinculos(CaracteristicaEntidade caracteristica)
        { 
            this.removerVinculos(caracteristica);
            this.adicionarVinculos(caracteristica);
        }

        private void adicionarVinculos(CaracteristicaEntidade caracteristica)
        {
            foreach (var subtopico in caracteristica.Subtopicos)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    var sql = new StringBuilder();
                    var parameters = new List<SqlParameter>();

                    sql.Append($"INSERT INTO SubtopicoCaracteristica(SubtopicoId, CaracteristicaId) VALUES(");
                    sql.Append($"@param_SubtopicoId,@param_CaracteristicaId)");
                    parameters.Add(new SqlParameter("@param_SubtopicoId", subtopico.Id));
                    parameters.Add(new SqlParameter("@param_CaracteristicaId", caracteristica.Id));

                    var command = new SqlCommand(sql.ToString(), connection);
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    command.ExecuteNonQuery();
                    transaction.Complete();
                }
            }
        }

        private void removerVinculos(CaracteristicaEntidade subtopico)
        {
            var tabelas = new[] { "ProjetoCaracteristica", "CaracteristicaCaracteristica" };
            foreach (var tabela in tabelas)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    string sql = $"DELETE FROM {tabela} WHERE CaracteristicaId = @param_idCaracteristica";
                    var command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@param_idCaracteristica", $"{subtopico.Id}"));
                    command.ExecuteNonQuery();
                    transaction.Complete();
                }
            }
        }
    }
}
