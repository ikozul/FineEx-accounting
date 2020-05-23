using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.DataLayer.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string StreetName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }

        public int PostalCode { get; set; }

        [ForeignKey("CoutntryId")]
        public virtual Country Country { get;   set; }
    }
}