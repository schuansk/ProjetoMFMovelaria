using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Data;

namespace ProjetoMFMovelaria.Pages.Test
{
    public partial class ConnTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            toList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ConnTest connTest = new ConnTest();

            connTest.Name = txtName.Text;

            ConnTestDB db = new ConnTestDB();

            if (db.Insert(connTest))
            {
                lblMessage.Text = "Deu certo, amiguinho!";
                txtName.Text = "";
            }
            else
            {
                lblMessage.Text = "Ops, deu ruim!";
            }
        }

        private void toList()
        {
            ConnTestDB db = new ConnTestDB();
            DataSet ds = db.SelectAll();

            int amount = ds.Tables[0].Rows.Count;

            if (amount > 0)
            {
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                lblMessageList.Text = amount + " registro(s) encontrado(s)";
            } else
            {
                lblMessageList.Text = "Algo deu errado, nenhum registro foi localizado";
            }          
        }
    }
}