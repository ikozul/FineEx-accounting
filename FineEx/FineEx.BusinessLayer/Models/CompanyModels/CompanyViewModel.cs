using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.CompanyModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            
        }
        public CompanyViewModel(Company company)
        {
            Id = company.Id;
            BusinessNumber = company.BusinessNumber;
            BusinessUnit = company.BusinessUnit;
            CompanyName = company.Name;
            Address = company.Address;
            City = company.City;
            Country = company.County;
            GlobalLocationNumber = company.GLN;
            IBAN = company.IBAN;
            Phone = company.Phone;
            PricePrecision = company.PricePrecision;
            QuantityPrecision = company.QuantityPrecision;
        }

        public int Id { get; set; }
        public string BusinessNumber { get; set; }
        public string BusinessUnit { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string GlobalLocationNumber { get; set; }
        public string IBAN { get; set; }
        public string Phone { get; set; }
        public int PricePrecision { get; set; }
        public int QuantityPrecision { get; set; }
    }
}
