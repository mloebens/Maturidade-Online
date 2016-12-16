using Maturidade_Online.Dominio.Subtopico;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Maturidade_Online.Repositorio.Subtopico
{
    public class SubtopicoRepositorio : ContextoDeDados
    {
        public void AlterarVinculos(SubtopicoEntidade subtopico)
        { 
            this.removerVinculos(subtopico);
            this.adicionarVinculos(subtopico);
        }

        private void adicionarVinculos(SubtopicoEntidade subtopico)
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

        private void removerVinculos(SubtopicoEntidade subtopico)
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
