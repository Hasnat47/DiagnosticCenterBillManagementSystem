using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway aTestSetupGateway=new TestSetupGateway();

        public string SaveTest(TestSetup aTestSetup)
        {
            if (aTestSetupGateway.IsTestExists(aTestSetup))
            {
                return "Test Already Existed";
            }
            int rowAffected = aTestSetupGateway.SaveTest(aTestSetup);
            if (rowAffected>0)
            {
                return "Test Saved";
            }
            return "Test Save Failed";
        }

        public List<TestSetup> ShowAllTestSetups()
        {
            return aTestSetupGateway.ShowAllTest();
        }
    }
}