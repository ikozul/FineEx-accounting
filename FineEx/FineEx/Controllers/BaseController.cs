using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

        protected void SetUserInSession(int id)
        {
            App.UserId = id;
        }

        protected void SetCompanyInSession(int id)
        {
            App.CompanyId = id;
        }
    }
}