using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class TypeWiseReportManager
    {
        TypeWiseReportGateway aTypeWiseReportGateway = new TypeWiseReportGateway();
        public List<TestWiseReport> ShowReport(string text, string s)
        {
            return aTypeWiseReportGateway.ShowReport(text, s);
        }
    }
}