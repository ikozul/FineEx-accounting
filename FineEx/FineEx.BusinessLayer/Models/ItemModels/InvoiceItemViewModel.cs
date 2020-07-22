using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class InvoiceItemViewModel
    {
        public InvoiceItemViewModel(InvoiceItems invoiceItem)
        {
            this.Id = invoiceItem.Id;
            this.ItemQuantity = invoiceItem.ItemQuantity;
            this.Item = App.Db.Items.Single(x=>x.Id == invoiceItem.ItemId);
            this.Invoice = invoiceItem.Invoice;
        }

        public int Id { get; set; }
        public int ItemQuantity { get; set; }
        public Item Item { get; set; }
        public Invoice Invoice { get; set; }
    }
}
