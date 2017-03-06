using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway aTestRequestGateway=new TestRequestGateway();

        public string FindFee(string value)
        {
            return aTestRequestGateway.FindFee(value);
        }
        public string SavePatientHistory(TestRequest aTestRequest)
        {
            if (aTestRequestGateway.MobileNumberExists(aTestRequest.Mobile))
            {
                return "Mobile is Exists";
            }

            int rowAffect = aTestRequestGateway.SavePatientHistory(aTestRequest);

            if (rowAffect > 0)
            {
                return "Saved";
            }
            else
            {
                return "Saved failed";
            }
        }

        public void SaveRecord(string testName, long ms, string date)
        {
            aTestRequestGateway.SaveRecord(testName, ms, date);
        }
    }
}