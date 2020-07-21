using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.UserModels;

namespace FineEx.BusinessLayer.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private Company _company;
        private IQueryable<Company> _companies;
        private readonly List<CompanyViewModel> _companiesView = new List<CompanyViewModel>();
        public List<CompanyViewModel> GetCompanies()
        {
            _companies = App.Db.Companies;
            GetCompanyViewModels();
            return _companiesView;
        }
        public List<CompanyViewModel> GetCompanies(int userId)
        {
            _companies = App.Db.Users.Single(x=>x.Id == userId).Companies.AsQueryable();
            GetCompanyViewModels();
            return _companiesView;
        }

        public void GetCompanyViewModels()
        {
            if (_companiesView.Count != 0)
                _companiesView.Clear();

            foreach (var company in _companies)
            {
                _companiesView.Add(new CompanyViewModel(company));
            }

        }

        public void UpdateCompany(CompanyViewModel model)
        {
            _company = App.Db.Companies.Single(x => x.Id == model.Id);
            _company.Address = model.Address;
            _company.BusinessNumber = model.BusinessNumber;
            _company.City = model.City;
            _company.County = model.Country;
            _company.IBAN = model.IBAN;
            _company.Phone = model.Phone;
            App.Db.SaveChanges();
        }

        public bool ValidateInput(CompanyViewModel model)
        {
            //Todo determine what to validate

            return true;
        }

        public void UpdateUser(UserViewModel model)
        {
            var user = App.Db.Users.Single(x => x.Id == model.Id);
        }
    }
}
