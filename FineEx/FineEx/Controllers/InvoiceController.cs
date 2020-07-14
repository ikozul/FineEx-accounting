using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Services.CompanyService;
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
        private CompanyService _companyService;
        private List<CompanyViewModel> _companies;
        private List<InvoiceViewModel> _invoices;


        public InvoiceController()
        {
            ViewBag.InvoiceTypes = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Incoming"},
                new SelectListItem { Value = "2", Text = "Outgoing"}
            }, "Value", "Text");
            
            _companyService = new CompanyService();
            _companies = _companyService.GetCompanies();
            IEnumerable<SelectListItem> selectList = from c in _companies
                                                     select new SelectListItem
                                                     {
                                                         Value = c.BusinessNumber,
                                                         Text = c.CompanyName
                                                     };
            ViewBag.Companies = new SelectList(selectList, "Value", "Text");
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
    }
}