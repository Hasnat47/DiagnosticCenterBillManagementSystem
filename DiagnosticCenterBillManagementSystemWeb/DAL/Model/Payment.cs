using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Model
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public int ID { get; set; }
        public string Date { get; set; }
    }
}