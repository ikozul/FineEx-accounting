using System.Collections.Generic;
using System.Linq;
using FineEx.BusinessLayer.Exceptions;
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
        public InvoiceService()
        {

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

        public InvoiceViewModel GetInvoiceById(int id)
        {
            var invoice = App.Db.Invoices.Single(i => i.Id == id);
            if (invoice == null)
            {
                throw new NoInvoiceFoundException("No invoice found with ID: " + id);
            }
            return new InvoiceViewModel(invoice);
        }
    }
}
