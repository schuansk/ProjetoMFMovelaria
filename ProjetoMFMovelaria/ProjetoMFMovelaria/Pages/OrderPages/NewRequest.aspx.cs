using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;
using System.Text;

namespace ProjetoMFMovelaria.Pages.OrderPages
{
    public partial class NewRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);
            int forId = Convert.ToInt32(Request.QueryString["for_id"]);

            if (!Page.IsPostBack)
            {
                CarryItems(orcId);
                SetInitialRow();
                SupplierName(forId);
                lblGdvItems.Text = "Não há itens para listar.";
            }
        }

        //CARREGA TODOS OS ITENS DO ORCAMENTO NO DDLITEMS
        private void CarryItems(int id)
        {
            BudgetItemBD db = new BudgetItemBD();
            DataSet ds = db.SelectAllById(id);

            ddlItem.DataSource = ds.Tables[0].DefaultView;
            ddlItem.DataTextField = "ori_descricao";
            ddlItem.DataValueField = "ori_id";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, "Selecione");
        }

        //VERIFICA SE TEM ALGUM ITEM SELECIONADO
        private bool hasItem()
        {
            return (ddlItem.SelectedItem.Text != "Selecione");
        }

        //CARREGA DADOS DO ITEM SELECIONADO
        private void CarryItemData(int id)
        {
            if (!hasItem())
            {
                return;
            }

            BudgetItemBD db = new BudgetItemBD();
            BudgetItem budgetitem = db.Select(id);

            txtTotal.Text = budgetitem.Amount.ToString();

            txtUnitValue.Text = budgetitem.Price.ToString();
            lblType.Text = budgetitem.Type.ToString(); // Oculto para usuário
            txtNeedBuy.Text = budgetitem.Amount.ToString();
        }

        //ENVIAR O ID DO ITEM PARA O CARRYAMOUNT
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!hasItem())
            {
                txtTotal.Text = "";
                return;
            }

            int id = Convert.ToInt32(ddlItem.SelectedItem.Value);
            CarryItemData(id);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!hasItem())
            {
                lblSelectItem.Text = "Selecione um item.";
                return;
            }
            double calc = Convert.ToDouble(txtUnitValue.Text) * Convert.ToInt32(txtNeedBuy.Text);

            AddNewRowToGrid(Math.Round(calc, 2));
            lblGdvItems.Text = "";
            btnSave.Enabled = true;
            Clear();
        }

        // CRIAR UM DATATABLES AO ENTRAR NA PAGINA
        private void SetInitialRow()
        {
            DataTable datatable = new DataTable();

            datatable.Columns.Add("Descrição", typeof(string));
            datatable.Columns.Add("Tipo", typeof(string));
            datatable.Columns.Add("Quantidade", typeof(string));
            datatable.Columns.Add("Preço un. (R$)", typeof(string));
            datatable.Columns.Add("Preço total (R$)", typeof(string));

            ViewState["CurrentTable"] = datatable;

            gdvItems.DataSource = datatable;
            gdvItems.DataBind();
        }

        // ADICIONAR UMA NOVA LINHA COM DADOS NO GDVITEMS
        private void AddNewRowToGrid(double calc)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["Descrição"] = ddlItem.SelectedItem.Text;
                drCurrentRow["Tipo"] = lblType.Text;
                drCurrentRow["Quantidade"] = txtNeedBuy.Text;
                drCurrentRow["Preço un. (R$)"] = txtUnitValue.Text;
                drCurrentRow["Preço total (R$)"] = Convert.ToString(calc);

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;
                gdvItems.DataSource = dtCurrentTable;
                gdvItems.DataBind();
                gdvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData();
        }

        // ATUALIZAR O DATATABLES SEMPRE QUE ADD UMA NOVA LINHA
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dt.Rows[i]["Descrição"].ToString();
                        dt.Rows[i]["Tipo"].ToString();
                        dt.Rows[i]["Quantidade"].ToString();
                        dt.Rows[i]["Preço un. (R$)"].ToString();
                        dt.Rows[i]["Preço total (R$)"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int orcId = Convert.ToInt32(Request.QueryString["orc_id"]);
            int forId = Convert.ToInt32(Request.QueryString["for_id"]);
            bool success = false;

            OrderDB orderbd = new OrderDB();
            Order order = new Order();

            RequestItemBD requestbd = new RequestItemBD();
            RequestItem item = new RequestItem();

            order.RegisterDate = DateTime.Now;
            order.IdSupplier = forId;
            order.IdBudget = orcId;

            if (orderbd.Insert(order))
            {
                int lastOrderId = orderbd.SelectLastOrder();

                for (int i = 0; i < gdvItems.Rows.Count; i++)
                {
                    item.Desc = gdvItems.Rows[i].Cells[0].Text;
                    item.TypeOfItem = gdvItems.Rows[i].Cells[1].Text;
                    item.Qty = Convert.ToInt32(gdvItems.Rows[i].Cells[2].Text);
                    item.Price = Convert.ToDouble(gdvItems.Rows[i].Cells[3].Text);
                    item.PedId = lastOrderId;

                    if (requestbd.Insert(item))
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            else
            {
                success = false;
            }

            if (success)
            {
                Response.Redirect("ListOrders.aspx?orc_id=" + orcId + "&success=true");
            }
            else
            {
                lblMessage.Text = "Erro ao salvar o pedido.";
            }
        }

        private void Clear()
        {
            txtNeedBuy.Text = "";
            txtTotal.Text = "";
            txtUnitValue.Text = "";
            lblSelectItem.Text = "";

            for (int i = 0; i < ddlItem.Items.Count; i++)
            {
                ddlItem.Items[i].Selected = false;
            }

            ddlItem.Items[0].Selected = true;
        }

        private void SupplierName(int forId)
        {
            SupplierDB db = new SupplierDB();
            Supplier supplier = new Supplier();

            supplier = db.SelectById(forId);

            lblSupplier.Text = Convert.ToString(supplier.Name);
        }

        protected void gdvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCellCollection cells = e.Row.Cells;

                foreach (TableCell cell in cells)
                {
                    cell.Text = Server.HtmlDecode(cell.Text);
                }
            }
        }
    }
}