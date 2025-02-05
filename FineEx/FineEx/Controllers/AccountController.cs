﻿using FineEx.BusinessLayer.Exceptions;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.BusinessLayer.Services.Login;
using FineEx.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.BusinessLayer.Models.InvoiceModels;
using FineEx.BusinessLayer.Services.PdfGenerator;
using FineEx.DataLayer.Models;
using System.Globalization;
using FineEx.BusinessLayer.Models.Registration;
using FineEx.BusinessLayer.Services.Registration;

namespace FineEx.Controllers
{
    public class AccountController : BaseController
    {
        private LoginService _loginService = new LoginService();
        private UserViewModel _user;
        private RegistrationService _registrationService;


        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Invoice");
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginViewModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _user = _loginService.GetUser(loginCredentials);
                    SetUserInSession(_user.Id);
                    Session["user"] = _user;
                }
                catch (InvalidCredentialsException ex)
                {
                    ViewBag.LoginError = true;
                    ViewBag.LoginMessage = ex.Message;
                    return View();
                }
            }

            if (_user.IsSiteAdmin)
                return RedirectToAction("Index", "Administration");

            return RedirectToAction("Index", "Invoice");
        }

        [HttpGet]
        [Route("registration")]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [Route("registration")]
        public ActionResult Registration(RegistrationViewModel registration)
        {
            if (ModelState.IsValid)
            {
                _registrationService = new RegistrationService(registration);
                _registrationService.RegisterBusinessUser();
                return RedirectToAction("Login");
            }
            return View(registration);
        }

        /// <summary>
        /// This is important for registration
        /// </summary>
        /// <param name="EmailRegistration"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public JsonResult IsUserEmailAvailable(string EmailRegistration)
        {
            return Json(!App.Db.Users.Any(x => x.Email == EmailRegistration), JsonRequestBehavior.AllowGet);
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