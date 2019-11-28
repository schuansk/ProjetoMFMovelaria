<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToList.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.RequestItemPages.ToList" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Lista de pedidos"></asp:Label>
                    <br />
                    <asp:Label ID="Supplier" runat="server" Text=""></asp:Label>
                 </h1>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="container">
                    <div class="row">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvRequestItems" runat="server" AutoGenerateColumns="False" CssClass="table table-success table-hover gdvRequestItems">
                                    <Columns>
                                        <asp:BoundField DataField="pei_id" HeaderText="#ID" />
                                        <asp:BoundField DataField="pei_descricao" HeaderText="Descrição" />
                                        <asp:BoundField DataField="pei_tipo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="pei_quantidade" HeaderText="Quantidade" />
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
