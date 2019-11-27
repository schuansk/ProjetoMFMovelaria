<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSupplier.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.OrderPages.SelectSupplier" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container mt-4 mb-4">
            <!-- Row: Cabeçalho -->
            <div class="row">
                <div class="col">
                    <h1 class="text-center h1">
                        <asp:Label ID="lblTitle" runat="server" Text="Selecione o fornecedor"></asp:Label>
                    </h1>
                    <p class="h5 text-center text-danger">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <!-- Row: Conteúdo -->
            <div class="row">
                <div class="container">
                    <!-- Row: Selecionar fornecedor -->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="100%" Font-Size="Larger">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <!-- Row: Botão próxima página -->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <asp:LinkButton ID="lkbNextPage" CssClass="btn btn-success btn-sm" runat="server" OnClick="lkbNextPage_Click" Width="100%">Prosseguir</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
