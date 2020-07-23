using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.Registration;
using FineEx.BusinessLayer.Utils;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly RegistrationViewModel _registration;
        private Company _company;
        

        public RegistrationService(RegistrationViewModel registration)
        {
            _registration = registration;
        }
        public void RegisterBusinessUser()
        {
            _company = RegisterCompany();
            RegisterUserForCompany();
        }

        private void RegisterUserForCompany()
        {
           var user = new User();
           user.Companies.Add(_company);
           user.FirstName = _registration.User.FirstName;
           user.LastName = _registration.User.LastName;
           user.Email = _registration.User.Email;
           user.Password = PasswordHelper.HashPassword(_registration.User.Password);
           user.RoleId = 50;
           user.IsActive = true;

           App.Db.Users.Add(user);
           App.Db.SaveChanges();
        }

        private Company RegisterCompany()
        {
            var company = new Company
            {
                Address = _registration.Company.Address,
                BusinessNumber = _registration.Company.BusinessNumber,
                BusinessUnit = _registration.Company.BusinessUnit,
                City = _registration.Company.City,
                Name = _registration.Company.CompanyName,
                IBAN = _registration.Company.IBAN,
                County = _registration.Company.Country,
                PricePrecision = 2,
                QuantityPrecision = 2
            };

            App.Db.Companies.Add(company);
            App.Db.SaveChanges();
            return company;
        }
    }
}
