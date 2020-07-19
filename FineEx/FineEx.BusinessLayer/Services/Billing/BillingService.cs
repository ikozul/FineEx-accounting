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
            _receiverCompany = App.Db.Companies.Single(x => x.Id == id);
            _userCount = _receiverCompany.Users.Count();
        }

        public void BillCompany()
        {
            var invoice = new Invoice();
            invoice.Sender = App.Db.Companies.Single(x => x.Id == 1);
            invoice.User = invoice.Sender.Users.FirstOrDefault();
            invoice.Receiver = _receiverCompany;
            invoice.InvoiceDate = DateTime.Now;
            invoice.DueDate = DateTime.Now.AddDays(Config.PaymentDueDateDays);
            invoice.Items.Add(GetBillingItems());
            invoice.Approved = false;

            invoice.InvoiceNumber = "Test invoice number";
            invoice.PaymentMethod = App.Db.PaymentMethods.FirstOrDefault();
            //invoice.PriceWithoutVat = 10m,
            //invoice.TotalPrice = 10m,
            invoice.UniqueIdentifierOfInvoice = Guid.NewGuid().ToString();
            invoice.VatNumber = "Test invoice vat number";
            invoice.VatPercentage = 10m;
            invoice.VatSwiftBankClient = "Test invoice vat swift bank client";

            App.Db.Invoices.Add(invoice);
            App.Db.SaveChanges();





            var viewModel = new InvoiceViewModel(invoice);
        }

        private Item GetBillingItems()
        {
            if (_userCount < (int)BillingPackages.Packages.Small)
            {
                return App.Db.Items.First(x => x.Id == 1);
            }
            return _userCount < (int)BillingPackages.Packages.Medium ? App.Db.Items.First(x => x.Id == 2) : App.Db.Items.First(x => x.Id == 3);
        }
    }
}
