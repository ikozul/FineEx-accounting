using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class InvoiceItemViewModel : InvoiceItems
    {
        public InvoiceItemViewModel(InvoiceItems invoiceItem)
        {
            this.Id = invoiceItem.Id;
            this.ItemQuantity = invoiceItem.ItemQuantity;
            this.Item = invoiceItem.Item;
            this.Invoice = invoiceItem.Invoice;
        }
    }
}
