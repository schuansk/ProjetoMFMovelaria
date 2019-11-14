﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.StepPages.History" %>

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
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="gdvStepHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-success table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="eta_id" HeaderText="#ID" />
                                            <asp:BoundField DataField="eta_nome" HeaderText="Etapa" />
                                            <asp:BoundField DataField="eta_data_inicio" HeaderText="Data início" />
                                            <asp:BoundField DataField="eta_data_conclusao" HeaderText="Data conclusão" />
                                            <asp:BoundField DataField="orc_id" HeaderText="E-mail cliente" />
                                            <asp:BoundField DataField="eta_desc" HeaderText="Descrição" />
                                            <%--<asp:BoundField DataField="pei_correto" HeaderText="Correto" />--%>
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