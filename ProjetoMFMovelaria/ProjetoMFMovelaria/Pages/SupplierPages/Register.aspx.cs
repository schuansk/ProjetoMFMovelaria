using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Data;

namespace ProjetoMFMovelaria.Pages.SupplierPages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNumber_Click(object sender, EventArgs e)
        {
            bool verify = true;

            if (txtAddNumber.Text != "")
            {
                for (int i = 0; i < cblNumber.Items.Count; i++)
                {
                    if (txtAddNumber.Text == cblNumber.Items[i].Text)
                    {
                        lblVerify.Text = "Esse número já foi adicionado.";
                        verify = false;
                    }
                }
            }
            else
            {
                verify = false;
            }

            if (verify)
            {
                cblNumber.Items.Add(txtAddNumber.Text);
                txtAddNumber.Text = "";
                lblMessagePhone.Text = "";
                lblVerify.Text = "";
            }
        }

        protected void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (!hasPhone())
            {
                return;
            }

            for (int i = 0; i < cblNumber.Items.Count; i++)
            {
                if (cblNumber.Items[i].Selected)
                {
                    string selectedItem = Convert.ToString(cblNumber.Items[i].Text);
                    cblNumber.Items.Remove(selectedItem);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SupplierDB supplierdb = new SupplierDB();

            if (supplierdb.SelectByCNPJ(txtCNPJ.Text) != null)
            {
                lblMessageCNPJ.Text = "Já existe uma empresa cadastrada com o CNPJ fornecido.";
                lblMessage.Text = "";
            }
            else
            {
                if (Convert.ToInt32(cblNumber.Items.Count) > 0)
                {
                    Supplier supplier = new Supplier();

                    supplier.Name = txtName.Text;
                    supplier.CNPJ = txtCNPJ.Text;
                    supplier.Email = txtEmail.Text.ToLower();
                    supplier.City = txtCity.Text;
                    supplier.UF = ddlUf.SelectedItem.Value;

                    if (supplierdb.Insert(supplier))
                    {
                        int id = Convert.ToInt32(supplierdb.SelectByCNPJ(txtCNPJ.Text).Id);

                        int count = Convert.ToInt32(cblNumber.Items.Count);

                        PhoneNumberDB phonenumberdb = new PhoneNumberDB();

                        for (int i = 0; i < count; i++)
                        {
                            phonenumberdb.Insert(id, cblNumber.Items[i].Text);
                        }

                        lblMessage.Text = "Fornecedor cadastrado com sucesso.";
                        Clear();
                    }
                    else
                    {
                        lblMessageCNPJ.Text = "Sinto muito, não foi possível realizar o cadastro";
                        lblMessage.Text = "";
                    }                    
                }
                else
                {
                    lblMessagePhone.Text = "Adicione pelo menos um número de telefone.";
                    lblMessageCNPJ.Text = "";
                }
            }
        }

        // VERIFICA SE TEM ALGUM NÚMERO DE TELEFONE ADICIONADO
        private bool hasPhone()
        {
            for (int i = 0; i < cblNumber.Items.Count; i++)
            {
                if (cblNumber.Items[i].Selected)
                {
                    return true;
                }
            }
            return false;
        }

        // LIMPA TODOS OS CAMPOS O FORM
        private void Clear()
        {
            txtName.Text = "";
            txtCNPJ.Text = "";
            txtEmail.Text = "";
            txtAddNumber.Text = "";
            lblMessageCNPJ.Text = "";
            lblVerify.Text = "";
            txtCity.Text = "";

            for (int i = 0; i < ddlUf.Items.Count; i++)
            {
                ddlUf.Items[i].Selected = false;
            }

            ddlUf.Items[0].Selected = true;

            cblNumber.Items.Clear();
        }
    }
}