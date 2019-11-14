using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;

namespace ProjetoMFMovelaria.Pages.StepPages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            urlStepHistory.Visible = false;
            lblEtaId.Visible = false;

            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);

            loadBudgetFields(orcId);
            loadPreviousStep(orcId);
        }

        protected void loadBudgetFields(int orcId)
        {
            BudgetBD budgetBD = new BudgetBD();
            Budget budget = budgetBD.SelectById(orcId);

            if (budget != null)
            {
                lblMessage.Visible = false;
                lblOrcamento.Text = budget.Id.ToString();
                lblDataInicio.Text = budget.StartDate.ToString();
                lblTotal.Text = budget.TotalBudget.ToString();
                lblCliente.Text = budget.Email.ToString();
                lblResponsavel.Text = budget.NameEmployee.ToString();
            }
            else
            {
                lblMessage.Visible = true;
            }
        }

        protected void loadPreviousStep(int id)
        {
            StepBD stepBD = new StepBD();
            Step step = stepBD.SelectPreviousStep(id);

            if (step != null)
            {
                lblEtaId.Text = step.Id.ToString();
                urlStepHistory.Visible = true;
                //urlStepHistory.style = System.Drawing.  "visibility: visible";
            }
        }

        protected void btnCadastrarEtapa_Click(object sender, EventArgs e)
        {
            StepBD stepBD = new StepBD();
            Step step = new Step();

            DateTime today = DateTime.Today;

            step.Name = listEtapa.SelectedItem.Value;
            step.StartDate = today;
            //step.FinishDate = Convert.ToDateTime(null);
            step.OrcId = Convert.ToInt32(lblOrcamento.Text);
            step.Desc = txtDescricao.Value;

            if (stepBD.Insert(step))
            {
                lblMessage.Text = "Etapa cadastrada com sucesso.";
                Clear();
            }
            else
            {
                lblMessage.Text = "Opa";
            }
            
        }

        private void Clear()
        {
            txtDescricao.Value = "";

            for (int i = 0; i < listEtapa.Items.Count; i++)
            {
                listEtapa.Items[i].Selected = false;
            }

            listEtapa.Items[0].Selected = true;
        }
    }
}