using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FineEx.BusinessLayer.Models.InvoiceModels
{
    public class InvoiceCreateModel
    {
        public int SenderID { get; set; }

        public string Sender { get; set; }

        public int ReceiverID { get; set; }
        
        [Required]
        public int PaymentMethodID { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string UniqueIdentifierOfInvoice { get; set; }

        [Required]
        public string VatNumber { get; set; }

        [Required]
        public string VatSwiftBankClient { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        [Required]
        public decimal PriceWithoutVat { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal VatPercentage { get; set; }

        [Required]
        public string Issuer { get; set; }

        public List<ItemViewModel> Items { get; set; }        
    }
}
