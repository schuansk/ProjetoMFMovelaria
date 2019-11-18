using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjetoMFMovelaria.App_Code.Persistence;

namespace ProjetoMFMovelaria.Pages.OrderPages
{
    public partial class SelectSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarrySupplier();
            }
        }

        // CARREGA TODOS OS FORNECEDORES NO DDLSUPPLIER
        private void CarrySupplier()
        {
            SupplierDB db = new SupplierDB();
            DataSet ds = db.SelectAllActive();

            ddlSupplier.DataSource = ds.Tables[0].DefaultView;
            ddlSupplier.DataTextField = "for_nome";
            ddlSupplier.DataValueField = "for_id";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, "Selecione");
        }

        protected void lkbNextPage_Click(object sender, EventArgs e)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);

            if (ddlSupplier.SelectedItem.Text != "Selecione")
            {
                string forId = ddlSupplier.SelectedItem.Value;
                Response.Redirect("NewRequest.aspx?orc_id=" + orcId + "&for_id=" + forId);
            }
            else
            {
                lblMessage.Text = "Um fornecedor precisa ser selecionado para prosseguir.";
            }
        }
    }
}