<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassesTaken.aspx.cs" Inherits="Virtual_Advisor.ClassesTaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Virtual Advisor - Create Account</title>
    <link rel="stylesheet" href="Style.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.min.js"></script>

    <script type="text/javascript">
        $(function() {
            // Trigger the SelectedIndexChanged event when the user selects an item from the drop-down list
            $("#<%=ddlMajor.ClientID%>").change(function() {
                __doPostBack("<%=ddlMajor.UniqueID%>", "");
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function() {
            // Hide both dropdown list controls initially
            $("#ddlMajor").hide();
            $("#ddlMinor").hide();

            // Show the corresponding dropdown list control when a tab is clicked
            $("#tabs").tabs({
                activate: function(event, ui) {
                    if (ui.newPanel.attr("id") === "tab1") {
                        $("#ddlMajor").show();
                        $("#ddlMinor").hide();
                    }
                    else {
                        $("#ddlMajor").hide();
                        $("#ddlMinor").show();
                    }
                }
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

        <div id="tabs" style="width: 400px">
            <ul>
                <li>
                    <a href="#tab1">Majors</a>
                </li>
                <li>
                    <a href="#tab2">Minors</a>
                </li>
            </ul>
            <div id="tab1">
                <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" AppendDataBoundItems="True"></asp:DropDownList>
                <asp:GridView ID="gvMajorClassesTaken" runat="server"></asp:GridView>
            </div>
            <div id="tab2">
                <asp:DropDownList ID="ddlMinor" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlMinor_SelectedIndexChanged"></asp:DropDownList>
                <asp:GridView ID="gvMinorClassesTaken" runat="server"></asp:GridView>
            </div>
        </div>

    </form>
</body>
</html>
