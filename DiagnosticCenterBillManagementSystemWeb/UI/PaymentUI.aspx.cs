using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemWeb.BLL;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        PaymentManager aPaymentManager=new PaymentManager();
        List<Payment> aPaymentList=new List<Payment>(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void paymentSearchButton_Click(object sender, EventArgs e)
        {
            aPaymentList = aPaymentManager.Search(billNoTextBox.Text, mobileNoTextBox.Text);
            foreach (Payment payment in aPaymentList)
            {
                amountTextBox.Text = payment.Amount.ToString();
                duedateTextBox.Text = payment.Date;
                messageHiddenTextField.Value = payment.ID.ToString();
            }
        }

        protected void paymentButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = aPaymentManager.Pay(messageHiddenTextField.Value);
        }
    }
}