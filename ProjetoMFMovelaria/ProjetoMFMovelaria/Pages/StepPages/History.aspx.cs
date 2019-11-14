using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Data;

namespace ProjetoMFMovelaria.Pages.StepPages
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int etaId = Convert.ToInt32(Request.QueryString["eta_id"]);
            LoadStepHistories(etaId);
        }

        protected void LoadStepHistories(int etaId)
        {
            StepBD stepBD = new StepBD();
            DataSet ds = stepBD.SelectStepById(etaId);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                gdvStepHistory.DataSource = ds.Tables[0].DefaultView;
                gdvStepHistory.DataBind();
                gdvStepHistory.HeaderRow.TableSection = TableRowSection.TableHeader;
                //lblMessage.Visible = false;
            }
            //else
            //{
            //    lblMessage.Visible = true;
            //}
        }
    }
}