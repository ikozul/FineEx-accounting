using FineEx.BusinessLayer.Models.UserModels;
using FineEx.BusinessLayer.Services.Login;
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

        private LoginService loginService = new LoginService();

        [HttpPost]
        [Route("login")]
        public UserViewModel Login(LoginViewModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserViewModel user = loginService.GetUser(loginCredentials);
                    return user;
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
        public async Task<IHttpActionResult> Register(UserCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TO DO: REGISTRIRAJ KORISNIKA
            //var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            //IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            //if (!result.Succeeded)
            //{
            //    return GetErrorResult(result);
            //}

            return Ok();
        }

    }
}
