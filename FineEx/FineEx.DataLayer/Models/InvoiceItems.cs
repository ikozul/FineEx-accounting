using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FineEx.DataLayer.Models
{
    public class InvoiceItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; } 
        public virtual Invoice Invoice { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int ItemQuantity { get; set; }
    }
}
