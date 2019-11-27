<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToListBudget.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.BudgetPages.ToListBudget" Title="" MasterPageFile="~/Master/Master.Master" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listar orçamentos</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/buttons.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Orçamentos cadastrados"></asp:Label>
                </h1>
                <p class="text-center h5">
                    <asp:Label ID="lblStatus" runat="server" Enabled="False" ForeColor="#666666" Text="Status True: Orçamento ativo || Status False: Orçamento cancelado" Visible="True"></asp:Label>
                </p>
                <p class="text-center h4">
                    <asp:Label ID="lblMessage" runat="server" Enabled="False" ForeColor="#666666" Text="Não há orçamentos para listar" Visible="False"></asp:Label>
                </p>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row col-lg-6">
            <div class="col">

                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvBudget" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvOrc_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="orc_id" HeaderText="ID" />
                                        <asp:BoundField DataField="orc_data_inicio" HeaderText="Data de início" DataFormatString="{0:d}"/>
                                        <asp:BoundField DataField="orc_email" HeaderText="E-mail do cliente" />
                                        <asp:BoundField DataField="orc_total_orcamento" HeaderText="Valor total" DataFormatString="R${0:N2}" />
                                        <asp:BoundField DataField="fun_nome" HeaderText="Funcionário" />
                                        <asp:BoundField DataField="orc_ativo" HeaderText="Status" />
                                        <asp:TemplateField HeaderText="Ações">
                                            <ItemTemplate>
                                                <asp:LinkButton CssClass="btn btn-primary" ID="btnEtapa" runat="server" CommandName="Etapa"
                                                    CommandArgument='<%#Bind("orc_id")%>'>Etapa</asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-success" ID="btnPedido" runat="server" CommandName="Pedido"
                                                    CommandArgument='<%#Bind("orc_id")%>'>Pedido</asp:LinkButton>
                                                <asp:Button CssClass="btn btn-danger" ID="statSwitch" runat="server" Text="Cancelar"
                                                    CommandName="Cancelar" CommandArgument='<%# Container.DataItemIndex %>'
                                                    OnClientClick="return confirm('Clique em OK apenas se tiver certeza de que deseja desativar este orcamento. Do contrario, clique em CANCELAR.');" />
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


<%-- </form>


    <script src="../../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="../../Scripts/DataTables/dataTables.buttons.min.js"></script>
    <script src="../../Scripts/DataTables/buttons.flash.min.js"></script>
    <script src="../../Scripts/DataTables/buttons.html5.min.js"></script>
    <script src="../../Scripts/DataTables/buttons.colVis.min.js"></script>
    <script src="../../Scripts/jszip.min.js"></script>
    <script src="../../Scripts/pdfmake.min.js"></script>
    <script src="../../Scripts/vfs_fonts.js"></script>
    <script src="../../Scripts/project.js"></script>
</body>
</html>--%>
