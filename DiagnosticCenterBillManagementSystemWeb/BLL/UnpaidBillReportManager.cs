using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class UnpaidBillReportManager
    {
        UnpaidBillReportGateway aUnpaidBillReportGateway = new UnpaidBillReportGateway();
        public List<UnpaidBillReport> ShowAllUnpaid(string from, string to)
        {
            return aUnpaidBillReportGateway.ShowAllUnpaid(from, to);
        }
    }
}