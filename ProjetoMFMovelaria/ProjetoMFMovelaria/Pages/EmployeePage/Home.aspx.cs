using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Persistence;
using ProjetoMFMovelaria.App_Code.Class;

namespace ProjetoMFMovelaria.Pages.EmployeePage
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
                EmployeeDB bd = new EmployeeDB();
                Employee employee = bd.Select(id);

                if (!IsAdmin(employee.Type))
                {
                    Response.Redirect("../ErrorPages/AccessDanied.aspx");
                }
                else
                {
                    lblMensage.Text = "Bem-vindo, " + employee.Name;
                }
            }
            else
            {
                Response.Redirect("../ErrorPages/AccessDanied.aspx");
            }
        }

        private bool IsAdmin(int tipo)
        {
            bool retorno = false;

            if (tipo == 1)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}