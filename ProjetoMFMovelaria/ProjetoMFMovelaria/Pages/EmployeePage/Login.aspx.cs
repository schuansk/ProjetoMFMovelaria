using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjetoMFMovelaria.App_Code.Persistence;
using ProjetoMFMovelaria.App_Code.Class;

namespace ProjetoMFMovelaria.Pages.EmployeePage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool IsPreenchido(string str)
        {
            bool retorno = false;
            if (str != string.Empty)
            {
                retorno = true;
            }
            return retorno;
        }

        private bool UsuarioEncontrado(Employee employee)
        {
            bool retorno = false;
            if (employee != null)
            {
                retorno = true;
            }
            return retorno;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txbUsuario.Text.Trim();
            string senha = txbSenha.Text.Trim();

            if (!IsPreenchido(email))
            {
                lblMensagem.Text = "Preencha o usuario";
                txbUsuario.Focus();
                return;
            }
            if (!IsPreenchido(senha))
            {
                lblMensagem.Text = "Preencha a senha";
                txbSenha.Focus();
                return;
            }

            EmployeeDB bd = new EmployeeDB();
            Employee func = new Employee();

            func = bd.Autentica(email, senha);
            if (!UsuarioEncontrado(func))
            {
                lblMensagem.Text = "Usuário não encontrado";
                txbUsuario.Focus();
                return;
            }
            Session["ID"] = func.Id;
            switch (func.Type)
            {
                case 1:
                    Response.Redirect("Home.aspx");
                    break;
                default:
                    break;
            }
        }
    }
}