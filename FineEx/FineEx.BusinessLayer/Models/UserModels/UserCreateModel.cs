using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Utils;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

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

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string PasswordRepeat { get; set; }

        public int CompanyId { get; set; }

        public void CreateUser()
        {
            User user = new User();
            user.Companies.Add(App.Db.Companies.Single(x=>x.Id == CompanyId));
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
            user.RoleId = 50;
            user.Password = PasswordHelper.HashPassword(Password);
            App.Db.Users.Add(user);
            App.Db.SaveChanges();
        }
    }
}
