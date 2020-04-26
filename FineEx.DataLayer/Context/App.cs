using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FineEx.DataLayer.Models;

namespace FineEx.DataLayer.Context
{
    public static class App
    {
        public static DbFineEx Db
        {
            get
            {
                if (HttpContext.Current.Items.Contains("_db"))
                    return (DbFineEx)HttpContext.Current.Items["_db"];

                var dbService = new DbFineEx();
                HttpContext.Current.Items.Add("_db", dbService);

                return (DbFineEx)HttpContext.Current.Items["_db"];
            }
        }

        public static string Language
        {
            get
            {
                var cultureCookie = HttpContext.Current.Request.Cookies["_culture"];
                return cultureCookie != null ? cultureCookie.Value : "hr";
            }
        }
        
        public static int? UserId
        {
            get { return HttpContext.Current.Session["UserId"] as int?; }
            set { HttpContext.Current.Session["UserId"] = value; }
        }

        public static string UserPassword
        {
            get { return HttpContext.Current.Session["UserPassword"] as string; }
            set { HttpContext.Current.Session["UserPassword"] = value; }
        }

        public static User User
        {
            get
            {
                if (UserId.HasValue)
                {
                    return Db.Users.FirstOrDefault(u => u.Id == UserId);
                }

                return null;
            }
        }
    }
}
