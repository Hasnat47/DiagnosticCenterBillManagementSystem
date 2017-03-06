using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemWeb.BLL;
using DiagnosticCenterBillManagementSystemWeb.DAL.Model;
//using iTextSharp.text.pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DiagnosticCenterBillManagementSystemWeb.UI
{
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {
        UnpaidBillReportManager aUnpaidBillReportManager = new UnpaidBillReportManager();
        List<UnpaidBillReport> aUnpaidBillReportList = new List<UnpaidBillReport>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            aUnpaidBillReportList = aUnpaidBillReportManager.ShowAllUnpaid(fromDateTextBox.Text, toDateTextBox.Text);

            if (aUnpaidBillReportList.Count != 0)
            {
                unpaidBillGridView.DataSource = aUnpaidBillReportList;
                unpaidBillGridView.DataBind();
            }
            else
            {
                messageLabel.Text = "No Data Found";
            }
            decimal total = 0;

            foreach (UnpaidBillReport report in aUnpaidBillReportList)
            {
                total += report.BillAmount;
            }
            totalTextBox.Text = total.ToString();
            ViewState["unpaid"] = aUnpaidBillReportList;
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


            aUnpaidBillReportList = (List<UnpaidBillReport>)ViewState["unpaid"];


            PdfDocument pdf = new PdfDocument();


            pdf.Info.Title = "Patient bill information";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont font = new XFont("Verdana", 15, XFontStyle.Underline);
            graph.DrawString("Batch C#30", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            yPoint += 40;
            graph.DrawString("Unpaid Patients", font, XBrushes.Black, new XRect(25, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            yPoint = yPoint + 50;

            graph.DrawString("Sl", font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Bill No", font, XBrushes.Black, new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Patient Name", font, XBrushes.Black, new XRect(250, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Mobile", font, XBrushes.Black, new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Fee", font, XBrushes.Black, new XRect(450, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;

            font = new XFont("Verdana", 10, XFontStyle.Italic);

            int i = 1;


            foreach (UnpaidBillReport billList in aUnpaidBillReportList)
            {
                graph.DrawString(i++.ToString(), font, XBrushes.Black, new XRect(10, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.BillNo, font, XBrushes.Black, new XRect(150, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.PatientName, font, XBrushes.Black, new XRect(250, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.MobileNo, font, XBrushes.Black, new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString(billList.BillAmount.ToString(), font, XBrushes.Black, new XRect(450, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint += 40;
            }
            graph.DrawString("Total", font, XBrushes.Black, new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(total.ToString(), font, XBrushes.Black, new XRect(450, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);







            string filename = DateTime.Now.ToString("yymmddhhmmss");

            string pdfFileName = "unpaid" + filename + ".pdf";

            bool exists = System.IO.Directory.Exists("C:/unpaid");

            if (!exists)
                System.IO.Directory.CreateDirectory("C:/unpaid");



            pdf.Save("C:/unpaid/" + pdfFileName);
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = "C:/unpaid",
                UseShellExecute = true,
                Verb = "open"
            });



        }
    }
}