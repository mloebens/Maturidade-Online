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
    public class ProjetoRepositorio : ContextoDeDados
    {
        public void AlterarVinculos(Projeto projeto)
        {

            this.removerVinculos(projeto);
            this.adicionarVinculos(projeto);
        }

        private void adicionarVinculos(Projeto projeto)
        {
            foreach (var caracteristica in projeto.Caracteristicas)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    var sql = new StringBuilder();
                    var parameters = new List<SqlParameter>();

                    sql.Append($"INSERT INTO ProjetoCaracteristica(ProjetoId, CaracteristicaId) VALUES(");
                    sql.Append($"@param_ProjetoId,@param_CaracteristicaId)");
                    parameters.Add(new SqlParameter("@param_ProjetoId", projeto.Id));
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

            foreach (var subtopico in projeto.Subtopicos)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    var sql = new StringBuilder();
                    var parameters = new List<SqlParameter>();

                    sql.Append($"INSERT INTO ProjetoSubtopico(ProjetoId, SubtopicoId) VALUES(");
                    sql.Append($"@param_ProjetoId,@param_SubtopicoId)");
                    parameters.Add(new SqlParameter("@param_ProjetoId", projeto.Id));
                    parameters.Add(new SqlParameter("@param_SubtopicoId", subtopico.Id));

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

        private void removerVinculos(Projeto projeto)
        {
            var tabelas = new[] { "ProjetoSubtopico", "ProjetoCaracteristica" };
            foreach (var tabela in tabelas)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                using (var connection = Conexao())
                {
                    connection.Open();

                    string sql = $"DELETE FROM {tabela} WHERE ProjetoId = @param_idProjeto";
                    var command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@param_idProjeto", $"{projeto.Id}"));
                    command.ExecuteNonQuery();
                    transaction.Complete();
                }
            }
        }
    }
}
