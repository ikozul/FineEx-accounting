using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Context;
using Newtonsoft.Json;

namespace FineEx.DataLayer.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index]
        [MaxLength(64)]
        public string BusinessNumber { get; set; }

        public string BusinessUnit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string GLN { get; set; }
        public string IBAN { get; set; }
        public string Phone { get; set; }
        public int PricePrecision { get; set; }
        public int QuantityPrecision { get; set; }

        [JsonIgnore]
        public virtual string PostalCode
        {
            get
            {
                int index = City.IndexOf(" ");
                if (index != -1)
                {
                    return City.Substring(0, index).Trim();
                }

                return string.Empty;
            }
        }

        [JsonIgnore]
        public virtual string CityName
        {
            get
            {
                int index = City.IndexOf(" ");
                if (index != -1)
                {
                    return City.Substring(index + 1).Trim();
                }

                return string.Empty;
            }
        }

        [JsonIgnore]
        public virtual string StreetName
        {
            get
            {
                int index = Address.LastIndexOf(" ");
                if (index != -1)
                {
                    return Address.Substring(0, index).Trim();
                }

                return string.Empty;
            }
        }

        [JsonIgnore]
        public virtual string StreetNumber
        {
            get
            {
                int index = Address.LastIndexOf(" ");
                if (index != -1)
                {
                    return Address.Substring(index + 1).Trim();
                }

                return string.Empty;
            }
        }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }

        [JsonIgnore]
        public virtual ICollection<Invoice> SentInvoices { get; set; }

        [JsonIgnore]
        public virtual ICollection<Invoice> ReceivedInvoices { get; set; }

        public Company()
        {
            if (PricePrecision == 0)
            {
                PricePrecision = 2;
            }
            if (QuantityPrecision == 0)
            {
                QuantityPrecision = 2;
            }

            Users = new HashSet<User>();
            Items = new HashSet<Item>();
            SentInvoices = new HashSet<Invoice>();
            ReceivedInvoices = new HashSet<Invoice>();
        }
    }
}
