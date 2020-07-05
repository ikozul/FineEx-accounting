using System.Collections.Generic;
using System.Linq;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private IQueryable<Invoice> _invoices;
        private readonly List<InvoiceViewModel> _invoicesView = new List<InvoiceViewModel>();
        private readonly string _businessNumber;

        public InvoiceService(string businessNumber)
        {
            this._businessNumber = businessNumber;
        }

        public List<InvoiceViewModel> GetIncomingInvoices()
        {
            _invoices = App.Db.Invoices.Where(x => x.Receiver.BusinessNumber == _businessNumber);
            GetInvoiceViewModels();
            return _invoicesView;

        }

        public List<InvoiceViewModel> GetOutgoingInvoices()
        {
            _invoices = App.Db.Invoices.Where(x => x.Sender.BusinessNumber == _businessNumber);
            GetInvoiceViewModels();
            return _invoicesView;
        }

        public void GetInvoiceViewModels()
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
