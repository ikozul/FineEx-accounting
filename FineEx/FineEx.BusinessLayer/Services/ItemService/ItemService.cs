using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.ItemService
{
    public class ItemService : IItemService
    {
        private IQueryable<Item> _items;
        private readonly List<ItemViewModel> _itemsView = new List<ItemViewModel>();
        public List<ItemViewModel> GetItemsForCompany(int companyId)
        {
            _items = App.Db.Items.Where(x => x.CompanyId == companyId);
            GetItemViewModels();
            return _itemsView;
        }

        private void GetItemViewModels()
        {
            if (_itemsView.Count != 0)
                _itemsView.Clear();

            foreach (var item in _items)
            {
                _itemsView.Add(new ItemViewModel(item));
            }
        }
    }
}
