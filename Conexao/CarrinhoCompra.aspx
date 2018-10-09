<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="CarrinhoCompra.aspx.cs" Inherits="Conexao.CarrinhoCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="BootStrap/bootstrap.css" rel="stylesheet" />
    <script src="scripts/jquery.js"></script>
    <script>
        window.onload = function ConsultaProdutoID() {
            if (sessionStorage.getItem("ProdutoVendidoID") != "") {
                $.ajax({
                    type: 'POST',
                    url: 'CarrinhoCompra.aspx/PesquisaProdutoID',
                    data: "{ProdutoID: " + sessionStorage.getItem("ProdutoVendidoID") + "}",
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',

                    success: function (retorno) {
                        if (retorno.d != '') {
                            document.getElementById('divExibeProduto').innerHTML = retorno.d;
                        }
                    }
                });
            }
            else
                alert('Sessão vazia !!');
        }
        function InserirCarrinho() {
            if (sessionStorage.getItem("OrcamentoID") == null) {
                $.ajax({
                    type: 'POST',
                    url: 'CarrinhoCompra.aspx/ContinuarComprando',
                    data: "{}",
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',

                    success: function (retorno) {
                        if (retorno.d != '') {
                            sessionStorage.setItem("OrcamentoID", retorno.d);
                            var sTable = document.getElementById('tblItensCompra');
                            var iProdutoID = 0;
                            if (sTable != null) {
                                for (var i = 0; i < sTable.children[0].children.length; i++) {
                                    if (i > 0) {
                                        iProdutoID = sTable.children[0].children[i].children[0].innerHTML;
                                        if (sessionStorage.getItem('OrcamentoID') != null) {
                                            $.ajax({
                                                type: 'POST',
                                                url: 'CarrinhoCompra.aspx/InserirItensOrcamento',
                                                data: "{iOrcamento: " + sessionStorage.getItem("OrcamentoID") + ",  iProdutoID: " + iProdutoID + "}",
                                                contentType: 'application/json; charset=utf-8',
                                                datatype: 'json',

                                                success: function (retorno) {
                                                    if (retorno.d != "")
                                                        alert('Dados cadastrado com sucesso !!');
                                                }
                                            });
                                        }
                                    }
                                }
                            }

                            ConsultarItensComprados(sessionStorage.getItem('OrcamentoID'));
                        }
                    }
                });
            }
            else {
                var sTable = document.getElementById('tblItensCompra');
                var iProdutoID = 0;
                if (sTable != null) {
                    for (var i = 0; i < sTable.children[0].children.length; i++) {
                        if (i > 0) {
                            iProdutoID = sTable.children[0].children[i].children[0].innerHTML;
                            if (sessionStorage.getItem('OrcamentoID') != null) {
                                $.ajax({
                                    type: 'POST',
                                    url: 'CarrinhoCompra.aspx/InserirItensOrcamento',
                                    data: "{iOrcamento: " + sessionStorage.getItem("OrcamentoID") + ",  iProdutoID: " + iProdutoID + "}",
                                    contentType: 'application/json; charset=utf-8',
                                    datatype: 'json',

                                    success: function (retorno) {
                                        if (retorno.d != "")
                                            alert('Dados cadastrado com sucesso !!');
                                    }
                                });
                            }
                        }
                    }
                }

                ConsultarItensComprados(sessionStorage.getItem('OrcamentoID'));
            }
                       
        }
        function ConsultarItensComprados(OrcamentoID) {
            $.ajax({
                type: 'POST',
                url: 'CarrinhoCompra.aspx/ConsultarItensOrcamento',
                data: "{iOrcamento: " +OrcamentoID+ "}",
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',
                success: function (retorno) {
                    if (retorno.d != '') {
                        document.getElementById('divExibeProdutoComprados').innerHTML = retorno.d;
                    }
                }
            });
        }
        function ContinuarComprando() {
            window.location.href = "ExibirProduto.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divExibeProduto"></div>
    <%-- div para adicionar os botões de comando --%>
    <div class="row">
        <%-- Botão continuar comprando --%>
        <div class="col-md-4">
            <input type="button" class="btn btn-success" value="Continuar comprando" id="btnContComprar" onclick="ContinuarComprando()"/>
        </div>
        <%-- Botão finalizar compra --%>  
        <div class="col-md-4">
            <input type="button" class="btn btn-primary" value="Finalizar compra" id="btnFinCompra"/>
        </div> 
        <%-- Botão para inserir no carrinho --%> 
        <div class="col-md-4">
            <input type="button" class="btn btn-warning" value="Inserir no carrinho" id="btnInserirCarrinho" onclick="InserirCarrinho()"/>
        </div>
    </div>
    <div class="row">
        <div id="divExibeProdutoComprados"></div>
    </div>
</asp:Content>
