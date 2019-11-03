<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.SupplierPages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de forncedor</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <!-- Conianter: principal -->
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Cadastro de fornecedor"></asp:Label>
                </h1>
                <p class="text-center h1 text-white">
                    <asp:HyperLink ID="hlkToList" CssClass="btn btn-info btn-sm" runat="server" NavigateUrl="~/Pages/SupplierPages/ToList.aspx">Consultar fornecedores cadastrados</asp:HyperLink>
                </p>
                <p class="h5 text-center text-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </p>
                <p class="h5 text-danger text-center">
                    <asp:Label ID="lblMessageCNPJ" runat="server" ForeColor="#CC0000"></asp:Label>
                </p>
            </div>
        </div>
        <!-- Row: Conteúdo -->
        <div class="row">
            <div class="container">
                <form id="form1" runat="server">
                    <!-- Row: Nome do fornecedor -->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <asp:Label ID="lblName" runat="server" Text="Nome do fornecedor:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtName" runat="server" Width="100%"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Preencha o campo nome do fornecedor" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!-- Row: CNPJ e Email -->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <div class="row">
                                <!-- Col: CNPJ -->
                                <div class="col-12 col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="CNPJ: "></asp:Label>
                                    <asp:RegularExpressionValidator ID="revCNPJ" runat="server" ControlToValidate="txtCNPJ" ErrorMessage="O CNPJ está incorreto" ForeColor="#CC0000" ValidationExpression="[0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2}"></asp:RegularExpressionValidator>
                                    <br />
                                    <asp:TextBox ID="txtCNPJ" CssClass="cnpj" runat="server" Width="100%"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvCNPJ" runat="server" ControlToValidate="txtCNPJ" ErrorMessage="Preencha o campo CNPJ" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <!-- Col: Email -->
                                <div class="col-12 col-md-6">
                                    <asp:Label ID="lblEmail" runat="server" Text="E-mail: "></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="O e-mail está incorreto" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <br />
                                    <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Preencha o campo e-mail" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Row: Estado e Cidade -->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <div class="row">
                                <!-- Col: Estado -->
                                <div class="col-3">
                                    <asp:Label ID="lblUF" runat="server" Text="Estado:"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlUf" runat="server" Width="100%">
                                        <asp:ListItem>Selecione</asp:ListItem>
                                        <asp:ListItem>AC</asp:ListItem>
                                        <asp:ListItem>AL</asp:ListItem>
                                        <asp:ListItem>AP</asp:ListItem>
                                        <asp:ListItem>AM</asp:ListItem>
                                        <asp:ListItem>BA</asp:ListItem>
                                        <asp:ListItem>CE</asp:ListItem>
                                        <asp:ListItem>DF</asp:ListItem>
                                        <asp:ListItem>ES</asp:ListItem>
                                        <asp:ListItem>GO</asp:ListItem>
                                        <asp:ListItem>MA</asp:ListItem>
                                        <asp:ListItem>MT</asp:ListItem>
                                        <asp:ListItem>MS</asp:ListItem>
                                        <asp:ListItem>MG</asp:ListItem>
                                        <asp:ListItem>PA</asp:ListItem>
                                        <asp:ListItem>PB</asp:ListItem>
                                        <asp:ListItem>PR</asp:ListItem>
                                        <asp:ListItem>PE</asp:ListItem>
                                        <asp:ListItem>PI</asp:ListItem>
                                        <asp:ListItem>RJ</asp:ListItem>
                                        <asp:ListItem>RN</asp:ListItem>
                                        <asp:ListItem>RS</asp:ListItem>
                                        <asp:ListItem>RO</asp:ListItem>
                                        <asp:ListItem>RR</asp:ListItem>
                                        <asp:ListItem>SC</asp:ListItem>
                                        <asp:ListItem>SP</asp:ListItem>
                                        <asp:ListItem>SE</asp:ListItem>
                                        <asp:ListItem>TO</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:CompareValidator ID="cvUf" runat="server" ControlToValidate="ddlUf" ErrorMessage="Selecione um estado" Operator="NotEqual" SetFocusOnError="True" ValueToCompare="Selecione" ForeColor="#CC0000">Selecione um estado</asp:CompareValidator>
                                </div>
                                <!-- Col: Cidade -->
                                <div class="col-9">
                                    <asp:Label ID="lblCity" runat="server" Text="Cidade:"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtCity" runat="server" Width="100%"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity" ErrorMessage="Preencha o campo cidade" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Row: Add Telefone e Lista telefone-->
                    <div class="row">
                        <div class="col-12 col-lg-8 offset-lg-2">
                            <div class="row">
                                <!-- Col: Add Telefone -->
                                <div class="col-12 col-md-6">
                                    <asp:Label ID="lblAddPhone" runat="server" Text="Telefone:"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtAddNumber" CssClass="input-your-tel" runat="server" Width="100%"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnAddNumber" CssClass="btn btn-info btn-sm" runat="server" OnClick="btnAddNumber_Click" Text="Adicionar número" Width="100%" />
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAddNumber" ErrorMessage="Esse número não está em um formato correto." ForeColor="#CC0000" ValidationExpression="^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$"></asp:RegularExpressionValidator>
                                    <br />
                                    <asp:Label ID="lblVerify" runat="server" ForeColor="#CC0000"></asp:Label>
                                </div>
                                <!-- Col: Lista Telefone -->
                                <div class="col-12 col-md-6">
                                    <p class="text-center">
                                        <asp:Label ID="Label456" runat="server" Text="Telefones adicionados:"></asp:Label>
                                        <br />
                                        <asp:CheckBoxList ID="cblNumber" runat="server" EnableTheming="False"></asp:CheckBoxList>
                                    </p>
                                    <asp:Label ID="lblMessagePhone" runat="server" ForeColor="#CC0000"></asp:Label>
                                    <asp:Button ID="btnRemoveNumber" CssClass="btn btn-danger btn-sm" runat="server" OnClick="btnRemoveNumber_Click" Text="Remover" Width="100%" />
                                    <p class="text-info">
                                        <asp:Label ID="Label3434" runat="server" Text="Selecione um telefone e clique em remover para removê-lo."></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <!-- Row: Botão salvar -->
                    <div class="row">
                        <div class="offset-4 col-4">
                            <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Salvar" OnClick="btnSave_Click" Width="100%" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="../../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../../Scripts/jquery.mask.min.js"></script>
    <script src="../../Scripts/project.js"></script>
</body>
</html>
