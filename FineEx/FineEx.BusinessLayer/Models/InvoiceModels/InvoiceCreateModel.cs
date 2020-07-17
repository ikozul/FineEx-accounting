using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.InvoiceModels
{
    public class InvoiceCreateModel
    {
        public CompanyViewModel Sender { get; set; }
        public CompanyViewModel Receiver { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string UniqueIdentifierOfInvoice { get; set; }
        public string VatNumber { get; set; }
        public string VatSwiftBankClient { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal PriceWithoutVat { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatPercentage { get; set; }
        public string Issuer { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}
