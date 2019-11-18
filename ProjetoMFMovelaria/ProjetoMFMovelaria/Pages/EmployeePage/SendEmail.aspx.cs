using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Persistence;
using ProjetoMFMovelaria.App_Code.Class;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace ProjetoMFMovelaria.Pages.EmployeePage
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarrySupplier();
                txtsubject.Text = "Pedido MF Movelaria";
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string supplier = ".";

            if (hasSupplier())
            {
                supplier = ", " + ddlSupplier.SelectedItem.Text + ".";
            }

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("movelariamf@gmail.com", "MF Movelaria");
            mail.To.Add(txtEmail.Text);

            mail.Subject = txtsubject.Text;
            mail.IsBodyHtml = true;
            mail.Body = "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Ol&aacute;" + supplier + "</span></span></span></p>" +
                "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Segue em anexo lista de pedidos.</span></span></span></p>" +
                "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Qualquer d&uacute;vida estamos a disposi&ccedil;&atilde;o.</span></span></span></p>" +
                "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Atenciosamente,</span></span></span></p>" +
                "<p><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>MF Movelaria.</span></span></span></p>" +
                "<p style='text-align:center'><span style='font - size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Contato:</span></span></span></p>" +
                "<div style='text-align: center;'><font color='#000000' face='arial, helvetica, sans-serif'><span style='font-size:12px'>(12) 3152-2515</span></font></div>" +
                "<p style='text-align:center'><span style='font-size:12px'><span style='color:#000000'><span style='font-family:arial,helvetica,sans-serif'>Av. Gen. Eduardo Areco, 606 - Vila Geny, Lorena - SP, CEP: 12604-100</span></span></span></p>";

            MemoryStream ms = new MemoryStream(fuAnexo.FileBytes);
            Attachment attach = new Attachment(ms, fuAnexo.FileName);

            mail.Attachments.Add(attach);

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

        // CARREGA TODOS OS FORNECEDORES NO DDLSUPPLIER
        private void CarrySupplier()
        {
            SupplierDB db = new SupplierDB();
            DataSet ds = db.SelectAll();

            ddlSupplier.DataSource = ds.Tables[0].DefaultView;
            ddlSupplier.DataTextField = "for_nome";
            ddlSupplier.DataValueField = "for_id";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, "Selecione");
        }

        // VERIFICA SE TEM UM FORNCEDOR SELECIONDO
        private bool hasSupplier()
        {
            return (ddlSupplier.SelectedItem.Text != "Selecione");
        }

        // INSERE O EMAIL DO FORNCEDOR NO TXTEMAIL
        private void AddEmail(int id)
        {
            if (!hasSupplier())
            {
                return;
            }

            SupplierDB db = new SupplierDB();
            Supplier supplier = db.SelectById(id);

            txtEmail.Text = supplier.Email.ToString();
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlSupplier.SelectedItem.Value);
            AddEmail(id);
        }

        // LIMPA OS CAMPOS
        private void Clear()
        {
            txtEmail.Text = "";

            for (int i = 0; i < ddlSupplier.Items.Count; i++)
            {
                ddlSupplier.Items[i].Selected = false;
            }

            ddlSupplier.Items[0].Selected = true;
        }
    }
}