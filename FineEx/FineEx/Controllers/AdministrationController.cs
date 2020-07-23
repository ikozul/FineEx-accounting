using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Services.Billing;
using FineEx.BusinessLayer.Services.Export;
using FineEx.DataLayer.Context;

namespace FineEx.Controllers
{
    public class AdministrationController : BaseController
    {
        [HttpGet]
        [Route("administration")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartBilling()
        {
            foreach (var model in App.Db.Companies.Where(x => x.Id > 1))
            {
                BillingService service = new BillingService(model.Id);
                service.BillCompany();
            }

            App.Db.SaveChanges();
            return RedirectToAction("Index", "Administration");
        }

        public FileContentResult ExportData()
        {
            var invoiceExport = new ExportInvoices(1);
            return File(fileContents: invoiceExport.ExportData(), "text/csv", "export.csv");
        }
    }
}