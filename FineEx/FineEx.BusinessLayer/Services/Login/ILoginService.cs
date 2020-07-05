using FineEx.BusinessLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.Login
{
    public interface ILoginService
    {
        UserViewModel GetUser(LoginViewModel loginViewModel);
    }
}
