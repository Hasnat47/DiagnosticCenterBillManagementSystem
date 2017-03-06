using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Model
{
    public class TestSetup
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public decimal Fee { get; set; }
        public string TestTypeName { get; set; }
    }
}