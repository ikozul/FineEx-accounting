using FineEx.BusinessLayer.Services.InvoiceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineEx.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceService _invoiceService;

        public InvoiceController()
        {
            ViewBag.InvoiceTypes = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Incoming"},
                new SelectListItem { Value = "2", Text = "Outgoing"}
            }, "Value", "Text");
        }

        [HttpGet]
        [Route("invoices")]
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Partial(int invoiceType, string businessNumber)
        {

            return View();
        }
    }
}