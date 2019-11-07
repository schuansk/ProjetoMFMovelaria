using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class RequestItem
    {
        public int PeiId { get; set; }
        public string Desc { get; set; }
        public string TypeOfItem { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public bool isActive { get; set; }
        public bool isCorrect { get; set; }
        public int PedId { get; set; }
    }
}