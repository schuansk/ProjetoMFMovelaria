<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.EmployeePage.Home" Title="" MasterPageFile="~/Master/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- todo o código dentro do content "head" gera o gráfico -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <%--<script src="../../Scripts/jquery-3.0.0.min.js"></script>--%>
    <script type="text/javascript">
        
            google.charts.load('current', {'packages':['corechart']});
            google.charts.setOnLoadCallback(drawChart);

            
        function drawChart() {
                // cria o datatable do gráfico
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Fornecedor');
                data.addColumn('number', 'Itens corretos');
                data.addColumn('number', 'Itens incorretos');
                data.addRows([
                    <%=ChartDados%>
                ]);

                // Opções do chart
                var options = {
                    'title': 'Qualidade dos fornecedores atuais',
                    legend: { position: 'bottom', alignment: 'end' }
                };

                // instancia e desenha o gráfico, passando as options
                var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
                chart.draw(data, options);
        }
    </script> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div>
        <p class="text-center h3">
            <asp:Label ID="lblMensage" runat="server" Text=""></asp:Label>

        </p>
    </div>
    <!--onde ta o gráfico-->
    <div id="chart_div" style="width: 800px; height: 500px;"></div>--%>

    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h3 class="text-center h3">
                    <asp:Label ID="lblMensage" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="col">
                    <div class="row">
                        <div class="col-12">
                            <div id="chart_div" style="width: 800px; height: 500px;"></div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-12">
                            <h3 class="text-center">Tempo em dias de cada projeto</h3>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <asp:Label class="mt-1 h6" ID="Label1" runat="server" Text="Selecione um orçamento que já foi entregue:&nbsp"></asp:Label>
                        <asp:DropDownList class="btn btn-outline-dark" Width="50%" ID="ddlFinishedBudgets" runat="server">
                        </asp:DropDownList>
                        <asp:Button class="btn btn-success" ID="btnFinishedBudget" runat="server" Text="Selecionar" OnClick="btnFinishedBudget_Click" AutoPostBack="false"/>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12">
                            <div class="table-responsive">
                                <asp:GridView ID="gdvLeadTimeKpi" CssClass="table table-success table-hover defaulttable" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                            <asp:BoundField DataField="etd_id" HeaderText="#ID" />
                                            <asp:BoundField DataField="etd_descricao" HeaderText="Etapa" />
                                            <asp:BoundField DataField="eta_data_inicio" HeaderText="Data início" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="eta_data_conclusao" HeaderText="Data conclusão" DataFormatString="{0:d}" />
                                        </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3 btn btn-success">
                        <asp:Label class="h5" ID="Label2" runat="server" Text="Total de dias acumulados (início até a entrega):"></asp:Label>
                        <b><asp:Label class="h5" ID="lblDiasAcumulados" runat="server" Text=""></asp:Label></b>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>

