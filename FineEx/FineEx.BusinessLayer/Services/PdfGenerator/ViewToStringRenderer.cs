using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FineEx.BusinessLayer.Models.InvoiceModels;
using RazorLight;

namespace FineEx.BusinessLayer.Services.PdfGenerator
{
    public class ViewToStringRenderer : Controller
    {
        private readonly IRazorLightEngine _engine;
        public ViewToStringRenderer()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var viewsPath = Path.Combine(outputDirectory, @"PdfGenerator\Views");
            var viewsLocation = new Uri(viewsPath).LocalPath;
            _engine = EngineFactory.CreatePhysical(viewsLocation);
        }

        public string RenderInvoiceTypeToString(InvoiceViewModel invoiceType)
        {
            return _engine.Parse("InvoicePdf.cshtml", invoiceType);
        }
    }
}
