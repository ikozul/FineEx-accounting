using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.InvoiceModels;

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
            var htmlContent = GetHtmlPdf();
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);

            Save(pdfBytes);
            return _basePdfPath;
        }

        private void Save(byte[] pdfBytes)
        {
            System.IO.File.WriteAllBytes(_basePdfPath, pdfBytes);
        }
    }
}
