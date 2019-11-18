using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Data;

namespace ProjetoMFMovelaria.Pages.RequestItemPages
{
    public partial class ToList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pedId = Convert.ToInt32(Request.QueryString["ped_id"]);
            LoadRequestItems(pedId);
        }

        protected void LoadRequestItems(int pedId)
        {
            RequestItemBD requestItemBD = new RequestItemBD();
            DataSet ds = requestItemBD.SelectItemsById(pedId);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                gdvRequestItems.DataSource = ds.Tables[0].DefaultView;
                gdvRequestItems.DataBind();
                gdvRequestItems.HeaderRow.TableSection = TableRowSection.TableHeader;
                //lblMessage.Visible = false;
            }
            //else
            //{
            //    lblMessage.Visible = true;
            //}
        }
    }
}