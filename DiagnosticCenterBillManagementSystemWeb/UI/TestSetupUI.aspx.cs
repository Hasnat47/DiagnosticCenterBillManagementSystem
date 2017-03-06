using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemWeb.BLL;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.UI
{
    public partial class TestSetupUI : System.Web.UI.Page
    {
        TestTypeSetupManager aTestTypeSetupManager=new TestTypeSetupManager();
        TestSetupManager aTestSetupManager=new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAllTest();
            if (!IsPostBack)
            {
                testTypeDropDownList.DataSource = aTestTypeSetupManager.ShowAllTypes();
                testTypeDropDownList.DataTextField = "TypeName";
                testTypeDropDownList.DataValueField = "Id";
                testTypeDropDownList.DataBind();
            }
        }

        protected void testSetupSaveButton_Click(object sender, EventArgs e)
        {
            TestSetup aTestSetup=new TestSetup();
            aTestSetup.TestName = testNameTextBox.Text;
            aTestSetup.Fee = Convert.ToDecimal(testFeeTextBox.Text);
            aTestSetup.TestTypeName =testTypeDropDownList.Text;

            messageLabel.Text = aTestSetupManager.SaveTest(aTestSetup);
            testFeeTextBox.Text = "";
            testNameTextBox.Text = "";
            ShowAllTest();
        }

        private void ShowAllTest()
        {
            List<TestSetup> aList =new List<TestSetup>();
            aList = aTestSetupManager.ShowAllTestSetups();
            testSetupGridView.DataSource = aList;
            testSetupGridView.DataBind();
        }

        protected void testSetupGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable aDataTable = new DataTable();
            aDataTable.DefaultView.Sort = e.SortExpression + "Desc";
        }
    }
}