<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.StepPages.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Etapas anteriores</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/buttons.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4 mb-4">
            <div class="row">
                <div class="col">
                    <h1 class="text-center h1">
                        <asp:Label ID="lblTitle" runat="server" Text="Etapas anteriores"></asp:Label>
                    </h1>
                    <br />
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gdvStepHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-success table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="etd_id" HeaderText="#ID" />
                                            <asp:BoundField DataField="etd_descricao" HeaderText="Etapa" />
                                            <asp:BoundField DataField="eta_data_inicio" HeaderText="Data início" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="eta_data_conclusao" HeaderText="Data conclusão" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="orc_email" HeaderText="E-mail cliente" />
                                            <asp:BoundField DataField="eta_desc" HeaderText="Descrição" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="../../Scripts/DataTables/dataTables.buttons.min.js"></script>
    <script src="../../Scripts/DataTables/buttons.flash.min.js"></script>
    <script src="../../Scripts/DataTables/buttons.html5.min.js"></script>
    <script src="../../Scripts/DataTables/buttons.colVis.min.js"></script>
    <script src="../../Scripts/jszip.min.js"></script>
    <script src="../../Scripts/vfs_fonts.js"></script>
    <script src="../../Scripts/project.js"></script>
</body>
</html>
