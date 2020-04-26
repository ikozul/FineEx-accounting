﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.DataLayer.Models
{
    public class User
    {
        [Key]
        // Don't auto-increment the field since we'll use the IDs from Moj-eRačun
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int LanguageId { get; set; }
        //[ForeignKey("LanguageId")] public virtual Language Language { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public string FullName => string.Format("{0} {1}", FirstName, LastName).Trim();

        public User()
        {
            Companies = new HashSet<Company>();
        }
    }
}
