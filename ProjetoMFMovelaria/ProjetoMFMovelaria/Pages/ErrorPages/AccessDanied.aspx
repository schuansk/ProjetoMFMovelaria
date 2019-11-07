<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDanied.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.ErrorPages.AccessDanied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Acessao não autorizado"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pages/EmployeePage/Login.aspx">Voltar para login</asp:HyperLink>
            </p>
        </div>
    </form>
</body>
</html>
