using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conexao
{
    public partial class ExibirProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod()]
        public static string ExibirProdutos()
        {
            //Criar objeto da classe de negocio
            NegocioProduto negProduto = new NegocioProduto();
            //Criar variavel do tipo datatable
            DataTable dtRetorno = new DataTable();
            //atribuir o valor do método consultar
            //para a variável datatable
            dtRetorno = negProduto.ConsultarProduto("");
            //Criar a variavel para exibir os itens
            string sProdutos = "";
            //verificar se exite itens na variavel datatable
            if (dtRetorno.Rows.Count > 0)
            {
                //preencher a div com os valores dos produtos
                sProdutos += "<div class=\"row\">";

                //percorrer cada linha da variavel datatable
                foreach (DataRow item in dtRetorno.Rows)
                {
                    //criar a div de coluna
                    sProdutos += "<div class=\"col-md-4\">";
                    //atribuir o valor da coluna da tabela para a variável
                    sProdutos += "<div class=\"row\">" + item["Nome"].ToString() + "</div>";
                    sProdutos += "<div class=\"row\">" + item["ValorVenda"].ToString() + "</div>";
                    //cria o botão de comprar
                    sProdutos += "<div class=\"row\"><input type=\"button\" class=\"btn btn-primary\" value=\"COMPRAR\" onclick=\"ComprarProduto("+item["ProdutoID"]+")\"/></div>";
                    //fechar a div do produto
                    sProdutos += "</div>";
                }
                //fechar a div linha
                sProdutos += "</div>";
            }
            return sProdutos;
        }
    }
}