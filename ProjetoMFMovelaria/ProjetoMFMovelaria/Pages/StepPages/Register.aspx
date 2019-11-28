<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="ProjetoMFMovelaria.Pages.StepPages.Register" Title="" MasterPageFile="~/Master/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Contant2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">&nbsp;<asp:Label ID="lblTitle" runat="server" Text="Cadastro de etapa"></asp:Label>
                </h1>
                <p class="text-center h1 text-white">
                    <%--<asp:HyperLink ID="urlStepHistory" CssClass="btn btn-info btn-sm" runat="server" NavigateUrl="#">Consultar etapas anteriores</asp:HyperLink>--%>
                    <asp:LinkButton ID="urlStepHistory" CssClass="btn btn-info btn-sm" runat="server" OnClick="urlStepHistory_Click">Consultar etapas anteriores</asp:LinkButton>
                </p>
                <p class="h5 text-center text-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:Label ID="lblEtaId" runat="server"></asp:Label>
                </p>
            </div>
        </div>
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <div class="row">
                            <asp:Label ID="Label1" class="h4" runat="server" Text="Orçamento: "></asp:Label>
                            <asp:Label ID="lblOrcamento" CssClass="h4" runat="server" Text="#"></asp:Label>
                        </div>
                        <div class="row">
                            <b>
                                <asp:Label ID="Label2" runat="server" Text="Data início: "></asp:Label></b>
                            <asp:Label ID="lblDataInicio" runat="server"></asp:Label>
                        </div>
                        <div class="row">
                            <b>
                                <asp:Label ID="Label3" runat="server" Text="Total orçamento: "></asp:Label></b>
                            <asp:Label ID="lblTotal" runat="server" Text="110"></asp:Label>
                        </div>
                        <div class="row">
                            <b>
                                <asp:Label ID="Label4" runat="server" Text="Funcionário responsável: "></asp:Label></b>
                            <asp:Label ID="lblResponsavel" runat="server" Text="Amanda"></asp:Label>
                        </div>
                        <div class="row">
                            <b>
                                <asp:Label ID="Label5" runat="server" Text="Cliente: "></asp:Label></b>
                            <asp:Label ID="lblCliente" runat="server" Text="pessoa@pessoa.com"></asp:Label>
                        </div>
                        <div class="row">
                            <b>
                                <asp:Label ID="Label10" runat="server" Text="Data de conclusão do projeto:"></asp:Label></b>
                            <asp:Label ID="lblDataConclusao" runat="server" Text="Projeto" DataFormatString="{0:d}"></asp:Label>
                        </div>
                        <div class="row">
                            <b>
                                <asp:Label ID="Label6" runat="server" Text="Etapa atual:"></asp:Label></b>
                            <asp:Label ID="lblEtapaAtual" runat="server" Text="Projeto" Style="background-color: #4cff00; border-radius: 5px;"></asp:Label>
                        </div>
                        <br />
                        <div class="row">
                            <b>
                                <asp:Label ID="Label7" runat="server" Text="Nova etapa:"></asp:Label></b>
                            <asp:DropDownList ID="listEtapa" runat="server" Width="100%">
                                <asp:ListItem>Selecione</asp:ListItem>
                                <asp:ListItem>Aguardando material</asp:ListItem>
                                <asp:ListItem>Separação</asp:ListItem>
                                <asp:ListItem>Corte</asp:ListItem>
                                <asp:ListItem>Usinagem</asp:ListItem>
                                <asp:ListItem>Montagem</asp:ListItem>
                                <asp:ListItem>Aguardando entrega</asp:ListItem>
                                <asp:ListItem>Entregue</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="row">
                            <asp:Label ID="Label9" runat="server" Text="Próxima etapa:"></asp:Label>
                            <asp:Label ID="lblNextStep" runat="server"></asp:Label>
                        </div>
                        <br />
                        <div class="row">
                            <b>
                                <asp:Label ID="Label8" runat="server" Text="Descrição:"></asp:Label></b>
                        </div>
                        <div class="row">
                            <textarea runat="server" id="txtDescricao" style="width: 100%;" cols="20" name="S1" rows="2"></textarea>
                        </div>
                        <br />
                        <div class="row">
                            <asp:CheckBox ID="checkboxSendEmail" runat="server" Checked="True" Text="Deseja enviar e-mail sobre a etapa para o cliente?" />
                        </div>
                        <div class="row">
                            <asp:Button class="btn btn-success btn-block" ID="btnCadastrarEtapa" runat="server" Text="Cadastrar" OnClick="btnCadastrarEtapa_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

