using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class UnpaidBillReportGateway:Gateway
    {
        public List<UnpaidBillReport> ShowAllUnpaid(string from, string to)
        {
            Query = "SELECT BillNo, PatientName, MobileNo, Total From TestRequest Where TestDate BETWEEN '" + from + "' AND '" + to + "'and Total>0";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<UnpaidBillReport> aUnpaidBillReportList = new List<UnpaidBillReport>();

            while (Reader.Read())
            {
                UnpaidBillReport aUnpaidBillReport = new UnpaidBillReport();

                aUnpaidBillReport.BillNo = Reader["BillNo"].ToString();
                aUnpaidBillReport.PatientName = Reader["PatientName"].ToString();
                aUnpaidBillReport.MobileNo = Reader["MobileNo"].ToString();
                aUnpaidBillReport.BillAmount =Convert.ToDecimal(Reader["Total"]);
                aUnpaidBillReportList.Add(aUnpaidBillReport);
            }
            Connection.Close();
            return aUnpaidBillReportList;
        }
    }
}