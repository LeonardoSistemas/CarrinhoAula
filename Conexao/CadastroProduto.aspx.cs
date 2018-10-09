using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conexao
{
    public partial class CadastroProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string GravarProduto(string sNome,decimal dValorCusto, decimal dValorVenda, decimal dValorLucro, decimal dEstoque, decimal dPeso) {
            NegocioProduto negProduto = new NegocioProduto();
            try
            {
                negProduto.InseriProduto(sNome, dValorCusto, dValorVenda, dValorLucro, dEstoque, dPeso);
                return "OK";
            }
            catch (Exception erro)
            {

                return erro.Message;
            }
            
        }        
    }
}