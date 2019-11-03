using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMFMovelaria.App_Code.Class
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int Active { get; set; }
    }
}