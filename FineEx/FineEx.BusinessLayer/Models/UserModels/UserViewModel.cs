using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Utils;
using FineEx.DataLayer.Context;

namespace FineEx.BusinessLayer.Models.UserModels
{
    public class UserViewModel
    {
        private int _companyAdminRoldId = 50;
        private const int _adminRoleId = 90;

        public UserViewModel()
        {

        }
        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Role;
            Password = user.Password;
            PasswordRepeat = user.Password;
        }

        public UserViewModel(int companyId)
        {
            CompanyId = companyId;
        }

        public UserViewModel(int id, string firstName, string lastName, string email, Role role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Role Role { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "*")]
        public string PasswordRepeat { get; set; }

        public int CompanyId { get; set; }

        public bool IsSiteAdmin => Role?.Id >= _adminRoleId;
        public bool IsCompanyAdmin => Role?.Id >= _companyAdminRoldId;

        public override string ToString() => $"{FirstName} {LastName}";

        public bool UpdateUser()
        {
            var user = App.Db.Users.Single(x => x.Id == Id);
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Password = PasswordHelper.HashPassword(Password);
            user.Email = Email;
            return App.Db.SaveChanges() > 0;
        }
    }
}
