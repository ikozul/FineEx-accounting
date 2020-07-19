using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.CompanyModels
{
    public class CompanyControlPanelModel
    {
        private Company _company;
        //private 
        public CompanyControlPanelModel(int id)
        {
            _company = App.Db.Companies.Single(x => x.Id == id);
            Company = new CompanyViewModel(_company);
            CompanyItems = App.Db.Items.Where(x => x.CompanyId == id);
        }

        public IQueryable<Item> CompanyItems { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}
