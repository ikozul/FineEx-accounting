using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.InvoiceModels;

namespace FineEx.BusinessLayer.Services.InvoiceService
{
    public interface IInvoiceService
    {
        List<InvoiceViewModel> GetIncomingInvoices();
        List<InvoiceViewModel> GetOutgoingInvoices();
        InvoiceViewModel GetInvoiceById(int id);
        void GetInvoiceViewModels();
    }
}
