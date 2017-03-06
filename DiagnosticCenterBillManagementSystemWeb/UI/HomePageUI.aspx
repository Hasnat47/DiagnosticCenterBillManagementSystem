<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemWeb.UI.HomePageUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            height: 447px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Font-Bold="False" Font-Names="Algerian" GroupingText="Home Page" Height="469px">
            <div class="auto-style2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Algerian" Text="Diagnostic Center Bill Management System"></asp:Label>
                <br />
                <br/>
                <br/>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TestTypeSetupUI.aspx">Test Type Setup</asp:HyperLink>
                <br />
                <br/>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UI/TestSetupUI.aspx">Test Setup</asp:HyperLink>
                <br />
                <br/>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/UI/TestRequestEntryUI.aspx">Test Request Entry</asp:HyperLink>
                <br />
                <br/>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/UI/PaymentUI.aspx">Payment</asp:HyperLink>
                <br />
                <br/>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/UI/TestWiseReportUI.aspx">Test Wise Report</asp:HyperLink>
                <br />
                <br/>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/UI/TypeWiseReportUI.aspx">Type Wise Report</asp:HyperLink>
                <br />
                <br/>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/UI/UnpaidBillReportUI.aspx">Unpaid Bill Report</asp:HyperLink>
                <br />
                <br />
                <br />
            </div>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
