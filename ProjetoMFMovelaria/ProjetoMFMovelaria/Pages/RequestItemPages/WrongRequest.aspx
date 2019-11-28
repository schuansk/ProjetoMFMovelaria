<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WrongRequest.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.RequestItemPages.WrongRequest"
    Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Contant2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Pedidos com Erros"></asp:Label>
                </h1>
                <%--<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>--%>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="col">
                <div class="container">
                    <div class="row">
                        <div class="col-md-10 col-md-offset-1">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvItems" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gdvItems_RowCancelingEdit" OnRowEditing="gdvItems_RowEditing" OnRowUpdating="gdvItems_RowUpdating">
                                    <Columns>
                                        <%--ID--%>
                                        <asp:TemplateField HeaderText="Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("pei_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--DESCRICAO--%>
                                        <asp:TemplateField HeaderText="Descrição">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescribe" runat="server" Text='<%#Eval("pei_descricao") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--QUANTIDADE--%>
                                        <asp:TemplateField HeaderText="Quantidade">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuant" runat="server" Text='<%#Eval("pei_quantidade") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--ERRADOS--%>
                                        <asp:TemplateField HeaderText="Errados">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWrong" runat="server" Text='<%#Eval("pei_errado") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtWrong" runat="server" Text='<%#Eval("pei_errado") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <%--AÇÃO--%>
                                        <asp:TemplateField HeaderText="Ações">
                                            <ItemTemplate>
                                                <asp:Button ID="btn_Edit" CssClass="btn btn-primary" runat="server" Text="Adicionar errados" CommandName="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btn_Update" CssClass="btn btn-success" runat="server" Text="Salvar" CommandName="Update" />
                                                <asp:Button ID="btn_Cancel" CssClass="btn btn-danger" runat="server" Text="Cancelar" CommandName="Cancel" />
                                            </EditItemTemplate>
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


