using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int Active { get; set; }
    }
}