using FineEx.BusinessLayer.Models.PaymentMethodModels;
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.PaymentMethodService
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private IQueryable<PaymentMethod> _paymentMethods;
        private readonly List<PaymentMethodViewModel> _paymentMethodsView = new List<PaymentMethodViewModel>();

        public List<PaymentMethodViewModel> GetPaymentMethods()
        {
            _paymentMethods = App.Db.PaymentMethods;
            GetPaymentMethodViewModels();
            return _paymentMethodsView;
        }

        public void GetPaymentMethodViewModels()
        {
            if (_paymentMethodsView.Count != 0)
                _paymentMethodsView.Clear();

            foreach (var pm in _paymentMethods)
            {
                _paymentMethodsView.Add(new PaymentMethodViewModel(pm));
            }
        }
    }
}
