using FineEx.BusinessLayer.Exceptions;
using FineEx.BusinessLayer.Models.User;
using FineEx.BusinessLayer.Services.Login;
using FineEx.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineEx.Controllers
{
    public class AccountController : BaseController
    {
        private LoginService loginService;

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginViewModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    loginService = new LoginService();
                    UserViewModel user = loginService.GetUser(loginCredentials);
                    Session["user"] = user;
                }
                catch (InvalidCredentialsException ex)
                {
                    ViewBag.LoginError = true;
                    ViewBag.LoginMessage = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("registration")]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [Route("registration")]
        public ActionResult Registration(UserCreateModel user)
        {
            if (ModelState.IsValid)
            {
                // registriraj usera
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}