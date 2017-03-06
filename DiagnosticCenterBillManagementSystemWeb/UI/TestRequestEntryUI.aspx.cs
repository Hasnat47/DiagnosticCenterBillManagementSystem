using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemWeb.BLL;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DiagnosticCenterBillManagementSystemWeb.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        TestRequestManager aTestRequestManager = new TestRequestManager();
        TestSetupManager aTestSetupManager = new TestSetupManager();
        List<TestRequest> aTestRequestList = new List<TestRequest>();
        private decimal total = 0;
        TestRequest aTestRequest = new TestRequest();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selectTestDropDownBox.DataSource = aTestSetupManager.ShowAllTestSetups();
                selectTestDropDownBox.DataTextField = "TestName";
                selectTestDropDownBox.DataValueField = "TestName";
                selectTestDropDownBox.DataBind();
            }
        }

        protected void selectTestDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            feeTextBox.Text = aTestRequestManager.FindFee(selectTestDropDownBox.Text);
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            TestRequest aTestRequest=new TestRequest();
            aTestRequest.TestName = selectTestDropDownBox.Text;
            aTestRequest.Date = DateTime.Now.ToString("yyyy-MM-dd");
            aTestRequest.Fee = Convert.ToDecimal(feeTextBox.Text);

            total = Convert.ToDecimal(ViewState["Total"]);
            total += Convert.ToDecimal(feeTextBox.Text);
            ViewState["Total"] = total;

            if (ViewState["Names"] == null)
            {
                aTestRequestList = new List<TestRequest>();

                aTestRequestList.Add(aTestRequest);

                ViewState["Names"] = aTestRequestList;
            }
            else
            {
                aTestRequestList = (List<TestRequest>)ViewState["Names"];
                aTestRequestList.Add(aTestRequest);
                ViewState["Names"] = aTestRequestList;

            }
            testRequestEntryGridView.DataSource = aTestRequestList;
            testRequestEntryGridView.DataBind();
            testRequestTotalTextBox.Text = total.ToString();
            messageLabel.Text = testRequestEntryGridView.Rows[0].Cells[0].Text;


        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            aTestRequest.Name = patientNameTextBox.Text;
            aTestRequest.Date = DateTime.Now.ToString("yyyy-MM-dd");
            aTestRequest.Birthdate = dateOfBirthTextBox.Text;
            aTestRequest.Mobile = mobileNoTextBox.Text;
            aTestRequest.PaymentStatus = "Unpaid";
            aTestRequest.TotalAmount = Convert.ToDecimal( ViewState["Total"]);

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long ms = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
            aTestRequest.BillNo = ms.ToString();

            aTestRequestList = (List<TestRequest>)ViewState["Names"];

            messageLabel.Text = aTestRequestManager.SavePatientHistory(aTestRequest);
            foreach (TestRequest testRequest in aTestRequestList)
            {
                aTestRequestManager.SaveRecord(testRequest.TestName, ms, aTestRequest.Date);
            }

            if (messageLabel.Text != "Mobile is Exists")
            {
                GetBillPDF();
            }

            patientNameTextBox.Text = "";
            dateOfBirthTextBox.Text = "";
            mobileNoTextBox.Text = "";
            testRequestTotalTextBox.Text = "";
            feeTextBox.Text = "";
            testRequestEntryGridView.DataSource = null;
            testRequestEntryGridView.DataBind();
        }

        private void GetBillPDF()
        {
            int yPoint = 0;

            decimal total = 0;
            total = (decimal)ViewState["Total"];
            aTestRequestList = (List<TestRequest>)ViewState["Names"];


            PdfDocument pdf = new PdfDocument();

            pdf.Info.Title = "Patient bill information";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont font = new XFont("Verdana", 15, XFontStyle.Underline);
            graph.DrawString("Batch C#30", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            yPoint += 40;
            graph.DrawString("Patient Bill", font, XBrushes.Black, new XRect(25, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            yPoint = yPoint + 50;

            font = new XFont("Verdana", 12, XFontStyle.Bold);
            graph.DrawString("Name: " + aTestRequest.Name, font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
            graph.DrawString("Date Of Birth: " + aTestRequest.Birthdate, font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
            graph.DrawString("Mobile: " + aTestRequest.Mobile, font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
            graph.DrawString("Test Name", font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            graph.DrawString("Fee", font, XBrushes.Black, new XRect(100, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            yPoint += 40;

            font = new XFont("Verdana", 10, XFontStyle.Italic);


            foreach (TestRequest billList in aTestRequestList)
            {
                graph.DrawString(billList.TestName, font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                graph.DrawString(billList.Fee.ToString(), font, XBrushes.Black, new XRect(100, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                yPoint += 40;
            }
            graph.DrawString("Total", font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString(total.ToString(), font, XBrushes.Black, new XRect(100, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            string pdfFileName = aTestRequest.BillNo + ".pdf";

            bool exists = System.IO.Directory.Exists("C:/Bill");

            if (!exists)
                System.IO.Directory.CreateDirectory("C:/Bill");

            pdf.Save("C:/Bill/" + pdfFileName);
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = "C:/Bill",
                UseShellExecute = true,
                Verb = "open"
            });
        }

    }
}