using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.CompanyModels
{
    public class CompanyCreateModel
    {
        [Required(ErrorMessage = "Business Number is required.", AllowEmptyStrings = false)]
        public string BusinessNumber { get; set; }

        public string BusinessUnit { get; set; }

        [Required(ErrorMessage = "Compny Name is required.", AllowEmptyStrings = false)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Address is required.", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.", AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.", AllowEmptyStrings = false)]
        public string Country { get; set; }

        public string GlobalLocationNumber { get; set; }

        [Required(ErrorMessage = "IBAN is required.", AllowEmptyStrings = false)]
        public string IBAN { get; set; }

        [Required(ErrorMessage = "Phone is required.", AllowEmptyStrings = false)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Price Precision is required.", AllowEmptyStrings = false)]
        public int PricePrecision { get; set; }

        [Required(ErrorMessage = "Quantity Precision is required.", AllowEmptyStrings = false)]
        public int QuantityPrecision { get; set; }
    }
}
