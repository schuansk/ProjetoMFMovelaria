using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Persistence;
using ProjetoMFMovelaria.App_Code.Class;
using System.Data;

namespace ProjetoMFMovelaria.Pages.EmployeePage
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
                EmployeeDB bd = new EmployeeDB();
                Employee employee = bd.Select(id);

                if (!IsAdmin(employee.Type))
                {
                    Response.Redirect("../ErrorPages/AccessDanied.aspx");
                }
                else
                {
                    lblMensage.Text = "Bem-vindo, " + employee.Name;
                    LoadCharts();
                }
            }
            else
            {
                Response.Redirect("../ErrorPages/AccessDanied.aspx");
            }
        }

        private bool IsAdmin(int tipo)
        {
            bool retorno = false;

            if (tipo == 1)
            {
                retorno = true;
            }
            return retorno;
        }
        //string que vai do back para o front do Home
        private string dados;
        public string ChartDados { get { return dados; } }
        //função que abastece o gráfico com as informações do fornecedor e seus itens
        public void LoadCharts()
        {
            RequestItemBD requestItemBD = new RequestItemBD();
            RequestItem requestItem = new RequestItem();

            DataSet ds = new DataSet();
            ds = requestItemBD.TotalSuppliers();
            int totSup = (Int32)(ds.Tables[0].Rows[0][0]);

            int i = 0;
            for (i = 1; i <= totSup; i++)
            {
                try
                {
                    DataSet ds2 = new DataSet();
                    ds2 = requestItemBD.TotalWrongItems(i);
                    if (!(ds2.Tables[0].Rows[0][0] is DBNull))
                    {
                        requestItem.Wrong = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);

                        DataSet ds3 = new DataSet();
                        ds3 = requestItemBD.TotalItems(i);
                        if (!(ds2.Tables[0].Rows[0][0] is DBNull))
                        {
                            requestItem.Qty = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);

                            requestItem.Correct = requestItem.Qty - requestItem.Wrong;

                            DataSet ds4 = new DataSet();
                            ds4 = requestItemBD.SupplierName(i);
                            requestItem.SupName = Convert.ToString(ds4.Tables[0].Rows[0][0]);

                            dados = dados + "['" + requestItem.SupName + "', " + requestItem.Correct + "," + requestItem.Wrong + "],";

                        }
                    }
                }catch (System.Exception ex)
                {
                    throw;
                }
            }


        }
    }
}