using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using ProjetoMFMovelaria.App_Code.Persistence;

namespace ProjetoMFMovelaria.Pages.BudgetPages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Plan1$]", mycon);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            mycon.Close();
           
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int id = 0;
            BudgetBD orcamentobd = new BudgetBD();
            if (Session["ID"] != null)
            {
                id = Convert.ToInt32(Session["ID"]);

            }

            bool sucesso = true;

            
                if (orcamentobd.Insert(DateTime.Now, GridView1.Rows[0].Cells[0].Text, GridView1.Rows[0].Cells[1].Text, id))
                {
                    BudgetItemBD orcamentoItem = new BudgetItemBD();
                    BudgetBD budget = new BudgetBD();
                    int lastId = budget.SelectLastBudget();

                    for (int j = 0; j < GridView1.Rows.Count; j++)
                    {
                        if (orcamentoItem.Insert(GridView1.Rows[j].Cells[2].Text, GridView1.Rows[j].Cells[3].Text, GridView1.Rows[j].Cells[4].Text, GridView1.Rows[j].Cells[5].Text, 1, lastId))
                        {
                            sucesso = true;
                            
                        }
                        else
                        {
                            sucesso = false;
                            
                        }
                    }
                


            }


            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{

            //}

        }
    }
}