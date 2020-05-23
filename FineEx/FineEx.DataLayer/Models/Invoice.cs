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
        public Invoice() => Items = new HashSet<Item>();
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool Incoming { get; set; }

        [ForeignKey("SenderId")]
        public virtual Company Sender
        {
            get; set;
        }

        [ForeignKey("ReceiverId")]
        public virtual Company Receiver
        {
            get; set;
        }
        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string ProtectedCodeOfSupplier { get; set; }
        public string UniqueIdentifierOfInvoice { get; set; }
        public string VatNumber { get; set; }
        public string VatSwiftBankClient { get; set; }

        [ForeignKey("LocationId")]  
        public virtual Location Location { get; set; }

        public string InvoiceNumber { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
