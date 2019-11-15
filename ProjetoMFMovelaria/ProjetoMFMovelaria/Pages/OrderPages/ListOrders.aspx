<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListOrders.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.OrderPages.ListOrders" Title="" MasterPageFile="~/Master/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Contant2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Pedido(s) do"></asp:Label>
                    <asp:Label ID="lblBudget" runat="server" Text=""></asp:Label>
                </h1>
                <p class="text-center h1">
                    <asp:HyperLink ID="hlkToList" CssClass="btn btn-info btn-sm" runat="server" NavigateUrl="~/Pages/OrderPages/NewRequest.aspx">Novo pedido</asp:HyperLink>
                </p>
                <p class="text-center h4">
                    <asp:Label ID="lblNotFoundOrders" runat="server" Enabled="False" ForeColor="#666666" Text="Ainda não há pedidos para esse orçamento" Visible="False"></asp:Label>
                </p>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="col">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvOrders" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="ped_id" HeaderText="Id" />
                                        <asp:BoundField DataField="ped_data" HeaderText="Data" DataFormatString="{0:d}"/>
                                        <asp:BoundField DataField="for_nome" HeaderText="Fornecedor" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


