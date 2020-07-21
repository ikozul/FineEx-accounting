using FineEx.BusinessLayer.Models.PaymentMethodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Services.PaymentMethodService
{
    public interface IPaymentMethodService
    {
        List<PaymentMethodViewModel> GetPaymentMethods();
    }
}
