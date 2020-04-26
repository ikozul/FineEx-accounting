namespace FineEx.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int IdUser { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Surname { get; set; }

        public double? Salary { get; set; }

        public int? CompanyId { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string IdCardNumber { get; set; }

        [StringLength(255)]
        public string IdNumber { get; set; }

        public bool? IsActive { get; set; }

        public virtual Company Company { get; set; }

        public virtual Company Company1 { get; set; }

        public virtual Company Company2 { get; set; }
    }
}
