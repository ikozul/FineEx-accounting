using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Services.Billing.Models;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Services.Billing
{
    public class BillingService
    {
        private Company _receiverCompany;
        private Company _senderCrompany;
        private BillingPackages _billingPackages = new BillingPackages();
        private int _userCount = 0;

        public BillingService(int id)
        {
            _receiverCompany = App.Db.Companies.Single(x => x.Id == id);
            _userCount = _receiverCompany.Users.Count();
        }

        public bool BillCompany()
        {
            var invoice = new Invoice();
            invoice.Sender = App.Db.Companies.Single(x => x.Id == 1);
            invoice.Receiver = _receiverCompany;
            invoice.InvoiceDate = DateTime.Now;
            invoice.DueDate = DateTime.Now.AddDays(Config.PaymentDueDateDays);
            //var billingItem = App.Db.Items.First(x => x.Companies.FirstOrDefault(z => z.Id == _senderCrompany.Id));
            return true;
        }
    }
}
