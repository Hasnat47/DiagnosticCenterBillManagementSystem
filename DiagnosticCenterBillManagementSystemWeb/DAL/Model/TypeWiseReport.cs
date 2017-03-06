using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Model
{
    public class TypeWiseReport
    {
        public string Name { get; set; }
        public int TotalTest { get; set; }
        public decimal TotalFee { get; set; }
    }
}