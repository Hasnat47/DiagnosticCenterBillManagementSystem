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
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        TestWiseReportManager aTestWiseReportManager=new TestWiseReportManager();
        List<TestWiseReport> aTestWiseReportList =new List<TestWiseReport>(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            aTestWiseReportList = aTestWiseReportManager.ShowReport(fromDateTextBox.Text, toDateTextBox.Text);
            ViewState["Test"] = aTestWiseReportList;

            if (aTestWiseReportList.Count != 0)
            {
                 testWiseGridView.DataSource = aTestWiseReportList;
                 testWiseGridView.DataBind();
            }
            else
            {
                messageLabel.Text = "No Data Found";
            }
           

            decimal total = 0;
            foreach (TestWiseReport report in aTestWiseReportList)
            {
                total += report.TotalFee;
            }
            totalTextBox.Text = total.ToString();

        }

        protected void PDFButton_Click(object sender, EventArgs e)
        {
            GetBillPDF();
        }

        private void GetBillPDF()
        {
            int yPoint = 0;

            double total = 0;
            total = Convert.ToDouble(totalTextBox.Text);


            aTestWiseReportList = (List<TestWiseReport>) ViewState["Test"];


            PdfDocument pdf = new PdfDocument();

            pdf.Info.Title = "Patient bill information";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont font = new XFont("Verdana", 15, XFontStyle.Underline);
            graph.DrawString("Batch C#30", font, XBrushes.Black,
                new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            yPoint += 40;
            graph.DrawString("Test Wise Report", font, XBrushes.Black,
                new XRect(25, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            yPoint = yPoint + 50;

            graph.DrawString("SL", font, XBrushes.Black,
                new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Test Name", font, XBrushes.Black,
                new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Total Test", font, XBrushes.Black,
                new XRect(250, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Total Amount", font, XBrushes.Black,
                new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;

            font = new XFont("Verdana", 10, XFontStyle.Italic);

            int i = 1;


            foreach (TestWiseReport billList in aTestWiseReportList)
            {
                graph.DrawString(i++.ToString(), font, XBrushes.Black,
                    new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.Name, font, XBrushes.Black,
                    new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.TotalTest.ToString(), font, XBrushes.Black,
                    new XRect(290, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.TotalFee.ToString(), font, XBrushes.Black,
                    new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint += 40;
            }
            graph.DrawString("Total", font, XBrushes.Black,
                new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(total.ToString(), font, XBrushes.Black,
                new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);







            string filename = DateTime.Now.ToString("yymmddhhmmss");

            string pdfFileName = "test" + filename + ".pdf";

            bool exists = System.IO.Directory.Exists("C:/test");

            if (!exists)
                System.IO.Directory.CreateDirectory("C:/test");



            pdf.Save("C:/test/" + pdfFileName);
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = "C:/test",
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}