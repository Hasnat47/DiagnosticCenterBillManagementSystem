using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Model
{
    [Serializable]
    public class TestRequest
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Mobile { get; set; }
        public decimal Fee { get; set; }
        public string Date { get; set; }
        public string BillNo { get; set; }
        public string TestName { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
    }
}