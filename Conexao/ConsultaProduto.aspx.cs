using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conexao
{
    public partial class ConsultaProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod()]
        public static string ConsultarProduto(string sNome) {
            //Criar objeto da classe de negocio
            NegocioProduto negProduto = new NegocioProduto();
            //Criar variavel do tipo datatable
            DataTable dtRetorno = new DataTable();
            //Criar string para criar a tabela
            string sTabela = "<table class=\"table table-bordered\"><thead><tr><th style=\"width:400px\">Nome</th><th style=\"width:200px\">Preço venda</th><th style=\"width:200px\">Estoque</th><th style=\"width:200px\">Peso</th></tr>";
            //Atribuindo o resultado da consulta na variavel do tipo table
            dtRetorno = negProduto.ConsultarProduto(sNome);

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
            //retorna a tabela preenchida
            return sTabela += "</table>";

        }
    }
}