using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.InvoiceModels
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel(Invoice invoice)
        {
            Id = invoice.Id;
            Approved = invoice.Approved;
            Sender = invoice.Sender;
            Receiver = invoice.Receiver;
            PaymentMethod = invoice.PaymentMethod.PaymentType;
            InvoiceDate = invoice.InvoiceDate;
            DueDate = invoice.DueDate;
            UniqueIdentifierOfInvoice = invoice.UniqueIdentifierOfInvoice;
            VatNumber = invoice.VatNumber;
            VatSwiftBankClient = invoice.VatSwiftBankClient;
            InvoiceNumber = invoice.InvoiceNumber;
            PriceWithoutVat = invoice.PriceWithoutVat;
            TotalPrice = invoice.TotalPrice;
            VatPercentage = invoice.VatPercentage;
            Issuer = invoice.User.FullName;
            Items = invoice.Items.Select(i => new ItemViewModel(i.Id, i.ItemName, i.ItemPrice, i.ItemQuantity)).ToList();
        }

        public int Id { get; set; }
        public bool Approved { get; set; }
        public Company Sender { get; set; }
        public Company Receiver { get; set; }
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
