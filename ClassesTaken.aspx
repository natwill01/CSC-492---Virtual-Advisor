<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassesTaken.aspx.cs" Inherits="Virtual_Advisor.ClassesTaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Virtual Advisor - Create Account</title>
    <link rel="stylesheet" href="Style.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.min.js"></script>

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
            
        <div class="selectClasses">
            <asp:RadioButtonList ID="rbTabs" runat="server" OnSelectedIndexChanged="rbTabs_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="1">Select Classes for Your Major(s)</asp:ListItem>
                <asp:ListItem Value="2">Select Classes for Your Minor(s)</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False"></asp:DropDownList>
            <asp:GridView ID="gvMajorClassesTaken" runat="server" OnSelectedIndexChanged="gvMajorClassesTaken_SelectedIndexChanged"></asp:GridView>
        </div>
            
        <div>
            <asp:DropDownList ID="ddlMinor" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlMinor_SelectedIndexChanged" Visible="False"></asp:DropDownList>
            <asp:GridView ID="gvMinorClassesTaken" runat="server" OnSelectedIndexChanged="gvMinorClassesTaken_SelectedIndexChanged"></asp:GridView>
        </div>
    </form>
</body>
</html>
