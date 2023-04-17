<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassesTaken.aspx.cs" Inherits="Virtual_Advisor.ClassesTaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Virtual Advisor - Create Account</title>
    <link rel="stylesheet" href="Style.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.min.js"></script>
    
    <%-- 
    <script type="text/javascript">
        $(function() {
            // Trigger the SelectedIndexChanged event when the user selects an item from the drop-down list
            $("#<%=ddlMajor.ClientID%>").change(function() {
                __doPostBack("<%=ddlMajor.UniqueID%>", "");
            });

            $("#<%=ddlMinor.ClientID%>").change(function() {
                __doPostBack("<%=ddlMajor.UniqueID%>", "");
            });
        });
    </script>
    --%>

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

        <asp:ScriptManager ID="smMajorMinor" runat="server"></asp:ScriptManager>
            <
            <div class="selectClasses">
                <asp:RadioButtonList ID="rbTabs" runat="server">
                    <asp:ListItem Value="1">Select Classes for Your Major(s)</asp:ListItem>
                    <asp:ListItem Value="2">Select Classes for Your Minor(s)</asp:ListItem>
                </asp:RadioButtonList>
            </div>

        <asp:UpdatePanel ID="upMajorMinor" runat="server"></asp:UpdatePanel>
            <ContentTemplate>
                <div>
                    <div id="majorDiv" style="display: none;">
                        <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" AppendDataBoundItems="True"></asp:DropDownList>
                        <asp:GridView ID="gvMajorClassesTaken" runat="server" OnSelectedIndexChanged="gvMajorClassesTaken_SelectedIndexChanged"></asp:GridView>
                    </div>
                    <div id="minorDiv" style="display: none;">
                        <asp:DropDownList ID="ddlMinor" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlMinor_SelectedIndexChanged"></asp:DropDownList>
                        <asp:GridView ID="gvMinorClassesTaken" runat="server" OnSelectedIndexChanged="gvMinorClassesTaken_SelectedIndexChanged"></asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                
            </Triggers>

        <script type="text/javascript">
            function rbTabs_SelectedIndexChanged() {
                var majorDiv = document.getElementById('majorDiv');
                var minorDiv = document.getElementById('minorDiv');
                var rbTabs = document.getElementById('<%= rbTabs.ClientID %>');

                if (rbTabs.value == '1') {
                    majorDiv.style.display = 'block';
                    minorDiv.style.display = 'none';
                } else if (rbTabs.value == '2') {
                    majorDiv.style.display = 'none';
                    minorDiv.style.display = 'block';
                }
            }
        </script>

    </form>
</body>
</html>
