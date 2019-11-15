using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public string SupplierName { get; set; }
        public int IdSupplier { get; set; }
        public int IdBudget { get; set; }
    }
}