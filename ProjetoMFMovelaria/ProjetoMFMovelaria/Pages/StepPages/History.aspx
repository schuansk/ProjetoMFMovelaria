<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.StepPages.History" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Contant2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Etapas anteriores"></asp:Label>
                </h1>
                <br />
                <div class="container">
                    <div class="row">
                        <div class="col-md-10 col-md-offset-1">
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
</asp:Content>
