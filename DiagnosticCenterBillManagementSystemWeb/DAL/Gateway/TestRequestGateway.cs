using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.BLL;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class TestRequestGateway:Gateway
    {
        public string FindFee(string value)
        {
            Query = "SELECT Fee From TestSetup WHERE TestName = '" + value + "'";

            Command = new SqlCommand(Query, Connection);
            string result = "";
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                result = Reader["Fee"].ToString();

            }

            Connection.Close();

            return result;
        }
        private int GetTestType(string test)
        {
            Query = "SELECT TestTypeSetupId From TestSetup Where TestName= '" + test + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            int id = 0;
            if (Reader.Read())
            {
                id = (int)Reader["TestTypeSetupId"];
            }

            Connection.Close();

            return id;
        }
        public int SavePatientHistory(TestRequest aTestRequest)
        {
            int type = GetTestType(aTestRequest.TestName);
            Query = "INSERT INTO TestRequest (BillNo, PatientName, DOB, MobileNo, TestDate, Total, PaymentStatus) VALUES ('" 
                + aTestRequest.BillNo + "', '" + aTestRequest.Name + "', '" + aTestRequest.Birthdate 
                + "', '" + aTestRequest.Mobile + "', '" + aTestRequest.Date + "', '" + aTestRequest.TotalAmount 
                + "', '" + aTestRequest.PaymentStatus + "') ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public void SaveRecord(string testName, long ms, string date)
        {
            int pId = GetPId(ms);

            Query = "INSERT into PatientTest(TestSetupId, TestTypeId, TestDate, Fee, TestRequestId) select  Id, TestTypeSetupId, '" + date + "', Fee, '" + pId + "' from TestSetup WHERE TestName = '" + testName + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        private int GetPId(long ms)
        {
            Query = "SELECT Id, TestDate  From TestRequest Where BillNo = '" + ms + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            int id = 0;
            string date = null;
            if (Reader.Read())
            {
                id = (int)Reader["Id"];

            }

            Connection.Close();

            return id;
        }
        public bool MobileNumberExists(string mobile)
        {
            Query = "Select * from TestRequest where MobileNo = '" + mobile + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }
    }
}