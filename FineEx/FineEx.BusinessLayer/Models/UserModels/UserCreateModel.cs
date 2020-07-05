using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.UserModels
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Name is required.", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required.", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.", AllowEmptyStrings = false)]
        public string Password { get; set; }        
    }
}
