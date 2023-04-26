<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GPA.aspx.cs" Inherits="Virtual_Advisor.GPA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Virtual Advisor - GPA Calculator</title>
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

        <asp:Label ID="lblDisplay" runat="server" Text="" EnableViewState="False"></asp:Label>
        <asp:Button ID="btnCalcGPA" runat="server" Text="Button" OnClick="btnCalcGPA_Click" />

    </form>
</body>
</html>
