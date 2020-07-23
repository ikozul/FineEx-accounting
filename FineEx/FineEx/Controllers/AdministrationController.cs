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
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter writer = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    foreach (var invoice in App.Db.Invoices.Where(x => x.SenderId == 1))
                    {
                        var invoiceViewModel = new InvoiceViewModel(invoice);
                        csv.WriteRecord(invoiceViewModel);
                        csv.NextRecord();
                    }

                    writer.Flush();
                    csv.Flush();

                    return File(fileContents: memoryStream.GetBuffer(), "text/csv", "export.csv");
                }
            }
        }
    }
}