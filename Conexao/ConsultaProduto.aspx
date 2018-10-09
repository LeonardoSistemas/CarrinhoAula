<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaProduto.aspx.cs" Inherits="Conexao.ConsultaProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="BootStrap/bootstrap.css" rel="stylesheet" />
    <script src="scripts/jquery.js"></script>
    <script>
        function ConsultarProduto() {
            var NomeProduto = "";
            if (document.getElementById('txtPesquisaProduto') != null) {
                if (document.getElementById('txtPesquisaProduto').value != '')
                    NomeProduto = document.getElementById('txtPesquisaProduto').value;
            }
            $.ajax({
                type: 'POST',
                url: 'ConsultaProduto.aspx/ConsultarProduto',
                data: "{sNome : '"+NomeProduto+"'}",
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',

                success: function (retorno) {
                    if (retorno.d != '') {
                        document.getElementById("divExibeResultado").innerHTML = retorno.d;
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <div class="col-md-9">
            Nome
            <input type="text" class="form-control" id="txtPesquisaProduto" />
        </div>
        <div class="col-md-2">
            <div class="btn btn-default" onclick="ConsultarProduto()">Pesquisar</div>
        </div>
    </div>
    <div id="divExibeResultado"></div>
    </form>
</body>
</html>
