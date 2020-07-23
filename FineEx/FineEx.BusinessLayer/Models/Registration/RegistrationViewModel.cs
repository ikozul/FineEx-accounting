using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.UserModels;

namespace FineEx.BusinessLayer.Models.Registration
{
    public class RegistrationViewModel
    {
        public UserCreateModel User { get; set; }
        public CompanyCreateModel Company { get; set; }
        [System.Web.Mvc.Remote("IsUserEmailAvailable", "Account")]
        [EmailAddress()]
        [DataType(DataType.EmailAddress)]
        public string EmailRegistration { get; set; }
    }
}
