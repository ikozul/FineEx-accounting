using FineEx.DataLayer.Context;
using FineEx.Dummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.DataLayer.Context;

namespace FineEx.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            try
            {
                var xompany = new Company()
                {
                    IdCompany = 1,
                    Name = "Algebra",
                    Address = "Ilica 242"
                };

                App.Db.Companies.Add(xompany);
                App.Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(UserLogin loginCredentials)
        {
            if (ModelState.IsValid && loginCredentials.Username.Trim() == "admin" && loginCredentials.Password.Trim() == "admin")
            {
                // provjera credentialsa
                Session["user"] = loginCredentials.Username;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.LoginError = true;
            ViewBag.LoginMessage = "Wrong username or password";
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        [Route("registration")]
        public ActionResult Registration()
        {
            ViewBag.Companies = new SelectList(new List<Company>()
            {
                new Company()
                {
                    IdCompany = 1,
                    Name = "Algebra",
                    Address = "Ilica 242"
                },
                new Company()
                {
                    IdCompany = 2,
                    Name = "Pliva",
                    Address = "Baruna Filipovica 25"
                },
                new Company()
                {
                    IdCompany = 3,
                    Name = "INA",
                    Address = "Veceslava Holjevca 10"
                }
            }, "IdCompany", "Name", 1);
            return View();
        }

        [HttpPost]
        [Route("registration")]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                // registriraj usera
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}