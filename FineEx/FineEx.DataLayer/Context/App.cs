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

        public static int UserId { get; set; }
    }
}
