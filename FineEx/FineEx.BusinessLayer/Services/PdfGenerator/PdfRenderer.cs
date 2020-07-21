using FineEx.BusinessLayer.Models.InvoiceModels;
using NReco.PdfGenerator;

namespace FineEx.BusinessLayer.Services.PdfGenerator
{
    public class PdfRenderer
    {
        private readonly HtmlRenderer _htmlRenderer;

        public PdfRenderer()
        {
            _htmlRenderer = new HtmlRenderer();
        }

        public byte[] RenderPdf(InvoiceViewModel model)
        {
            string html = _htmlRenderer.RenderHtml(model);

            var converter = new HtmlToPdfConverter
            {
                Size = PageSize.A4,
                Zoom = 1.0f,
                CustomWkHtmlPageArgs = "--viewport-size 1024x768",
                CustomWkHtmlArgs = "--viewport-size 1024x768"
            };

            return converter.GeneratePdf(html);
        }

    }
}
