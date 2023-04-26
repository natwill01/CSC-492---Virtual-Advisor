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

        <div class="centeredTextAdmin">
        <h1>Welcome Admin!</h1>
        </div>

        <div class="grid">         
            <asp:GridView ID="gvUpdatePlan" runat="server" OnRowEditing="gvUpdatePlan_RowEditing" OnRowUpdating="gvUpdatePlan_RowUpdating">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button"></asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
