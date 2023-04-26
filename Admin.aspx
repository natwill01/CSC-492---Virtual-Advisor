<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Virtual_Advisor.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Virtual Advisor - Admin</title>
    <link rel="stylesheet" href="Style.css" />
    <link rel="shortcut icon" type="x-icon" href="Images/icon.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="homepageLogo"></div>
            <div class="gradient"></div>

            <ul class="homepageNav">
                <li>
                    <a href="Default.aspx">Homepage</a>
                </li>
            </ul>

        <asp:GridView ID="gvUpdatePlan" runat="server" AutoGenerateColumns="False" DataKeyNames="Major_Minor,Code" DataSourceID="sdsUpdatePlan" OnRowUpdating="gvUpdatePlan_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Major_Minor" HeaderText="Major_Minor" SortExpression="Major_Minor"></asp:BoundField>
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"></asp:BoundField>
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
                <asp:BoundField DataField="Optional" HeaderText="Optional" SortExpression="Optional"></asp:BoundField>
                <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                <asp:BoundField DataField="Prereq" HeaderText="Prereq" SortExpression="Prereq"></asp:BoundField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sdsUpdatePlan" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' 
            SelectCommand="SELECT * FROM [Requirements]" 
            UpdateCommand="UPDATE Requirements SET Major_Minor = @MajorMinor, Code = @Code, Credits = @Credits, Optional = @Optional, Descrip = @Descrip, Prereq = @Prereq">
            <UpdateParameters>
                <asp:Parameter Name="MajorMinor" Type="String" />
                <asp:Parameter Name="Code" Type="String" />
                <asp:Parameter Name="Credits" Type="Int32" />
                <asp:Parameter Name="Optional" Type="Int32" />
                <asp:Parameter Name="Descrip" Type="String" />
                <asp:Parameter Name="Prereq" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
