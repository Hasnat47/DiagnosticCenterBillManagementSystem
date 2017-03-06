using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.DAL.Gateway
{
    public class PaymentGateway:Gateway
    {
        public List<Payment> Search(string bill, string mobile)
        {
            Query = "SELECT Id, Total, TestDate FROM TestRequest WHERE MobileNo = '" + mobile + "' OR BillNo = '" + bill + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Payment> paymentList = new List<Payment>();
            while (Reader.Read())
            {
                Payment aPayment = new Payment();
               aPayment.Amount =Convert.ToDecimal(Reader["Total"]);
                aPayment.ID = (int)Reader["Id"];
                aPayment.Date = Reader["TestDate"].ToString();

                paymentList.Add(aPayment);

            }

            Connection.Close();

            return paymentList;
        }
        public int Pay(string id)
        {
            string status = "Paid";
            decimal total = 0;
            Query = "UPDATE TestRequest SET PaymentStatus =  '" + status + "' , Total= '"+total+"' Where Id = '" + id + "' ";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffect = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffect;
        }
    }
}