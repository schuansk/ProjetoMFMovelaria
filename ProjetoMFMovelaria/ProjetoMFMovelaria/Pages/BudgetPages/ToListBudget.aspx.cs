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
            if (!IsPostBack)
            {
                CarryBudgets();
            }
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
                lblStatus.Visible = true;
            }
            else
            {
                lblMessage.Visible = true;
                lblStatus.Visible = false;
            }
        }
        protected void gdvOrc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancelar")
            {
                BudgetBD bd = new BudgetBD();
                Budget budget = new Budget();

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gdvBudget.Rows[rowIndex];

                string strStatus = row.Cells[5].Text;

                budget.Id = Convert.ToInt32(row.Cells[0].Text);


                if (strStatus.Equals("True"))
                {
                    if (bd.UpdateBudget(budget))
                    {
                        Response.Redirect(Request.RawUrl, false);
                    }
                }
                else
                {
                    Response.Redirect(Request.RawUrl, false);
                }
            }
        }
    }
}