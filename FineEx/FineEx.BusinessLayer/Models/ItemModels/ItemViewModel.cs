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
        public ItemViewModel(Item item)
        {
            Id = item.Id;
            ItemName = item.ItemName;
            ItemPrice = item.ItemPrice;
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
