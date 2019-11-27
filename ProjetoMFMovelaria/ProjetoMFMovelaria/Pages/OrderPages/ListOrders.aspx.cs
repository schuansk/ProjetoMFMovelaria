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

            bool success = Convert.ToBoolean(Request.QueryString["success"]);

            if (success)
            {
                lblMessageSuccess.Text = "Pedido gerado com sucesso";
            }

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

        protected void lbtNewRequest_Click(object sender, EventArgs e)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);
            Response.Redirect("SelectSupplier.aspx?orc_id=" + orcId);
        }

        protected void gdvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Itens")
            {
                string ped_id = e.CommandArgument.ToString();
                Response.Redirect("../RequestItemPages/ToList.aspx?ped_id=" + ped_id);
            }

            if (e.CommandName == "Erros")
            {
                string ped_id = e.CommandArgument.ToString();
                Response.Redirect("../RequestItemPages/WrongRequest.aspx?ped_id=" + ped_id);
            }
        }
    }
}