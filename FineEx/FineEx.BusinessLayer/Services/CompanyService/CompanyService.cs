using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private IQueryable<Company> _companies;
        private readonly List<CompanyViewModel> _companiesView = new List<CompanyViewModel>();
        public List<CompanyViewModel> GetCompanies()
        {
            _companies = App.Db.Companies;
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
    }
}
