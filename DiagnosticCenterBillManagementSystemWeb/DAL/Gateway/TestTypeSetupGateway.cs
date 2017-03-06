using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class TestTypeSetupGateway:Gateway
    {
        public bool IsTestTypeNameExist(TestTypeName aTestTypeName)
        {
            Query = "SELECT * FROM TestTypeSetup WHERE TypeName = '" + aTestTypeName.TypeName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            bool hasRow = false;

            if (reader.HasRows)
            {
                hasRow = true;
            }

            reader.Close();
            Connection.Close();

            return hasRow;
        }
        public int SaveTestTypeName(TestTypeName aTestTypeName)
        {

            Query = "INSERT INTO TestTypeSetup VALUES('" + aTestTypeName.TypeName + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public List<TestTypeName> GetAllTestTypeNames()
        {
            Query = "SELECT * FROM TestTypeSetup";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<TestTypeName> aTestTypeNames = new List<TestTypeName>();
            while (reader.Read())
            {
                TestTypeName aTestTypeName = new TestTypeName();
                aTestTypeName.Id = (int)reader["Id"];
                aTestTypeName.TypeName = reader["TypeName"].ToString();
                aTestTypeNames.Add(aTestTypeName);

            }
            reader.Close();
            Connection.Close();
            return aTestTypeNames;
        }

        //public List<TestTypeName> GetTestTypeNames()
        //{
        //    Query = "SELECT TypeName FROM TestTypeSetup";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    SqlDataReader reader = Command.ExecuteReader();
        //    List<TestTypeName> aTestTypeNames = new List<TestTypeName>();
        //    while (reader.Read())
        //    {
        //        TestTypeName aTestTypeName = new TestTypeName();
        //        aTestTypeName.TypeName = reader["TypeName"].ToString();
        //        aTestTypeNames.Add(aTestTypeName);
        //    }
        //    reader.Close();
        //    Connection.Close();
        //    return aTestTypeNames;
        //}
    }
}