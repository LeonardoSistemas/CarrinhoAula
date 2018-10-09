using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Conexao
{
    public class NegocioProduto
    {
        AcessaDados objAcessaDados = new AcessaDados();
        public void InseriProduto(string sNome, decimal dValorCusto, decimal dValorVenda, decimal dValorLucro, decimal dEstoque, decimal dPeso)
        {
            //cria um objeto do tipo sqlparametercollection
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            parametros.Add(new SqlParameter("@Nome", sNome));
            parametros.Add(new SqlParameter("@ValorCusto", dValorCusto));
            parametros.Add(new SqlParameter("@ValorVenda", dValorVenda));
            parametros.Add(new SqlParameter("@ValorLucro", dValorLucro));
            parametros.Add(new SqlParameter("@Estoque", dEstoque));
            parametros.Add(new SqlParameter("@Peso", dPeso));
            objAcessaDados.ExecuteSQL("spCadastroProduto", parametros);

        }

        public DataTable ConsultarProduto(string sNome) {
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            parametros.Add(new SqlParameter("@Nome", sNome));
            return objAcessaDados.ConsultaDados("spConsultaProduto",parametros);
        }
        public void AlterarProduto()
        {

        }

        public void ExcluirProduto()
        {

        }

        public DataTable ConsultarProdutoID(int ProdutoID) {
            //cria um objeto do tipo sqlparametercollection
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            
            //passa o valor da variavel para o parametro do banco de dados(procedure)
            parametros.Add(new SqlParameter("@ProdutoID", ProdutoID));

            //Chama o método para executar a procedure no banco de dados
            DataTable dtRetorno = objAcessaDados.ConsultaDados("spConsultaProdutoID", parametros);
            return dtRetorno;
        }
    }
}