using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class ItemViewModel : Item
    {
        public ItemViewModel(int id, string itemName, decimal itemPrice, decimal warehouseQuantity)
        {
            Id = id;
            ItemName = itemName;
            ItemPrice = itemPrice;
            WarehouseQuantity = warehouseQuantity;
        }

    }
}
