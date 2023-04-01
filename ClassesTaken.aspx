<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassesTaken.aspx.cs" Inherits="Virtual_Advisor.ClassesTaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Virtual Advisor - Create Account</title>
    <link rel="stylesheet" href="Style.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script type="text/javascript">
    $(function() {
        // Trigger the SelectedIndexChanged event when the user selects an item from the drop-down list
        $("#<%=ddlMajorMinor.ClientID%>").change(function() {
            __doPostBack("<%=ddlMajorMinor.UniqueID%>", "");
        });
    });
    </script>
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

        <asp:DropDownList ID="ddlMajorMinor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajorMinor_SelectedIndexChanged" AppendDataBoundItems="True"></asp:DropDownList>
        <asp:GridView ID="gvClassesTaken" runat="server"></asp:GridView>

    </form>
</body>
</html>
