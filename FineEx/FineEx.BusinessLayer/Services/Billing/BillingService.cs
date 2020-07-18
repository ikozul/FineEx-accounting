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
        private Company _company;
        private BillingPackages _billingPackages = new BillingPackages();
        private int _userCount = 0;

        public BillingService(int id)
        {
            _company = App.Db.Companies.Single(x => x.Id == id);
            _userCount = _company.Users.Count();
        }

        public bool BillCompany()
        {
            return true;//Todo
        }
    }
}
