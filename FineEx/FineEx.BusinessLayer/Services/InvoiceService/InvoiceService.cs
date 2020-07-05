using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Services.InvoiceService
{
    public class InvoiceService
    {
        private IQueryable<Invoice> _invoices;
        private List<InvoiceViewModel> _invoicesView;
        private string businessNumber;

        public InvoiceService(string businessNumber, List<InvoiceViewModel> invoicesView)
        {
            this.businessNumber = businessNumber;
            _invoicesView = invoicesView;
        }

        public List<InvoiceViewModel> GetIncomingInvoices()
        {
            _invoices = App.Db.Invoices.Where(x => x.Receiver.BusinessNumber == businessNumber);
            GetInvoiceViewModels();
            return _invoicesView;

        }

        public List<InvoiceViewModel> GetOutgoingInvoices()
        {
            _invoices = App.Db.Invoices.Where(x => x.Sender.BusinessNumber == businessNumber);
            GetInvoiceViewModels();
            return _invoicesView;
        }

        private void GetInvoiceViewModels()
        {
            if (_invoicesView.Count != 0)
                _invoicesView.Clear();
            
            foreach (var invoice in _invoices)
            {
                _invoicesView.Add(new InvoiceViewModel(invoice));
            }
        }
    }
}
