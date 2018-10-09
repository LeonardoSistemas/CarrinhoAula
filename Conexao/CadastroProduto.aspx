<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="Conexao.CadastroProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="BootStrap/bootstrap.css" rel="stylesheet" />
    <style>
        input:required {
            box-shadow:2px 2px 2px red;
        }
    </style>
    <script src="scripts/jquery.js"></script>
    <script src="scripts/Funcoes.js"></script>

    <script>
        function CalcLucro() {
            var ValorVenda = 0;
            var ValorCusto = 0;
            var ValorLucro = 0;

            ValorVenda = document.getElementById('txtValorVenda');
            ValorCusto = document.getElementById('txtValorCusto');

            if (ValorCusto != null && ValorVenda != null) {
                if (ValorCusto.value != "" && ValorVenda.value != "") {
                    ValorLucro = CalcularLucro(ValorCusto.value, ValorVenda.value);
                    document.getElementById('txtLucro').value = ValorLucro;
                }
            }
        }
        function GravarRegistro() {
            var Nome = document.getElementById('txtNome');
            var ValorVenda = document.getElementById('txtValorVenda');
            var ValorCusto = document.getElementById('txtValorCusto');
            var ValorLucro = document.getElementById('txtLucro');
            var Estoque = document.getElementById('txtEstoque');
            var Peso = document.getElementById('txtPeso');
            var sCampoVazio = "";

            if (Nome != null) {
                if (Nome.value == "") {
                    sCampoVazio += " Nome ";
                    Nome.required = true;
                }
            }
            if (ValorVenda != null) {
                if (ValorVenda.value == "") {
                    sCampoVazio += " Valor de venda ";
                    ValorVenda.required = true;
                }
            }
            if (ValorCusto != null) {
                if (ValorCusto.value == "") {
                    sCampoVazio += "Valor de custo";
                    ValorCusto.required = true;
                }
            }
            if (ValorLucro != null) {
                if (ValorLucro.value == "") {
                    sCampoVazio += "Valor de lucro";
                    ValorLucro.required = true;
                }
            }
            if (Estoque != null) {
                if (Estoque.value == "") {
                    sCampoVazio += "Estoque";
                    Estoque.required = true;
                }
            }
            if (Peso != null) {
                if (Peso.value == "") {
                    sCampoVazio += "Peso";
                    Peso.required = true;
                }
            }
            if (sCampoVazio != "")
                 document.getElementById('divExibeAlert').innerHTML = "<div class=\"alert alert-danger\"><center>"+sCampoVazio + "são campos obrigatórios - preencha corretamente !!"+"</center><br/><center><input type=\"button\" class=\"btn btn-danger\" value=\"OK\" onclick=\"FecharAlert()\"></center></div>";
            else {
                $.ajax({
                    type: 'POST',
                    url: 'CadastroProduto.aspx/GravarProduto',
                    data: "{sNome: '" + Nome.value + "',dValorCusto: '" + ValorCusto.value + "', dValorVenda : '" + ValorVenda.value + "', dValorLucro: '" + ValorLucro.value + "', dEstoque: '" + Estoque.value + "',dPeso: '"+Peso.value+"'}",
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',

                    success: function (retorno) {
                        if (retorno.d == "OK") {
                            document.getElementById("divExibeAlert").innerHTML = "<div class=\"alert alert-success\"><center>Cadastro realizado com sucesso !! </center><br/><input type=\"button\" class=\"btn btn-success\" value=\"OK\" onclick=\"FecharAlert()\"/></div>"
                        }
                    }
                });
            }
        }

        function FecharAlert() {
            document.getElementById('divExibeAlert').innerHTML = '';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divExibeAlert"></div>
    <div class="row">
        <div class="col-md-12 col-sm-12">
            Nome
            <input type="text" id="txtNome" class="form-control" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-5 col-sm-12">
            Valor Custo
            <input type="text" id="txtValorCusto" class="form-control" runat="server" />
        </div>
        <div class="col-md-5 col-sm-12">
            Valor Venda
            <input type="text" id="txtValorVenda" onblur="CalcLucro()" class="form-control" runat="server" />
        </div>
        <div class="col-md-2 col-sm-12">
            Lucro
            <input type="text" id="txtLucro" class="form-control" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-sm-12">
            Estoque
            <input type="text" id="txtEstoque" class="form-control" runat="server" />
        </div>
       <div class="col-md-6 col-sm-12">
           Peso
           <input type="text" id="txtPeso" class="form-control" runat="server" />
       </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-sm-12">
            <input type="button" id="btnSalvarProduto" value="Salvar" class="btn btn-success" onclick="GravarRegistro()"/>
            
        </div>
    </div>
    </form>
</body>
</html>
