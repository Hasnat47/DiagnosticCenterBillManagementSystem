using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.BLL
{
    public class TestTypeSetupManager
    {
        TestTypeSetupGateway aTestTypeSetupGateway = new TestTypeSetupGateway();
        public string SaveTestType(TestTypeName aTestTypeName)
        {
            string message = "";

            if (aTestTypeSetupGateway.IsTestTypeNameExist(aTestTypeName))
            {
                message = "Type Name already Exist!";
            }
            else
            {
                int rowAffected = aTestTypeSetupGateway.SaveTestTypeName(aTestTypeName);
                if (rowAffected > 0)
                {
                    message = "Save Successfully";
                }
                else
                {
                    message = "Save failed";
                }
            }


            return message;
        }

        public List<TestTypeName> ShowAllTypes()
        {
            return aTestTypeSetupGateway.GetAllTestTypeNames();
        }
    }
}