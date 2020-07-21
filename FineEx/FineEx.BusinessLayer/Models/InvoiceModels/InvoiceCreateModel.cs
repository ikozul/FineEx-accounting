using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.BusinessLayer.Models.PaymentMethodModels;
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

        [Required(ErrorMessage = "*")]
        public int SenderID { get; set; }

        public string Sender { get; set; }

        [Required(ErrorMessage = "*")]
        public int ReceiverID { get; set; }

        [Required(ErrorMessage = "*")]
        public int PaymentMethodID { get; set; }
        
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "*")]
        public string UniqueIdentifierOfInvoice { get; set; }

        [Required(ErrorMessage = "*")]
        public string VatNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public string VatSwiftBankClient { get; set; }

        [Required(ErrorMessage = "*")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal PriceWithoutVat { get; set; }

        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal VatPercentage { get; set; }

        [Required(ErrorMessage = "*")]
        public string Issuer { get; set; }

        public ItemCreateModel InvoiceItems { get; set; }

        //public List<int> SelectedItemIds { get; set; }
        //public List<ItemViewModel> Items { get; set; }

        //public int SelectedItemID { get; set; }

        public List<CompanyViewModel> Recipients { get; set; }
        public List<PaymentMethodViewModel> PaymentMethods { get; set; }
    }
}
