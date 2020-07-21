using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.UserModels
{
    public class UserViewModel
    {
        private const int _adminRoleId = 90;

        public UserViewModel(int id, string firstName, string lastName, string email, Role role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public bool IsSiteAdmin => Role.Id >= _adminRoleId;

        public override string ToString() => $"{FirstName} {LastName}";

    }
}
