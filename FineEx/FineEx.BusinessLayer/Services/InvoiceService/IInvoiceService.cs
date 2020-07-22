using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Services.InvoiceService
{
    public interface IInvoiceService
    {
        List<InvoiceViewModel> GetIncomingInvoices();
        List<InvoiceViewModel> GetOutgoingInvoices();
        InvoiceViewModel GetInvoiceById(int id);
        void GetInvoiceViewModels();
        int CreateNewInvoice(InvoiceCreateModel invoiceCreateModel);
        User GetCurrentUser(int id);
    }
}
