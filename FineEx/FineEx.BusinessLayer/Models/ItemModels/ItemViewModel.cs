﻿using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            WarehouseQuantity = item.WarehouseQuantity;
        }

        public ItemViewModel()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal ItemPrice { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal WarehouseQuantity { get; set; }

        public void UpdateItem()
        {
            
        }
    }
}
