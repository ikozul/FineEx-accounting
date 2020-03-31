namespace FineEx.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [Key]
        public int IdItem { get; set; }

        public int? InvoiceId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public double? Price { get; set; }

        public int? Amount { get; set; }

        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Company Company1 { get; set; }

        public virtual Company Company2 { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Invoice Invoice1 { get; set; }

        public virtual Invoice Invoice2 { get; set; }
    }
}
