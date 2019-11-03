<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToList.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.SupplierPages.ToList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listar fornecedores</title>
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
                <form id="form1" runat="server">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gdvSupplier" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="for_nome" HeaderText="Fornecedor" />
                                            <asp:BoundField DataField="for_cnpj" HeaderText="CNPJ" />
                                            <asp:BoundField DataField="for_email" HeaderText="E-mail" />
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
