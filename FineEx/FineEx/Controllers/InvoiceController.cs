using FineEx.BusinessLayer.Exceptions;
using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.BusinessLayer.Services.CompanyService;
using FineEx.BusinessLayer.Services.InvoiceService;
using FineEx.BusinessLayer.Services.ItemService;
using FineEx.BusinessLayer.Services.PaymentMethodService;
using FineEx.BusinessLayer.Services.PdfGenerator;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineEx.Controllers
{
    public class InvoiceController : Controller
    {
        private const string PAYPAL = "PayPal";
        private InvoiceService _invoiceService;
        private CompanyService _companyService;
        private PaymentMethodService _paymentMethodService;
        private ItemService _itemService;
        private List<CompanyViewModel> _companies;
        private List<InvoiceViewModel> _invoices;
        private List<ItemViewModel> _items;
        private IEnumerable<SelectListItem> _selectList;
        private PdfGenerator _pdfGenerator;


        public InvoiceController()
        {
            ViewBag.InvoiceTypes = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = FineEx.Resources.Invoice.Invoice.IncomingInvoice },
                new SelectListItem { Value = "2", Text = FineEx.Resources.Invoice.Invoice.OutgoingInvoice }
            }, "Value", "Text");

            _paymentMethodService = new PaymentMethodService();
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
            InvoiceCreateModel invoiceCreateModel = new InvoiceCreateModel();
            var currentCompany = _companyService.GetCompanies().First(c => c.BusinessNumber == businessNumber);
            invoiceCreateModel.SenderID = currentCompany.Id;
            invoiceCreateModel.Sender = currentCompany.CompanyName;
            invoiceCreateModel.Recipients = _companyService.GetCompanies().Where(c => c.BusinessNumber != businessNumber).ToList();
            invoiceCreateModel.PaymentMethods = _paymentMethodService.GetPaymentMethods();
            UserViewModel currentUser = (UserViewModel)Session["user"];
            invoiceCreateModel.Issuer = currentUser.ToString();
            return View(invoiceCreateModel);
        }

        [HttpPost]
        public ActionResult Create(InvoiceCreateModel invoiceCreateModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CreatePart2", "Invoice", invoiceCreateModel);
            }
            return View(invoiceCreateModel);
        }

        [HttpGet]
        public ActionResult CreatePart2(InvoiceCreateModel invoiceCreateModel)
        {
            _itemService = new ItemService();
            invoiceCreateModel.InvoiceItems = new ItemCreateModel();
            invoiceCreateModel.InvoiceItems.Items = _itemService.GetItemsForCompany(invoiceCreateModel.SenderID);
            return View(invoiceCreateModel);
        }

        [HttpPost]
        [ActionName("CreatePart2")]
        public ActionResult CreatePart2Post(InvoiceCreateModel invoiceCreateModel)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(invoiceCreateModel);
        }

        public ActionResult DownloadPDF(int id)
        {
            string pdfPath;
            try
            {
                _invoiceService = new InvoiceService();
                var invoiceViewModel = _invoiceService.GetInvoiceById(id);
                _pdfGenerator = new PdfGenerator(invoiceViewModel);
                pdfPath = _pdfGenerator.GeneratePdfBytes();
                var fs = new FileStream(pdfPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return File(fs, "application/pdf", ("racun-" + invoiceViewModel.InvoiceNumber + ".pdf"));
            }
            catch (NoInvoiceFoundException ex)
            {
                ViewBag.NoInvoiceFoundError = true;
                ViewBag.NoInvoiceFoundMessage = ex.Message;
                return View("Index");
            }
        }
    }
}