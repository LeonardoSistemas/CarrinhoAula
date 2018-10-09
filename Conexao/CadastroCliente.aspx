<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="Conexao.CadastroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="BootStrap/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12">
            Nome
            <input type="text" id="txtNome" class="form-control" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-sm-12">
            CPF
            <input type="text" id="txtCPF" class="form-control" runat="server" />
        </div>
        <div class="col-md-6 col-sm-12">
            RG
            <input type="text" id="txtRG" class="form-control" runat="server" />
        </div>
    </div> 
    <div class="row">
        <div class="col-md-2 col-sm-6">
            UF
            <select id="cbbUF" class="form-control" runat="server">
                <option value="SP">SP</option>
                <option value="RJ">RJ</option>
                <option value="BA">BA</option>
            </select>
        </div>
        <div class="col-md-4 col-sm-6">
            Cidade
            <select id="cbbCidade" class="form-control" runat="server">
                <option value ="Bebedouro">Bebedouro</option>
                <option value ="Viradouro">Viradouro</option>
                <option value ="MAP">Monte azul</option>
            </select>
        </div>
        <div class="col-md-6 col-sm-12">
            Endereço
            <input type="text" id="txtEndereco" class ="form-control" runat="server" />
        </div>
    </div> 
        <div class="row">
            <div class="col-md-4 col-sm-6">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
            </div>
        </div>  
    </form>
</body>
</html>
