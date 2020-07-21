using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.DataLayer.Context;

namespace FineEx.BusinessLayer.Services.PdfGenerator
{
    public class PdfGenerator
    {
        private readonly InvoiceViewModel _invoiceViewModel;
        private HtmlRenderer _htmlRenderer;
        private string _basePdfPath;

        public PdfGenerator(InvoiceViewModel invoiceViewModel)
        {
            _invoiceViewModel = invoiceViewModel;
            _htmlRenderer = new HtmlRenderer();
            _basePdfPath = Config.PdfPath + invoiceViewModel.Id + ".pdf";
        }

        private string GetHtmlPdf()
        {
            return _htmlRenderer.RenderHtml(_invoiceViewModel);
        }

        public string GeneratePdfBytes()
        {
            if (!File.Exists(_basePdfPath))
            {
                var htmlContent = GetHtmlPdf();
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);

                Save(pdfBytes);
            }

            if (string.IsNullOrEmpty(_invoiceViewModel.PdfPath))
            {
                var invoice = App.Db.Invoices.Single(x => x.Id == _invoiceViewModel.Id);
                invoice.PdfPath = _basePdfPath;
                App.Db.SaveChanges();
            }
                
            return _basePdfPath;
        }

        private void Save(byte[] pdfBytes)
        {
            if (!File.Exists(_basePdfPath))
            {
                File.WriteAllBytes(_basePdfPath, pdfBytes);
            }
            


        }
    }
}
