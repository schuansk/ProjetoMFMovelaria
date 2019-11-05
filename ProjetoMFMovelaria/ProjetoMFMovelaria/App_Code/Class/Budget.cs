using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class Budget
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Email { get; set; }
        public double TotalBudget { get; set; }
        public bool Active { get; set; }
    }
}