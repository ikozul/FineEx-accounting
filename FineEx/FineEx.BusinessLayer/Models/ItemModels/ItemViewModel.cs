using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class ItemViewModel
    {
        public ItemViewModel(int id, string itemName, decimal itemPrice, decimal itemQuantity)
        {
            Id = id;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemQuantity = itemQuantity;
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemQuantity { get; set; }
    }
}
