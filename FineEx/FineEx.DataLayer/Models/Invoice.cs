using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Context;

namespace FineEx.DataLayer.Models
{
    public class Invoice
    {
        public Invoice() => InvoiceItems = new HashSet<InvoiceItems>();
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Approved { get; set; }
        public string PdfPath { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public virtual Company Sender { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        public virtual Company Receiver { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        public string UniqueIdentifierOfInvoice { get; set; }
        public string VatNumber { get; set; }
        public string VatSwiftBankClient { get; set; }
        public decimal PriceWithoutVat { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatPercentage { get; set; }
        public string InvoiceNumber { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<InvoiceItems> InvoiceItems { get; set; }

    }
}
