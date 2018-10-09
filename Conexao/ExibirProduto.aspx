<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ExibirProduto.aspx.cs" Inherits="Conexao.ExibirProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="BootStrap/bootstrap.css" rel="stylesheet" />

    <script src="scripts/jquery.js"></script>
    <script>
        window.onload = function ExibirProduto() {
            $.ajax({
                type: 'POST',
                url: 'ExibirProduto.aspx/ExibirProdutos',
                data: "{}",
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',

                success: function (retorno) {
                    if (retorno.d != '') {
                        document.getElementById("divExibirProduto").innerHTML = retorno.d;
                    }
                }
            });
        }
        function ComprarProduto(idProduto) {
            sessionStorage.setItem("ProdutoVendidoID", idProduto);
            window.location.href = "CarrinhoCompra.aspx";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divExibirProduto"></div>
</asp:Content>
