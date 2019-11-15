using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;

namespace ProjetoMFMovelaria.Pages.OrderPages
{
    public partial class ListOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);

            lblBudget.Text = "Orçamento #" + orcId.ToString();
            CarryOrders(orcId);
        }

        private void CarryOrders(int orc_id)
        {
            OrderDB db = new OrderDB();
            DataSet ds = db.SelectAllFromBudget(orc_id);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                gdvOrders.DataSource = ds.Tables[0].DefaultView;
                gdvOrders.DataBind();
                gdvOrders.HeaderRow.TableSection = TableRowSection.TableHeader;
                lblNotFoundOrders.Visible = false;
            }
            else
            {
                lblNotFoundOrders.Visible = true;
            }
        } 
    }
}