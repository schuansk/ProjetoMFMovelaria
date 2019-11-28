<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListOrders.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.OrderPages.ListOrders" Title="" MasterPageFile="~/Master/Master.Master" %>

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

                <h1 class="text-center h4 text-success">
                    <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
                </h1>
                <p class="text-center h1">
                    <asp:LinkButton ID="lbtNewRequest" CssClass="btn btn-info" runat="server" OnClick="lbtNewRequest_Click">Adicionar pedido</asp:LinkButton>
                </p>
                <p class="text-center h4">
                    <asp:Label ID="lblNotFoundOrders" runat="server" Enabled="False" ForeColor="#666666" Text="Ainda não há pedidos para esse orçamento." Visible="False"></asp:Label>
                </p>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="col">
                <div class="container">
                    <div class="row">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvOrders" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvOrders_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="ped_id" HeaderText="Id" />
                                        <asp:BoundField DataField="ped_data" HeaderText="Data" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="for_nome" HeaderText="Fornecedor" />
                                        <asp:TemplateField HeaderText="Ações">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnItens" CssClass="btn btn-success" runat="server" CommandName="Itens"
                                                    CommandArgument='<%#Bind("ped_id")%>'>Visualizar itens</asp:LinkButton>
                                                <asp:LinkButton ID="btnErros" CssClass="btn btn-danger" runat="server" CommandName="Erros"
                                                    CommandArgument='<%#Bind("ped_id")%>'>Cadastrar erros</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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


