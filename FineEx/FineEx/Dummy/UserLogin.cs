using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FineEx.Dummy
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required.", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Resources.Login.Login), Name = nameof(Resources.Login.Login.Username))]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Resources.Login.Login), Name = nameof(Resources.Login.Login.Password))]
        public string Password { get; set; }
    }
}