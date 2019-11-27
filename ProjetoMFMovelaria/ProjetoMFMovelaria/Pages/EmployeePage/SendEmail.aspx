<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.EmployeePage.SendEmail" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Conianter: principal -->
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Enviar pedido por e-mail"></asp:Label>
                </h1>
                <p class="h5 text-center text-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </p>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="container">
                <!-- Row: Fornecedor -->
                <div class="row">
                    <div class="col-12 col-lg-8 offset-lg-2">
                        <asp:Label ID="Label1" runat="server" Text="Selecione o fornecedor:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlSupplier" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="E-mail do fornecedor:"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="O campo e-mail do fornecedor é obrigatório." ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="O formato do e-mail está incorreto." ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <!-- Row: Assunto -->
                <div class="row">
                    <div class="col-12 col-lg-8 offset-lg-2">
                        <asp:Label ID="Label4" runat="server" Text="Assunto:"></asp:Label>
                        <asp:TextBox ID="txtsubject" runat="server" Width="100%"></asp:TextBox>
                    </div>
                </div>
                <!-- Row: Anexo -->
                <br />
                <div class="row">
                    <div class="col-12 col-lg-8 offset-lg-2">
                        <asp:Label ID="Label3" runat="server" Text="Anexo (clique no botão escolher arquivo ou arraste o arquivo até o botão):"></asp:Label>
                        <br />
                        <asp:FileUpload ID="fuAnexo" runat="server" Width="100%" />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuAnexo" ErrorMessage="Você ainda não anexou um pedido." ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- Row: Botão enviar -->
                <br />
                <div class="row">
                    <div class="col-12 col-lg-8 offset-lg-2">
                        <asp:Button ID="btnSend" CssClass="btn btn-success btn-sm" runat="server" Text="Enviar" Width="100%" OnClick="btnSend_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
