using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Conexao
{
    public class NegocioOrcamento
    {
        AcessaDados objAcessaDados = new AcessaDados();
        public DataTable InserirOrcamento()
        {
            //Criar a variavel do tipo de paramentro sql
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            //Criar a variavel do tipo datatable para receber o valor do banco
            DataTable dtRetorno = new DataTable();
            //Método para inserir os dados no banco de dados
            //Captura o retorno do código inserido no banco de dados
            dtRetorno = objAcessaDados.ConsultaDados("spInserirOrcamento", parametros);
            //Retorna o datable para a aplicação
            return dtRetorno;
        }
        public void InserirItensOrcamento(int iOrcamento, int iProduto)
        {
            //Criar a variavel do tipo de paramentro sql
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            //Passar os parametros para a procedure
            parametros.Add(new SqlParameter("@OrcamentoID", iOrcamento));
            parametros.Add(new SqlParameter("@ProdutoID", iProduto));
            //Executa a procedure passando os parametros
            //OrcamentoID e ProdutoID
            objAcessaDados.ExecuteSQL("spInserirItensOrcamento", parametros);           
        }
        public DataTable ConsultarItensComprados(int iOrcamento) {
            //Criar a variavel do tipo de paramentro sql
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            //Criar a variavel DataTable
            DataTable dtRetorno = new DataTable();
            // Passar os parametros para a procedure
            parametros.Add(new SqlParameter("@OrcamentoID", iOrcamento));
            //Executa a procedure passando os parametros
            //OrcamentoID
            dtRetorno = objAcessaDados.ConsultaDados("spConsultarItensComprados", parametros);
            return dtRetorno;
        }
    }
}