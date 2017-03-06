using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class TestWiseReportManager
    {
        TestWiseReportGateway aTestWiseReportGateway = new TestWiseReportGateway();

        public List<TestWiseReport> ShowReport(string text, string s)
        {
            return aTestWiseReportGateway.ShowReport(text, s);
        }
    }
}