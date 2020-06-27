using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FineEx.Dummy
{
    public class Company : DataLayer.Models.Company
    {
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString() => Name;
    }
}