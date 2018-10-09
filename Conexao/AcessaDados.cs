using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao
{
    public class AcessaDados
    {
        #region Obter SqlConnection
        public SqlConnection ObterConexao()
        {
            try
            {
                // Obtemos os dados da conexão existentes no WebConfig utilizando o ConfigurationManager
                string dadosConexao = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
                // Instanciando o objeto SqlConnection
                SqlConnection sqlconnection = new SqlConnection(dadosConexao);                
                //Retorna o sqlconnection.              
                return sqlconnection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Adiciona Parâmetros 
        public void ExecuteSQL(string spNome, SqlParameterCollection parametros)
        {

            using (SqlConnection conexao = ObterConexao())
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(spNome, conexao);
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.Add(parametro.ParameterName, parametro.Value);
                    }
                    comando.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
        }
        #endregion

        #region Consulta dados
        public DataTable ConsultaDados(string spNome, SqlParameterCollection parametros)
        {

            using (SqlConnection conexao = ObterConexao())
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(spNome, conexao);
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(comando);
                    DataTable dtConsulta = new DataTable();
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.Add(parametro.ParameterName, parametro.Value);
                    }
                    sqlAdapter.Fill(dtConsulta);
                    return dtConsulta;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
        }
        #endregion
    }
}