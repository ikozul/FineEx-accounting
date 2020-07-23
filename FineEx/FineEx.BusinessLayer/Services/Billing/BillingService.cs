using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Services.Billing.Models;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Services.Billing
{
    public class BillingService
    {
        private Company _receiverCompany;
        private Company _senderCrompany;
        private int _userCount = 0;

        public BillingService(int id)
        {
            _senderCrompany = App.Db.Companies.Single(x => x.Id == 1);
            _receiverCompany = App.Db.Companies.Single(x => x.Id == id);
            _userCount = _receiverCompany.Users.Count();
        }

        public void BillCompany()
        {
            var invoice = new Invoice();
            invoice.Sender = _senderCrompany;
            invoice.User = invoice.Sender.Users.FirstOrDefault();
            invoice.Receiver = _receiverCompany;
            invoice.InvoiceDate = DateTime.Now;
            invoice.DueDate = DateTime.Now.AddDays(Config.PaymentDueDateDays);
            invoice.InvoiceItems.Add(GetBillingItems());
            invoice.Approved = false;

            invoice.InvoiceNumber = "Test invoice number";
            invoice.PaymentMethod = App.Db.PaymentMethods.FirstOrDefault();
            //invoice.PriceWithoutVat = 10m,
            //invoice.TotalPrice = 10m,
            invoice.UniqueIdentifierOfInvoice = Guid.NewGuid().ToString();
            invoice.VatNumber = "Test invoice vat number";
            invoice.VatPercentage = 10m;
            invoice.VatSwiftBankClient = _senderCrompany.IBAN;

            App.Db.Invoices.Add(invoice);
            

            var viewModel = new InvoiceViewModel(invoice);
        }

        private InvoiceItems GetBillingItems()
        {
            Item item;
            if (_userCount < (int)BillingPackages.Packages.Small)
            {
                item =  App.Db.Items.First(x => x.Id == 1);
            }
            item = _userCount < (int)BillingPackages.Packages.Medium ? App.Db.Items.First(x => x.Id == 2) : App.Db.Items.First(x => x.Id == 3);
            InvoiceItems invoiceItems = new InvoiceItems();
            invoiceItems.Item = item;
            invoiceItems.ItemQuantity = 1;
            return invoiceItems;

        }
    }
}
