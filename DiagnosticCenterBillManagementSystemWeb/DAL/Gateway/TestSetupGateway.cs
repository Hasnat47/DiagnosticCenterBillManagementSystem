using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class TestSetupGateway:Gateway
    {
        public int SaveTest(TestSetup aTestSetup)
        {
            Query = "INSERT INTO TestSetup VALUES('" + aTestSetup.TestName + "','" + aTestSetup.Fee + "','" +
                    aTestSetup.TestTypeName + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowaffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffected;
        }

        public List<TestSetup> ShowAllTest()
        {
            List<TestSetup> aTestSetups=new List<TestSetup>();
            //Query = "SELECT * FROM TestSetup";
            Query="SELECT ts.TestName,ts.Fee,tts.TypeName FROM TestSetup ts JOIN TestTypeSetup tts ON ts.TestTypeSetupId=tts.Id";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TestSetup aTestSetup=new TestSetup();
                aTestSetup.TestName = Reader["TestName"].ToString();
                aTestSetup.Fee = Convert.ToDecimal(Reader["Fee"]);
                aTestSetup.TestTypeName = Reader["TypeName"].ToString();
                //aTestSetup.Id = (int) Reader["Id"];
                aTestSetups.Add(aTestSetup);

            }
            Connection.Close();
            return aTestSetups;
        }
        public bool IsTestExists(TestSetup aTestSetup)
        {
            Query = "SELECT * FROM TestSetup WHERE TestName = '" + aTestSetup.TestName + "'";
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