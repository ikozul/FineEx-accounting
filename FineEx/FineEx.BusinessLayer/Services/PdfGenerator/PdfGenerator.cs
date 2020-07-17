﻿using System;
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
        private ViewToStringRenderer _viewToStringRenderer;

        public PdfGenerator(InvoiceViewModel invoiceViewModel)
        {
            _invoiceViewModel = invoiceViewModel;
            _viewToStringRenderer = new ViewToStringRenderer();
        }

        private string GetHtmlPdf()
        {
            return _viewToStringRenderer.RenderInvoiceTypeToString(_invoiceViewModel);
        }

        public void GeneratePdfBytes()
        {
            var htmlContent = GetHtmlPdf();
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);

            Save();
        }

        private void Save()
        {
            throw new NotImplementedException();
        }
    }
}