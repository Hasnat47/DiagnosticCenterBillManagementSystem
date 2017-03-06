using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Model
{
    [Serializable]
    public class UnpaidBillReport
    {
        public string PatientName { get; set; }
        public string BillNo { get; set; }
        public string MobileNo { get; set; }
        public decimal BillAmount { get; set; }
    }
}