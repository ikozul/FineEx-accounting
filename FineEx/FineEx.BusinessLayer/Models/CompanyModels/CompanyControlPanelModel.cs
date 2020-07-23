using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineEx.BusinessLayer.Models.CompanyModels
{
    public class CompanyControlPanelModel
    {
        private Company _company;
        public List<ItemViewModel> CompanyItems { get; set; }
        public List<UserViewModel> CompanyUsers { get; set; }

        public CompanyControlPanelModel(int id)
        {
            App.CompanyId = id;
            _company = App.Db.Companies.Single(x => x.Id == id);
            Company = new CompanyViewModel(_company);
            CompanyItems = new List<ItemViewModel>();
            CompanyUsers = new List<UserViewModel>();
            FillViewModels();

        }

        private void FillViewModels()
        {
            foreach (var item in App.Db.Items.Where(x=>x.CompanyId == _company.Id))
                CompanyItems.Add(new ItemViewModel(item));

            foreach (var user in _company.Users)
                CompanyUsers.Add(new UserViewModel(user));


        }

        public bool EditItem(ItemViewModel model)
        {
            var item = App.Db.Items.Single(x => x.Id == model.Id);
            item.ItemName = model.ItemName;
            item.ItemPrice = model.ItemPrice;
            item.WarehouseQuantity = model.WarehouseQuantity;
            return App.Db.SaveChanges() > 0;
        }

        public CompanyViewModel Company { get; set; }
    }
}
