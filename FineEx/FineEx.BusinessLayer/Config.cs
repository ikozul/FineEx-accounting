using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace FineEx.BusinessLayer
{
    public static class Config
    {
        // temp
        public const string Salt = "(*.*)Fine(*_*)Ex_(*o*)_";
        public static string  PdfPath = WebConfigurationManager.AppSettings["PFUserName"];
    }
}
