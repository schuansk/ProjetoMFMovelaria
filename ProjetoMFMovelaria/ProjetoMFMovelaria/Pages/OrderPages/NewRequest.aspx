<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRequest.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.OrderPages.NewRequest" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="container mt-4 mb-4">
            <!-- Row: Cabeçalho -->
            <div class="row">
                <div class="col">
                    <h1 class="text-center h1">
                        <asp:Label ID="lblTitle" runat="server" Text="Pedido para o fornecedor:"></asp:Label>
                    </h1>
                    <h2 class="text-center h3">
                        <asp:Label ID="lblSupplier" runat="server" Text=""></asp:Label>
                    </h2>
                    <p class="h5 text-center text-success">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label>
                    </p>
                </div>
            </div>
            <!-- Row: Conteúdo -->
            <div class="row">
                <div class="container">
                    <!-- Row: Seleção do item -->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <asp:Label ID="Label3" runat="server" Text="Selecione o item:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Width="100%">
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="lblSelectItem" runat="server" Font-Size="Smaller" ForeColor="#CC0000"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Row: total itens no orçamento e valor unitário-->
            <div class="row">
                <div class="col-12 col-lg-8 offset-lg-2">
                    <div class="row">
                        <!-- Col: Total itens no orçamento -->
                        <div class="col-12 col-md-6">
                            <asp:Label ID="lblTotal" runat="server" Text="Total que será usado no projeto:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtTotal" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                        </div>
                        <!-- Col: valor unitário -->
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label4" runat="server" Text="Preço unitário em R$:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtUnitValue" CssClass="money2" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Row: Quantidade precisa comprar e botão adicionar--%>
            <div class="row">
                <div class="col-12 col-lg-8 offset-lg-2">
                    <div class="row">
                        <!-- Col: e quantidade precisa comprar -->
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label2" runat="server" Text="Quantidade que precisa comprar:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtNeedBuy" CssClass="number" runat="server" Width="100%"></asp:TextBox>
                        </div>
                        <!-- Col: Botão adicionar -->
                        <div class="col-12 col-md-6">
                            <asp:Label ID="lblType" runat="server" Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="btnAdd" CssClass="btn btn-success btn-sm" runat="server" Text="Adicionar item na lista" OnClick="btnAdd_Click" Width="100%" />
                        </div>
                    </div>
                </div>
            </div>

            <%-- Row: Gridview --%>
            <div class="row">
                <div class="col-12 col-lg-8 offset-lg-2">
                    <hr />
                    <p class="h5 text-center text-info">
                        <asp:Label ID="lblGdvItems" CssClass="" runat="server" Text=""></asp:Label>
                    </p>
                    <div class="table-responsive">
                        <asp:GridView CssClass="table table-success table-hover gdvItems" ID="gdvItems" runat="server" OnRowDataBound="gdvItems_RowDataBound">
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <br />
            <%-- Row: Botão salvar --%>
            <div class="row">
                <div class="col-12 col-lg-8 offset-lg-2">
                    <asp:Button ID="btnSave" CssClass="btn btn-success btn-sm" runat="server" Text="Salvar" OnClick="btnSave_Click" Width="100%" Enabled="False" />
                </div>
            </div>
            <br />
        </div>
</asp:Content>


