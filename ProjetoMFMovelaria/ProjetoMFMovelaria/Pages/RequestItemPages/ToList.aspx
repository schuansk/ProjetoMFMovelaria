<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToList.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.RequestItemPages.ToList" Title="" MasterPageFile="~/Master/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <div class="row">
            <div class="col">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvRequestItems" runat="server" AutoGenerateColumns="False" CssClass="table table-success table-hover gdvRequestItems">
                                    <Columns>
                                        <asp:BoundField DataField="pei_id" HeaderText="#ID" />
                                        <asp:BoundField DataField="pei_descricao" HeaderText="Descrição" />
                                        <asp:BoundField DataField="pei_tipo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="pei_quantidade" HeaderText="Quantidade" />
                                        <asp:BoundField DataField="pei_preco_uni" HeaderText="Preço" />
                                        <asp:BoundField DataField="pei_ativo" HeaderText="Status" />
                                        <asp:BoundField DataField="pei_errado" HeaderText="Correto" />
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
