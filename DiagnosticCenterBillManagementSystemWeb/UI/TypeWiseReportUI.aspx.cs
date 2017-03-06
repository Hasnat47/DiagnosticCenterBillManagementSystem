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
    public partial class TypeWiseReportUI : System.Web.UI.Page
    {
        TypeWiseReportManager aTypeWiseReportManager = new TypeWiseReportManager();
        List<TestWiseReport> aTestWiseReportList = new List<TestWiseReport>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            aTestWiseReportList = aTypeWiseReportManager.ShowReport(fromDateTextBox.Text, toDateTextBox.Text);
            if (aTestWiseReportList.Count != 0)
            {
                typeWiseGridView.DataSource = aTestWiseReportList;
                typeWiseGridView.DataBind();

            }
            else
            {
                messageLabel.Text = "No data Found";
            }


            decimal total = 0;
            foreach (TestWiseReport report in aTestWiseReportList)
            {
                total += report.TotalFee;
            }
            totalTextBox.Text = total.ToString();
            ViewState["Type"] = aTestWiseReportList;
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


            aTestWiseReportList = (List<TestWiseReport>)ViewState["Type"];


            PdfDocument pdf = new PdfDocument();

            pdf.Info.Title = "Type Wise Report";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont font = new XFont("Verdana", 15, XFontStyle.Underline);
            graph.DrawString("Batch C#30", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            yPoint += 40;
            graph.DrawString("Type Wise Report", font, XBrushes.Black, new XRect(25, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            yPoint = yPoint + 50;

            graph.DrawString("Sl", font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Total Test", font, XBrushes.Black, new XRect(290, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Test Name", font, XBrushes.Black, new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Total Amount", font, XBrushes.Black, new XRect(400, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;

            font = new XFont("Verdana", 10, XFontStyle.Italic);

            int i = 1;


            foreach (TestWiseReport billList in aTestWiseReportList)
            {
                graph.DrawString(i++.ToString(), font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.Name, font, XBrushes.Black, new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.TotalTest.ToString(), font, XBrushes.Black, new XRect(290, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.TotalFee.ToString(), font, XBrushes.Black, new XRect(400, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint += 40;
            }
            graph.DrawString("Total", font, XBrushes.Black, new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(total.ToString(), font, XBrushes.Black, new XRect(400, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);





            string filename = DateTime.Now.ToString("yymmddhhmmss");

            string pdfFileName = "type" + filename + ".pdf";
            messageLabel.Text = pdfFileName;
            bool exists = System.IO.Directory.Exists("C:/type");

            if (!exists)
                System.IO.Directory.CreateDirectory("C:/type");


            pdf.Save("C:/type/" + pdfFileName);
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = "C:/type",
                UseShellExecute = true,
                Verb = "open"
            });



        }

        protected void typewiseHomeImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }

    }
}