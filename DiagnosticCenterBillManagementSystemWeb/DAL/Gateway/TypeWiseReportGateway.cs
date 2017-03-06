using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class TypeWiseReportGateway:Gateway
    {
        public List<TestWiseReport> ShowReport(string text, string s)
        {
            Query = "SELECT tts.TypeName, count(*) as TypeNo, SUM(pt.Fee) as Fee from PatientTest pt JOIN TestTypeSetup tts ON pt.TestTypeId = tts.Id WHERE (TestDate BETWEEN '" + text + "' AND '" + s + "') GROUP BY tts.TypeName";

            Command = new SqlCommand(Query, Connection);
            string result = "";
            double totalAmount = 0;
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TestWiseReport> atestWiseReportList = new List<TestWiseReport>();
            while (Reader.Read())
            {
                TestWiseReport aTestWiseReport = new TestWiseReport();
                aTestWiseReport.Name = Reader["TypeName"].ToString();
                aTestWiseReport.TotalTest = (int)Reader["TypeNo"];
                aTestWiseReport.TotalFee =Convert.ToDecimal(Reader["Fee"]);
                atestWiseReportList.Add(aTestWiseReport);
            }

            Connection.Close();
            return atestWiseReportList;
        }
    }
}