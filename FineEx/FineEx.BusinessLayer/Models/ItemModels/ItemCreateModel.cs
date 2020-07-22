using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class ItemCreateModel
    {
        [Required(ErrorMessage = "*")]
        public int SelectedItemID { get; set; }
        public int SelectedQuantity { get; set; }
        public decimal SelectedPrice { get; set; }

        public InvoiceItems GetInvoiceItemModel(int newInvoiceId)
        {
            InvoiceItems item = new InvoiceItems();
            item.InvoiceId = newInvoiceId;
            item.ItemId = SelectedItemID;
            item.ItemQuantity = SelectedQuantity;
            return item;
        }
    }
}
