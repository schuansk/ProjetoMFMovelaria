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
        int etapa_desc_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            urlStepHistory.Visible = false;
            lblEtaId.Visible = false;
            lblEtapaAtual.Visible = false;
            Label6.Visible = false;
            Label9.Visible = false;
            lblNextStep.Visible = false;
            Label10.Visible = false;
            lblDataConclusao.Visible = false;

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
                lblDataInicio.Text = budget.StartDate.ToString("dd/MM/yyyy");
                lblTotal.Text = ("R$" + budget.TotalBudget).ToString();
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
                lblEtapaAtual.Text = step.EtdDescricao.ToString();
                if(step.EtdId <= 7  || step.EtdId > 1)
                {
                    Label9.Visible = true;
                    lblNextStep.Visible = true;
                    Label7.Visible = false;
                    listEtapa.Visible = false;

                    bool statusOrcamento = checkBudgetStatus(step.OrcId);

                    if(step.EtdId == 7 || statusOrcamento == false)
                    {
                        if(statusOrcamento == true)
                        { 
                            lblDataConclusao.Text = step.FinishDate.ToString("dd/MM/yyyy");
                            Label10.Visible = true;
                            lblDataConclusao.Visible = true;
                        }
                        btnCadastrarEtapa.Visible = false;
                        Label9.Visible = false;
                        lblNextStep.Visible = false;
                        Label8.Visible = false;
                        txtDescricao.Visible = false;
                        checkboxSendEmail.Visible = false;
                    }

                }

                etapa_desc_id = step.EtdId + 1;

                switch (etapa_desc_id)
                {
                    case 1:
                        lblNextStep.Text = "Aguardando material";
                        break;
                    case 2:
                        lblNextStep.Text = "Separação";
                        break;
                    case 3:
                        lblNextStep.Text = "Corte";
                        break;
                    case 4:
                        lblNextStep.Text = "Usinagem";
                        break;
                    case 5:
                        lblNextStep.Text = "Montagem";
                        break;
                    case 6:
                        lblNextStep.Text = "Aguardando entrega";
                        break;
                    case 7:
                        lblNextStep.Text = "Entregue";
                        break;
                }

                urlStepHistory.Visible = true;
                Label6.Visible = true;
                lblEtapaAtual.Visible = true;
                //if (step.OrcId == budget.)
                //btnCadastrarEtapa.Visible = false;

                //urlStepHistory.style = System.Drawing.  "visibility: visible";
            }
        }

        private bool checkBudgetStatus(int orcId)
        {
            BudgetBD budgetBD = new BudgetBD();

            Budget budget = budgetBD.SelectById(orcId);

            if (budget != null)
            {                
                return budget.Active;
            }

            return true;

        }

        protected void btnCadastrarEtapa_Click(object sender, EventArgs e)
        {
            StepBD stepBD = new StepBD();
            Step step = new Step();

            DateTime today = DateTime.Today;

            switch (listEtapa.SelectedItem.Value)
            {
                case "Aguardando material":
                    step.EtdId = 1;
                    break;
                case "Separação":
                    step.EtdId = 2;
                    break;
                case "Corte":
                    step.EtdId = 3;
                    break;
                case "Usinagem":
                    step.EtdId = 4;
                    break;
                case "Montagem":
                    step.EtdId = 5;
                    break;
                case "Aguardando entrega":
                    step.EtdId = 6;
                    break;
                case "Entregue":
                    step.EtdId = 7;
                    break;
            }

            if (etapa_desc_id == 0)
            {
                etapa_desc_id = 1;
            }

            stepBD.UpdatePreviousStep(Convert.ToInt32(lblEtaId.Text)); //retorna um bool = true

            step.EtdId = etapa_desc_id;
            step.StartDate = today;

            if (step.EtdId == 7)
                step.FinishDate = Convert.ToDateTime(today);
            else
                step.FinishDate = Convert.ToDateTime(null);

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

        protected void urlStepHistory_Click(object sender, EventArgs e)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);
            Response.Redirect("History.aspx?orc_id=" + orcId);
        }
    }
}