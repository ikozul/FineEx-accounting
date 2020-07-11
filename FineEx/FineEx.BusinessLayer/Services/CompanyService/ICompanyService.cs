using FineEx.BusinessLayer.Models.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.CompanyService
{
    public interface ICompanyService
    {
        List<CompanyViewModel> GetCompanies();
        void GetCompanyViewModels();
    }
}
