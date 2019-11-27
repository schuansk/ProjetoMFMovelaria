using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class FinishedBudget
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int StepId { get; set; }
        public string StepDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}