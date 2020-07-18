using System.IO;
using FineEx.BusinessLayer.Models.InvoiceModels;
using Scriban;
using Scriban.Runtime;

namespace FineEx.BusinessLayer.Services.PdfGenerator
{
    public class HtmlRenderer
    {
        private readonly string TemplatePath = @"/Services/PdfGenerator/Views/InvoicePdf.tpl";

        private readonly Template _template;

        public HtmlRenderer()
        {
            var path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            var templateText = File.ReadAllText(path + TemplatePath);
            _template = Template.Parse(templateText , TemplatePath);
        }

        public string RenderHtml(InvoiceViewModel model)
        {
            var scriptObject = new ScriptObject();
            scriptObject.Import(model);

            var context = new TemplateContext();
            context.PushGlobal(scriptObject);

            context.StrictVariables = true;

            return _template.Render(context);
        }
    }
}
