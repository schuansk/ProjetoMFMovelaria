<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToList.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.RequestItemPages.ToList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Itens do pedido</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../../Content/DataTables/css/buttons.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container mt-4 mb-4">
        <div class="row">
            <div class="col">
                <form id="form1" runat="server">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gdvRequestItems" runat="server" AutoGenerateColumns="False" CssClass="table table-success table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="pei_id" HeaderText="#ID" />
                                            <asp:BoundField DataField="pei_descricao" HeaderText="Descrição" />
                                            <asp:BoundField DataField="pei_tipo" HeaderText="Tipo" />
                                            <asp:BoundField DataField="pei_quantidade" HeaderText="Quantidade" />
                                            <asp:BoundField DataField="pei_preco" HeaderText="Preço" />
                                            <asp:BoundField DataField="pei_ativo" HeaderText="Status" />
                                            <asp:BoundField DataField="pei_correto" HeaderText="Correto" />
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
