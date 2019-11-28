<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToList.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.SupplierPages.ToList" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Contant2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Fornecedores cadastrados"></asp:Label>
                </h1>
                <p class="text-center h1">
                    <asp:HyperLink ID="hlkToList" CssClass="btn btn-info btn-sm" runat="server" NavigateUrl="~/Pages/SupplierPages/Register.aspx">Cadastrar novo fornecedor</asp:HyperLink>
                </p>
                <p class="text-center h4">
                    <asp:Label ID="lblMessage" runat="server" Enabled="False" ForeColor="#666666" Text="Não há fornecedores para listar" Visible="False"></asp:Label>
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
                                <asp:GridView ID="gdvSupplier" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="for_nome" HeaderText="Fornecedor" />
                                        <asp:BoundField DataField="for_cnpj" HeaderText="CNPJ" />
                                        <asp:BoundField DataField="for_email" HeaderText="Email" />
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