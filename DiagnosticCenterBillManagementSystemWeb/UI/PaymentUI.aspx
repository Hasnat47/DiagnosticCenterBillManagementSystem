<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemWeb.UI.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="Payment" Height="318px">
            <asp:Label ID="Label1" runat="server" Text="Bill No"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="billNoTextBox" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label5" runat="server" Text="Or"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Mobile No"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="paymentSearchButton" runat="server" Text="Search" OnClick="paymentSearchButton_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Due Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="duedateTextBox" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="paymentButton" runat="server" Text="Pay" OnClick="paymentButton_Click" />
            <br />
            <asp:Label ID="messageLabel" runat="server" Text="Message"></asp:Label>
            <br />
            <asp:HiddenField ID="messageHiddenTextField" runat="server" />
            
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/HomePageUI.aspx">Home</asp:HyperLink>
            
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
