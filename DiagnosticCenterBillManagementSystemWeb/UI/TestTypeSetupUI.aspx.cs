using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemWeb.BLL;
using DiagnosticCenterBillManagementSystemWeb.DAL.Gateway;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;

namespace DiagnosticCenterBillManagementSystemWeb.UI
{
    public partial class TestTypeSetupUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestTypeDataGriedView();
        }
        private void TestTypeDataGriedView()
        {
            TestTypeSetupGateway aTestTypeGateway = new TestTypeSetupGateway();
            List<TestTypeName> aTestTypeNames = aTestTypeGateway.GetAllTestTypeNames();
            testTypeSetupGridView.DataSource = aTestTypeNames;
            testTypeSetupGridView.DataBind();

        }
        TestTypeSetupManager aTestTypeSetupManager = new TestTypeSetupManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestTypeName aTestTypeName = new TestTypeName();
            aTestTypeName.TypeName = testTypeSetupTextBox.Text;
            messageLabel.Text = aTestTypeSetupManager.SaveTestType(aTestTypeName);
            TestTypeDataGriedView();
        }

        protected void testTypeSetupGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable aDataTable = new DataTable();
            aDataTable.DefaultView.Sort = e.SortExpression + "Desc";
        }
    }
}