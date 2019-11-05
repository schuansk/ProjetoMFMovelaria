using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int OrcId { get; set; }
        public string Desc { get; set; }
    }
}