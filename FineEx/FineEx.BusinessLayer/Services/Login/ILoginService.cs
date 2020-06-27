using FineEx.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.Login
{
    public interface ILoginService
    {
        LoginViewModel GetUser(string username, string password);
    }
}
