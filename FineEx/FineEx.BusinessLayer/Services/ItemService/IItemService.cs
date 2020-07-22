using FineEx.BusinessLayer.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.ItemService
{
    public interface IItemService
    {
        List<ItemViewModel> GetItemsForCompany(int companyId);

        void CreateInvoiceItems(int invoiceId, List<ItemCreateModel> invoiceItems)
    }
}
