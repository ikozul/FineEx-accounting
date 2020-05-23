using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Context;
using Newtonsoft.Json;

namespace FineEx.DataLayer.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public decimal ItemPrice { get; set; }
        public decimal ItemQuantity { get; set; }
        public string ItemName { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }    

        public string Name { get; set; }

        public IQueryable<Item> Search()
        {
            return App.Db.Items
                .Where(q => q.CompanyId == CompanyId && q.Name.StartsWith(Name))
                .AsQueryable();
        }
    }
}
