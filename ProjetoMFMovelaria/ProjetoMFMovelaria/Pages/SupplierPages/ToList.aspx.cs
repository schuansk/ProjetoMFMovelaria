using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Data;

namespace ProjetoMFMovelaria.Pages.SupplierPages
{
    public partial class ToList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarrySuppliers();
        }

        private void CarrySuppliers()
        {
            SupplierDB bd = new SupplierDB();
            DataSet ds = bd.SelectAll();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                gdvSupplier.DataSource = ds.Tables[0].DefaultView;
                gdvSupplier.DataBind();
                gdvSupplier.HeaderRow.TableSection = TableRowSection.TableHeader;
                lblMessage.Visible = false;
            }
            else
            {
                lblMessage.Visible = true;
            }
        }
    }
}