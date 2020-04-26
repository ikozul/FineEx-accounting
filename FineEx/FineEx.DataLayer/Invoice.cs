namespace FineEx.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            Items = new HashSet<Item>();
            Items1 = new HashSet<Item>();
            Items2 = new HashSet<Item>();
        }

        [Key]
        public int IdInvoice { get; set; }

        public bool? Incoming { get; set; }

        public int? SenderCompanyId { get; set; }

        public int? RecipientCompanyId { get; set; }

        public DateTime? Date { get; set; }

        public int? IdLocation { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(255)]
        public string InvoiceNumber { get; set; }

        [StringLength(255)]
        public string EmployeeId { get; set; }

        [StringLength(255)]
        public string PaymentMethod { get; set; }

        [StringLength(255)]
        public string ProtectedCodeOfSupplier { get; set; }

        [StringLength(255)]
        public string UniqueIdentifierOfInvoice { get; set; }

        [StringLength(255)]
        public string VatNumber { get; set; }

        [StringLength(255)]
        public string VatSwiftBankClient { get; set; }

        public virtual Company Company { get; set; }

        public virtual Company Company1 { get; set; }

        public virtual Company Company2 { get; set; }

        public virtual Company Company3 { get; set; }

        public virtual Location Location { get; set; }

        public virtual Location Location1 { get; set; }

        public virtual Location Location2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items2 { get; set; }
    }
}
