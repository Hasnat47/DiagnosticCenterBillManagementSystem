using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class TestWiseReportGateway:Gateway
    {
        public List<TestWiseReport> ShowReport(string text, string s)
        {
            Query ="SELECT t.fee as Fee, TestName,COUNT(*) as TotalTest from PatientTest th JOIN TestSetup t ON th.TestSetupId = t.Id WHERE (TestDate BETWEEN '" +
                text + "' AND '" + s + "') GROUP BY TestName, t.Fee"; 

            Command = new SqlCommand(Query, Connection);
            string result = "";
            //double totalAmount = 0;
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TestWiseReport> aTestWiseReportList = new List<TestWiseReport>();
            while(Reader.Read())
            {
                TestWiseReport atestWiseReport = new TestWiseReport();
                atestWiseReport.Name = Reader["TestName"].ToString();
                atestWiseReport.TotalTest = (int) Reader["TotalTest"];
               atestWiseReport.TotalFee = Convert.ToDecimal(Reader["Fee"]) * atestWiseReport.TotalTest;
                aTestWiseReportList.Add(atestWiseReport);
            }
            Connection.Close();

            return aTestWiseReportList;
        }
    }
}