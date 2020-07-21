using FineEx.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineEx.BusinessLayer.Models.PaymentMethodModels
{
    public class PaymentMethodViewModel
    {
        public PaymentMethodViewModel(PaymentMethod pm)
        {
            Id = pm.Id;
            PaymentType = pm.PaymentType;
        }

        public PaymentMethodViewModel()
        {

        }

        public int Id { get; set; }
        public string PaymentType { get; set; }
    }
}
