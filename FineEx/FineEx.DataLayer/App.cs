using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FineEx.DataLayer.Service;

namespace FineEx.DataLayer
{
    public static class App
    {
        [ThreadStatic]
        private static DatabaseService DatabaseService;

        //public static DbFineEx Db
        //{
        //    get
        //    {
        //        if (HttpContext.Current == null)
        //        {
        //            if (DatabaseService == null)
        //            {
        //                DatabaseService = new DatabaseService();
        //            }

        //            return DatabaseService.db;
        //        }

        //        if (HttpContext.Current.Items.Contains("_db"))
        //            return ((DatabaseService)HttpContext.Current.Items["db"]).db;

        //        var dbService = new DatabaseService();
        //        HttpContext.Current.Items.Add("_db", dbService);

        //        return ((DatabaseService)HttpContext.Current.Items["db"]).db;
        //    }
        //}
    }
}
