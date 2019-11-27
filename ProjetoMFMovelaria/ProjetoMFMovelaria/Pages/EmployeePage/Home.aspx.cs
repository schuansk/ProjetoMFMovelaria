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
            Label2.Visible = false;
            lblDiasAcumulados.Visible = false;
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
                    if (!Page.IsPostBack) { 
                        LoadFinishedBudgets();
                        //string orcamento_id = ddlFinishedBudgets.SelectedItem.Value;
                        //LoadLeadTimeKpi(orcamento_id);
                    }
                    
                    //possivel solucao eh chamar o metodo aqui e esquecer o botao, ai faz o post
                }
            }
            else
            {
                Response.Redirect("../ErrorPages/AccessDanied.aspx");
            }
        }

        private void LoadLeadTimeKpi(string orcId)
        {
            //vai entrar no metodo do botao
            if (orcId != "Selecione")
            {
                //LoadLeadTimeKpi(Convert.ToInt32(orcamento_id));
                BudgetBD budgetBD = new BudgetBD();
                DataSet ds = budgetBD.SelectPreviousFinishedBudget(Convert.ToInt32(orcId));

                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    gdvLeadTimeKpi.DataSource = ds.Tables[0].DefaultView;
                    gdvLeadTimeKpi.DataBind();
                    gdvLeadTimeKpi.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //lblMessage.Visible = false;
                }

                FinishedBudget start = budgetBD.SelectStartDateById(Convert.ToInt32(orcId));
                FinishedBudget end = budgetBD.SelectEndDateById(Convert.ToInt32(orcId));

                double diasAcumulados = (end.FinishedDate - start.StartDate).TotalDays;

                Label2.Visible = true;
                lblDiasAcumulados.Visible = true;
                lblDiasAcumulados.Text = "&nbsp" + Convert.ToString(diasAcumulados);
            }
            else
            {
                gdvLeadTimeKpi.Visible = false;
            }
        }

        private void LoadFinishedBudgets()
        {
            BudgetBD db = new BudgetBD();
            DataSet ds = db.SelectAllFinished();

            ddlFinishedBudgets.DataSource = ds.Tables[0].DefaultView;
            ddlFinishedBudgets.DataTextField = "orc_id";
            ddlFinishedBudgets.DataValueField = "orc_id";
            ddlFinishedBudgets.DataBind();
            ddlFinishedBudgets.Items.Insert(0, "Selecione");
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

        protected void btnFinishedBudget_Click(object sender, EventArgs e)
        {
            string orcamento_id = ddlFinishedBudgets.SelectedItem.Value;
            //vai entrar no metodo do botao
            if (orcamento_id != "Selecione")
            {
                gdvLeadTimeKpi.Visible = true;
                //LoadLeadTimeKpi(Convert.ToInt32(orcamento_id));
                BudgetBD budgetBD = new BudgetBD();
                DataSet ds = budgetBD.SelectPreviousFinishedBudget(Convert.ToInt32(orcamento_id));

                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    gdvLeadTimeKpi.DataSource = ds.Tables[0].DefaultView;
                    gdvLeadTimeKpi.DataBind();
                    gdvLeadTimeKpi.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //lblMessage.Visible = false;
                }

                FinishedBudget start = budgetBD.SelectStartDateById(Convert.ToInt32(orcamento_id));
                FinishedBudget end = budgetBD.SelectEndDateById(Convert.ToInt32(orcamento_id));

                double diasAcumulados = (end.FinishedDate - start.StartDate).TotalDays;

                Label2.Visible = true;
                lblDiasAcumulados.Visible = true;
                lblDiasAcumulados.Text = "&nbsp" + Convert.ToString(diasAcumulados);
            }
            else
            {
                gdvLeadTimeKpi.Visible = false;
            }
        }
    }
}