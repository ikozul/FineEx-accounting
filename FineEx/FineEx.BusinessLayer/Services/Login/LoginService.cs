using FineEx.BusinessLayer.Exceptions;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.BusinessLayer.Utils;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.Login
{
    public class LoginService : ILoginService
    {
        private User _user;

        public UserViewModel GetUser(LoginViewModel loginViewModel) 
        {
            using (DbFineEx db = new DbFineEx())
            {
                _user = db.Users.FirstOrDefault(u => u.Email == loginViewModel.Email);
                if (_user == null)
                {
                    throw new InvalidCredentialsException("Invalid Email");
                } 
                else if (_user.Password == PasswordHelper.HashPassword(loginViewModel.Password))
                {
                    return new UserViewModel(_user.FirstName, _user.LastName, _user.Email, _user.Role);
                }
                else
                {
                    throw new InvalidCredentialsException("Invalid Password");
                }
            }
        }        
    }
}
