<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Conexao.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="BootStrap/bootstrap.css" rel="stylesheet" />

    <script src="scripts/jquery.js"></script>
    <script src="scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavDropdown">
                    <ul class="navbar-nav">                        
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="MenuCadastro" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Cadastros
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <a class="dropdown-item" href="CadastroCliente.aspx">Clientes</a>
                                <a class="dropdown-item" href="CadastroProduto.aspx">Produtos</a>
                            </div>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="MenuConsulta" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Consultas
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <a class="dropdown-item" href="CadastroCliente.aspx">Clientes</a>
                                <a class="dropdown-item" href="CadastroProduto.aspx">Produtos</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    </form>
</body>
</html>
