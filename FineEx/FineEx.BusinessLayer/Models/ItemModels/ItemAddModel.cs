using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.ItemModels
{
    public class ItemAddModel : ItemCreateModel
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string ItemName { get; set; }

        public int CompanyId { get; set; }
    }
}
