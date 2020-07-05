using FineEx.BusinessLayer.Exceptions;
using FineEx.BusinessLayer.Models.User;
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
        public UserViewModel GetUser(LoginViewModel loginViewModel) 
        {
            using (DbFineEx db = new DbFineEx())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == loginViewModel.Email);
                if (user == null)
                {
                    throw new InvalidCredentialsException("Invalid Email");
                } 
                else if (user.Password == PasswordHelper.HashPassword(loginViewModel.Password))
                {
                    return new UserViewModel(user.FirstName, user.LastName, user.Email, user.Role);
                }
                else
                {
                    throw new InvalidCredentialsException("Invalid Password");
                }
            }
        }        
    }
}
