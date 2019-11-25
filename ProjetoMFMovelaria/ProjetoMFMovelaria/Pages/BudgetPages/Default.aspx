<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetoMFMovelaria.Pages.BudgetPages.Default" 
    Title="" MasterPageFile="~/Master/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Contant2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-4">
        <!-- Row: Cabeçalho -->
        <div class="row">
            <div class="col">
                <h1 class="text-center h1">
                    <asp:Label ID="lblTitle" runat="server" Text="Upload planilha Excel"></asp:Label>
                </h1>              

            </div>
        </div>

        <div>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Arquivo: </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <br />
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Upload" />
                        <br />
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
        <p>
            &nbsp;
            <asp:GridView ID="GridView1" CssClass="table table-success table-hover defaulttable" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnSalvar" CssClass="btn btn btn-success" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            <br />
   </div>

 </asp:Content> 