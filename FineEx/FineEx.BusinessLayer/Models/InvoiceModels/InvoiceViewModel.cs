using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.InvoiceModels
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel(Invoice invoice)
        {
            Id = invoice.Id;
            Approved = invoice.Incoming;
            SenderNameNumber = invoice.Sender.Name + invoice.Sender.BusinessNumber;
            ReceiverNameNumber = invoice.Receiver.Name + invoice.Receiver.BusinessNumber;
            PaymentMethod = invoice.PaymentMethod.PaymentType;
            InvoiceDate = invoice.InvoiceDate;
            DueDate = invoice.DueDate;
            UniqueIdentifierOfInvoice = invoice.UniqueIdentifierOfInvoice;
            VatNumber = invoice.VatNumber;
            VatSwiftBankClient = invoice.VatSwiftBankClient;
            InvoiceNumber = invoice.InvoiceNumber;
            Issuer = invoice.User.FullName;
        }

        public int Id { get; set; }
        public bool Approved { get; set; }
        public string SenderNameNumber { get; set; }
        public string ReceiverNameNumber { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string UniqueIdentifierOfInvoice { get; set; }
        public string VatNumber { get; set; }
        public string VatSwiftBankClient { get; set; }
        public string InvoiceNumber { get; set; }
        public string Issuer { get; set; }
    }
}
