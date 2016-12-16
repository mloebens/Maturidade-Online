using Maturidade_Online.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Maturidade_Online.Repositorio
{
    public class SubtopicoRepositorio : ContextoDeDados
    {
        public void AlterarVinculos(Subtopico subtopico)
        { 
            this.removerVinculos(subtopico);
            this.adicionarVinculos(subtopico);
        }

        private void adicionarVinculos(Subtopico subtopico)
        {
            foreach (var caracteristica in subtopico.Caracteristicas)
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

            foreach (var projeto in subtopico.Projetos)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    var sql = new StringBuilder();
                    var parameters = new List<SqlParameter>();

                    sql.Append($"INSERT INTO SubtopicoSubtopico(ProjetoId, SubtopicoId) VALUES(");
                    sql.Append($"@param_ProjetoId,@param_SubtopicoId)");
                    parameters.Add(new SqlParameter("@param_SubtopicoId", subtopico.Id));
                    parameters.Add(new SqlParameter("@param_ProjetoId", projeto.Id));

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

        private void removerVinculos(Subtopico subtopico)
        {
            var tabelas = new[] { "ProjetoSubtopico", "CaracteristicaSubtopico" };
            foreach (var tabela in tabelas)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    string sql = $"DELETE FROM {tabela} WHERE SubtopicoId = @param_idSubtopico";
                    var command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@param_idSubtopico", $"{subtopico.Id}"));
                    command.ExecuteNonQuery();
                    transaction.Complete();
                }
            }
        }
    }
}
