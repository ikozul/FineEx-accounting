using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class ItemCreateModel
    {
        public List<int> SelectedItemIds { get; set; }
        public List<ItemViewModel> Items { get; set; }

        [Required(ErrorMessage = "*")]
        public int SelectedItemID { get; set; }
        public int SelectedQuantity { get; set; }
        public decimal SelectedPrice { get; set; }
    }
}
