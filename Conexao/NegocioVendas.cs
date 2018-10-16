using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Conexao
{
    public class NegocioVendas
    {
        //Criar variavel do tipo de classe conexão
        AcessaDados objAcessaDados = new AcessaDados();

        //cria o método para inserir registro na tabela de vendas
        public int InserirVenda() {
            //Criar a variavel do tipo de paramentro sql
            SqlParameterCollection parametros = new SqlCommand().Parameters;

            //Método para inserir os dados no banco de dados
            objAcessaDados.ExecuteSQL("spInserirVendas", parametros);

            int iVenda = 0;
            DataTable dtVenda = new DataTable();
            dtVenda = ConsultarUltVenda();
            if (dtVenda.Rows.Count > 0) {
                iVenda = Convert.ToInt32(dtVenda.Rows[0][0]);
            }
            return iVenda;
        }

        //cria o método para inserir registro na tabela de Itens vendas
        public void InserirItens(int iVendas, int iProduto) {
            //Criar a variavel do tipo de paramentro sql
            SqlParameterCollection parametros = new SqlCommand().Parameters;

            //Passar os parametros para a procedure
            parametros.Add(new SqlParameter("@VendaID", iVendas));
            parametros.Add(new SqlParameter("@ProdutoID", iProduto));

            objAcessaDados.ExecuteSQL("spInserirItens", parametros);
        }

        //Cria o método para consultar a última venda
        public DataTable ConsultarUltVenda() {
            //Criar a variavel do tipo de paramentro sql
            SqlParameterCollection parametros = new SqlCommand().Parameters;

            //Cria variavel do tipo datatable
            DataTable dtRetorno = new DataTable();

            dtRetorno = objAcessaDados.ConsultaDados("spConsultaUltVenda", parametros);
            return dtRetorno;
        }
    }
}