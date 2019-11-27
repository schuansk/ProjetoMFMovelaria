<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="TESTE5.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.EmployeePage.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- todo o código dentro do content "head" gera o gráfico -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
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
    <div>
        <p class="text-center h3">
            <asp:Label ID="lblMensage" runat="server" Text=""></asp:Label>

        </p>
    </div>
    <!--onde ta o gráfico-->
    <div id="chart_div" style="width: 800px; height: 500px;"></div>
</asp:Content>

