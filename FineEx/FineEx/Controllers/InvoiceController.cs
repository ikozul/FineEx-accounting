using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Services.CompanyService;
using FineEx.BusinessLayer.Services.InvoiceService;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.DataLayer.Context;

namespace FineEx.Controllers
{
    public class InvoiceController : Controller
    {
        private const string PAYPAL = "PayPal";
        private InvoiceService _invoiceService;
        private CompanyService _companyService;
        private List<CompanyViewModel> _companies;
        private List<InvoiceViewModel> _invoices;
        private IEnumerable<SelectListItem> _selectList;


        public InvoiceController()
        {
            ViewBag.InvoiceTypes = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = FineEx.Resources.Invoice.Invoice.IncomingInvoice },
                new SelectListItem { Value = "2", Text = FineEx.Resources.Invoice.Invoice.OutgoingInvoice }
            }, "Value", "Text");

            _companyService = new CompanyService();
            _companies = _companyService.GetCompanies(App.UserId);
            _selectList = from c in _companies
                          select new SelectListItem
                          {
                              Value = c.BusinessNumber,
                              Text = c.CompanyName
                          };
            ViewBag.Companies = new SelectList(_selectList, "Value", "Text");
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
            _invoiceService = new InvoiceService(businessNumber);
            if (invoiceType == 1)
            {
                _invoices = _invoiceService.GetIncomingInvoices();
            }
            else
            {
                _invoices = _invoiceService.GetOutgoingInvoices();
            }
            return PartialView("_InvoicePartial", _invoices);
        }

        [HttpGet]
        public ActionResult Create(string businessNumber)
        {
            ViewBag.Recipients = new SelectList(_selectList.Where(c => c.Value != businessNumber), "Value", "Text");
            ViewBag.PaymentMethods = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = FineEx.Resources.Invoice.Invoice.CreditCard },
                new SelectListItem { Value = "2", Text = FineEx.Resources.Invoice.Invoice.CashOnDelivery },
                new SelectListItem { Value = "3", Text = PAYPAL }
            }, "Value", "Text");
            InvoiceCreateModel invoiceCreateModel = new InvoiceCreateModel();
            invoiceCreateModel.Sender = _companyService.GetCompanies().First(c => c.BusinessNumber == businessNumber).CompanyName;
            return View(invoiceCreateModel);
        }

        [HttpPost]
        public ActionResult Create(InvoiceCreateModel invoiceCreateModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View(invoiceCreateModel);
        }

    }
}