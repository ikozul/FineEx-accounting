using FineEx.BusinessLayer.Models.UserModels;
using FineEx.BusinessLayer.Services.Login;
using FineEx.BusinessLayer.Utils;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace FineExApi.Controllers
{
    public class AccountController : ApiController
    {
        private DbFineEx db = new DbFineEx();

        [HttpPost]
        public User Login(LoginViewModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = db.Users.FirstOrDefault(u => u.Email == loginCredentials.Email);
                    if (user == null)
                    {
                        return null;
                    }
                    else if (user.Password == PasswordHelper.HashPassword(loginCredentials.Password))
                    {
                        user.Password = null;
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(UserCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (db.Users.FirstOrDefault(u => u.Email == model.Email) == null)
            {
                return NotFound();
            }
            User user = new User() {FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = PasswordHelper.HashPassword(model.Password)};
            db.Users.Add(user);
            db.SaveChanges();

            return Ok();
        }

    }
}
