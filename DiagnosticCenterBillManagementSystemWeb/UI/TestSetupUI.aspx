<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemWeb.UI.TestSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="Test Setup" Height="362px" Width="800px">
            <asp:Panel ID="Panel2" runat="server" Height="104px">
                <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Fee"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="testFeeTextBox" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="BDT"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Test Type"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="testTypeDropDownList" runat="server">
                </asp:DropDownList>
                <br />
                &nbsp;<asp:Label ID="messageLabel" runat="server" Text="Message"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="testSetupSaveButton" runat="server" Text="Save" Width="50px" OnClick="testSetupSaveButton_Click" />
                <br />
                <br />
                <br />
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
            <asp:GridView ID="testSetupGridView" runat="server" OnSorting="testSetupGridView_Sorting" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:TemplateField HeaderText="SL#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TestName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Type">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("TestTypeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
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
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
