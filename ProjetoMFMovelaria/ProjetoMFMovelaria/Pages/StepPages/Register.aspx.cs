using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Net.Mail;
using System.Net;

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
                if (step.EtdId <= 7 || step.EtdId > 1)
                {
                    Label9.Visible = true;
                    lblNextStep.Visible = true;
                    Label7.Visible = false;
                    listEtapa.Visible = false;

                    bool statusOrcamento = checkBudgetStatus(step.OrcId);

                    if (step.EtdId == 7 || statusOrcamento == false)
                    {
                        if (statusOrcamento == true)
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

            if (etapa_desc_id > 1)
            {
                stepBD.UpdatePreviousStep(Convert.ToInt32(lblEtaId.Text)); //retorna um bool = true
            }

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

                if (checkboxSendEmail.Checked)
                {
                    sendEmail(step.EtdId);
                }
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
        protected void sendEmail(int etdId)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);

            BudgetBD bd = new BudgetBD();
            Budget budget = bd.SelectById(orcId);

            string etapa = null;
            if (etdId == 1)
            {
                etapa = listEtapa.SelectedItem.Text;
            }
            else
            {
                etapa = lblNextStep.Text;
            }
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("movelariamf@gmail.com", "MF Movelaria");
            mail.To.Add(budget.Email);

            mail.Subject = "Atualizaçao do projeto";
            mail.IsBodyHtml = true;
            mail.Body = "<h2>Ol&aacute;, querido cliente!</h2>" +
                "<p>belezinha?</p>" +
                "<p>Seu lindo projeto, feito com amor está na etapa de produção: " + etapa + "</p>" +
                "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Atenciosamente,</span></span></span></p>" +
                "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>MF Movelaria.</span></span></span></p>" +
                "<p style='text-align:center'><span style='font - size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Contato:</span></span></span></p>" +
                "<div style='text-align: center;'><font color='#000000' face='arial, helvetica, sans-serif'><span style='font-size:12px'>(12) 3152-2515</span></font></div>" +
                "<p style='text-align:center'><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Av. Gen. Eduardo Areco, 606 - Vila Geny, Lorena - SP, CEP: 12604-100</span></span></span></p>";


            SmtpClient sc = new SmtpClient("smtp.gmail.com");
            sc.Port = 587;

            sc.EnableSsl = true;
            sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential("movelariamf", "mf_moveis*2019");

            try
            {
                sc.Send(mail);
                lblMessage.CssClass = "text-success";
                lblMessage.Text = "Pedido enviado com sucesso.";
                Clear();
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Erro ao enviar o e-mail.";
            }
        }
    }
}