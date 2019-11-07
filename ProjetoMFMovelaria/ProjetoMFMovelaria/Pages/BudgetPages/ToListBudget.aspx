<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToListBudget.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.BudgetPages.ToListBudget" %>

<!DOCTYPE html>

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
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Orçamentos cadastrados"></asp:Label>
                </h1>
                <p class="text-center h4">
                    <asp:Label ID="lblMessage" runat="server" Enabled="False" ForeColor="#666666" Text="Não há orçamentos para listar" Visible="False"></asp:Label>
                </p>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="col">
                <form id="form1" runat="server">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gdvBudget" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="orc_email" HeaderText="Email" />
                                            <asp:BoundField DataField="orc_data_inicio" HeaderText="Data de inicio" />
                                            <asp:TemplateField>
                                                 <ItemTemplate>
                                                 <asp:LinkButton ID="btnEtapa" runat="server" CommandName="Etapa"
                                                CommandArgument='<%# Bind("orc_id")%>'>Etapa</asp:LinkButton>
                                                 </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                 <ItemTemplate>
                                                 <asp:LinkButton ID="btnCancelar" runat="server" CommandName="Cancelar"
                                                CommandArgument='<%# Bind("orc_id")%>'>Cancelar</asp:LinkButton>
                                                 </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

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
</html>
