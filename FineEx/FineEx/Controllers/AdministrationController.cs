using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.BusinessLayer.Services.Billing;
using FineEx.DataLayer.Context;

namespace FineEx.Controllers
{
    public class AdministrationController : BaseController
    {
        [HttpGet]
        [Route("administration")]
        public ActionResult Index()
        {
            foreach (var model in App.Db.Companies.Where(x=>x.Id > 1))
            {
                BillingService service = new BillingService(model.Id);
                service.BillCompany();
            }
           
            return View();
        }

        public ActionResult StartBilling()
        {

            return null;
        }
    }
}