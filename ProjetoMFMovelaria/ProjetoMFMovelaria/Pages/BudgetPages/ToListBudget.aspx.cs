using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Data;

namespace ProjetoMFMovelaria.Pages.BudgetPages
{
    public partial class ToListBudget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarryBudgets();
        }
        private void CarryBudgets()
        {
            BudgetBD bd = new BudgetBD();
            DataSet ds = bd.SelectAll();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                gdvBudget.DataSource = ds.Tables[0].DefaultView;
                gdvBudget.DataBind();
                gdvBudget.HeaderRow.TableSection = TableRowSection.TableHeader;
                lblMessage.Visible = false;
            }
            else
            {
                lblMessage.Visible = true;
            }
        }
    }
}