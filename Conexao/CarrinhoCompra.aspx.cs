using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conexao
{
    public partial class CarrinhoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string PesquisaProdutoID(int ProdutoID) {
            //criar a variavel da classe de negocio produto
            NegocioProduto negProduto = new NegocioProduto();
            //Criar variavel do tipo datatable
            DataTable dtRetorno = new DataTable();
            //atribuir o valor do método consultar
            //para a variável datatable
            dtRetorno = negProduto.ConsultarProdutoID(ProdutoID);
            //Criar a variavel para exibir os itens
            string sTabela = "<table id=\"tblItensCompra\" class=\"table table-bordered\"><thead><tr><th style=\"width:60px\">Código</th><th style=\"width:400px\">Nome</th><th style=\"width:200px\">Preço venda</th><th style=\"width:200px\">Estoque</th><th style=\"width:200px\">Peso</th></tr>";
            //verifica se a variavel datatable está preenchida
            if (dtRetorno.Rows.Count > 0) {
                //percorrer cada linha da variavel table
                foreach (DataRow item in dtRetorno.Rows)
                {
                    //criar uma linha na tabela
                    sTabela += "<tr>";
                    //percorrer as colunas da variavel table
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        //adicionar a coluna na table
                        sTabela += "<td>" + item[i].ToString() + "</td>";
                    }
                    //fecha a linha da tabela
                    sTabela += "</tr>";
                }
                

            }
            //retorna a tabela preenchida
            return sTabela += "</table>";

        }
        [System.Web.Services.WebMethod]
        public static string ContinuarComprando() {
            try
            {
                NegocioOrcamento negOrcamento = new NegocioOrcamento();
                DataTable dtRetorno = negOrcamento.InserirOrcamento();
                if (dtRetorno.Rows.Count > 0)
                {
                    return dtRetorno.Rows[0][0].ToString();
                }
                else
                    return "Nenhum retorno esperado";
            }
            catch (Exception erro)
            {
                return erro.Message;
            }
        }
        [System.Web.Services.WebMethod]
        public static string InserirItensOrcamento(int iOrcamento, int iProdutoID) {
            try
            {
                NegocioOrcamento negOrcamento = new NegocioOrcamento();
                negOrcamento.InserirItensOrcamento(iOrcamento, iProdutoID);
                return "OK";
            }
            catch (Exception erro)
            {

                return erro.Message;
            }
        }
        [System.Web.Services.WebMethod]
        public static string ConsultarItensOrcamento(int iOrcamento) {
            //Criar objeto do tipo de classe "Negocio Orçamento"
            NegocioOrcamento negOrcamento = new NegocioOrcamento();

            //Criar variável do tipo datatable, para carregar os itens comprados
            DataTable dtRetorno = negOrcamento.ConsultarItensComprados(iOrcamento);
            
            //Criar a variavel para exibir os itens
            string sTabela = "<table id=\"tblItensCompra\" class=\"table table-bordered\"><thead><tr><th style=\"width:60px\">Código</th><th style=\"width:400px\">Nome</th><th style=\"width:200px\">Preço venda</th><th style=\"width:200px\">Estoque</th><th style=\"width:200px\">Peso</th></tr>";
            //verifica se a variavel datatable está preenchida
            if (dtRetorno.Rows.Count > 0)
            {
                //percorrer cada linha da variavel table
                foreach (DataRow item in dtRetorno.Rows)
                {
                    //criar uma linha na tabela
                    sTabela += "<tr>";
                    //percorrer as colunas da variavel table
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        //adicionar a coluna na table
                        sTabela += "<td>" + item[i].ToString() + "</td>";
                    }
                    //fecha a linha da tabela
                    sTabela += "</tr>";
                }


            }
            //retorna a tabela preenchida
            return sTabela += "</table>";
        }
    }
}