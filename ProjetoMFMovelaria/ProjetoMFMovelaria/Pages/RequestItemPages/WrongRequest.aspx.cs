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
    public partial class WrongRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // RECEBE O ID DO PEDIDO POR URL E PASSA PARA CARRYITEMS
                int idPed = Convert.ToInt32(Request.QueryString["ped_id"]);
                CarryItems(idPed);
            }
        }

        //METODO RESPONSAVEL POR CARREGAR OS ITENS DO PEDIDO_ITEM
        private void CarryItems(int idPed)
        {
            RequestItemBD db = new RequestItemBD();
            DataSet ds = db.SelectItemsById(idPed);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                gdvItems.DataSource = ds.Tables[0].DefaultView;
                gdvItems.DataBind();
            }
        }

        protected void gdvItems_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvItems.EditIndex = e.NewEditIndex;

            int idPed = Convert.ToInt32(Request.QueryString["ped_id"]);
            CarryItems(idPed);
        }

        protected void gdvItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RequestItemBD db = new RequestItemBD();

            Label id = gdvItems.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox wrong = gdvItems.Rows[e.RowIndex].FindControl("txtWrong") as TextBox;

            // VERIFICA SE O NUMERO DE ERROS FOI ATUALIZADO COM SUCESSO
            if (db.Update(Convert.ToInt32(id.Text), Convert.ToInt32(wrong.Text)))
            {
                lblMessage.Text = "sucesso";
                gdvItems.EditIndex = -1;

                int idPed = Convert.ToInt32(Request.QueryString["ped_id"]);
                CarryItems(idPed);
            }
            else
            {
                lblMessage.Text = "Erro";
            }
        }

        protected void gdvItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvItems.EditIndex = -1;

            int idPed = Convert.ToInt32(Request.QueryString["ped_id"]);
            CarryItems(idPed);
        }
    }
}