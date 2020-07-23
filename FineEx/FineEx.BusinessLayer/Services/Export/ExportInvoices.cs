using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using CsvHelper;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.DataLayer.Context;

namespace FineEx.BusinessLayer.Services.Export
{
    public class ExportInvoices
    {
        private readonly int _companyId;

        public ExportInvoices(int companyId)
        {
            _companyId = companyId;
        }

        public byte[] ExportData()
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter writer = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = ";";
                    foreach (var invoice in App.Db.Invoices.Where(x => x.SenderId == _companyId))
                    {
                        var invoiceViewModel = new InvoiceViewModel(invoice);
                        csv.WriteRecord(invoiceViewModel);
                        csv.NextRecord();
                    }

                    writer.Flush();
                    csv.Flush();

                    return memoryStream.GetBuffer();
                }
            }
        }
    }
}
