using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class PaymentManager
    {
        private PaymentGateway aPaymentGateway = new PaymentGateway();

        public List<Payment> Search(string bill, string mobile)
        {
            return aPaymentGateway.Search(bill, mobile);

        }

        public string Pay(string id)
        {
            int rowAffect = aPaymentGateway.Pay(id);
            if (rowAffect > 0)
            {
                return "Paid";
            }
            else
            {
                return "Payment process failed";
            }
        }
    }
}