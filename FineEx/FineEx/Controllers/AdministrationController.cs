using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.BusinessLayer.Services.Billing;

namespace FineEx.Controllers
{
    public class AdministrationController : BaseController
    {
        public ActionResult Index()
        {
            BillingService service = new BillingService(2);
            service.BillCompany();
            return View();
        }

        public ActionResult StartBilling()
        {

            return null;
        }
    }
}