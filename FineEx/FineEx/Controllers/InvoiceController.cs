using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineEx.Controllers
{
    public class InvoiceController : Controller
    {
        [HttpGet]
        [Route("invoices")]
        public ActionResult Index()
        {
            return View();
        }
    }
}