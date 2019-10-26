<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnTestPage.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.Test.ConnTestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teste de conexão</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="ml-4 mt-4">
<form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Cadastro para teste de conexão"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" CssClass="btn btn-sm btn-success" runat="server" OnClick="btnSave_Click" Text="Salvar" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Execute novamente o projeto e se tudo deu certo seu nome aparecera abaixo:"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="tes_nome" HeaderText="Nome" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblMessageList" runat="server"></asp:Label>
        <br />
    </form>
    </div>
    
    
    <!-- Importação do JS -->
    <script src="../../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</body>
</html>
