<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.EmployeePage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Style.css" rel="stylesheet" />
</head>
<body class="img-fundo-login">
    <form id="form1" runat="server">
        <div class="container">
            <div class="offset-md-4 col-md-4 caixa-texto-login">

                <p class="text-center">Bem-vindo</p>
                <h3 class="text-center">Acesso administrativo</h3>
                <br />
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <asp:TextBox ID="txbUsuario" runat="server" placeholder="Nome do usuário" CssClass="form-control teste-opacidade"></asp:TextBox>
                </div>
                <br />
                <br />
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <asp:TextBox ID="txbSenha" runat="server" placeholder="Senha" type="password" CssClass="form-control teste-opacidade"></asp:TextBox>
                </div>
                <br />
                <asp:CheckBox ID="cbxSalvarSenha" runat="server" Text="Lembrar-me nesse computador" />
                <br />

                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success offset-md-5 offset-sm-5 offset-5" OnClick="btnLogin_Click" />
                <br />
                <br />
                <asp:Label ID="lblMensagem" Text="" runat="server" CssClass=""></asp:Label>
                <div class="clearfix"></div>
            </div>
        </div>
    </form>
    <script src="../../Scripts/jquery-3.0.0.slim.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
</body>
</html>
