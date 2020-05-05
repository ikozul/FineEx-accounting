using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FineEx.Dummy
{
    public class User
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Name is required.", AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.", AllowEmptyStrings = false)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Company")]
        public Company Company { get; set; }
        public UserLogin LoginCredentials { get; set; }

        [Required(ErrorMessage = "Card Number ID is required.", AllowEmptyStrings = false)]
        [Display(Name = "ID card number")]
        public string IdCardNumber { get; set; }

        [Required(ErrorMessage = "Number ID is required.", AllowEmptyStrings = false)]
        [Display(Name = "PIN")]
        public string IdNumber { get; set; }

        public override string ToString() => $"{Name} {Surname} ({LoginCredentials.Username})";
    }
}