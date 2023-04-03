<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassesTaken.aspx.cs" Inherits="Virtual_Advisor.ClassesTaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Virtual Advisor - Create Account</title>
    <link rel="stylesheet" href="Style.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <script type="text/javascript">
        const tabs = document.querySelectorAll('.accordion-tab-header');
        tabs.forEach(tab => {
            tab.addEventListener('click', () => {
                tab.parentElement.classList.toggle('active');
            });
        });
    </script>

    <script type="text/javascript">
    $(function() {
        // Trigger the SelectedIndexChanged event when the user selects an item from the drop-down list
        $("#<%=ddlMajor.ClientID%>").change(function() {
            __doPostBack("<%=ddlMajor.UniqueID%>", "");
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

        <div class="accordion">
            
            <div class="accordion-tab">
                <div class="accordion-tab-header">Majors</div>
                
                <div class="accordion-tab-content">
                    <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" AppendDataBoundItems="True"></asp:DropDownList>
                    <asp:GridView ID="gvMajorClassesTaken" runat="server"></asp:GridView>
                </div>

            </div>
            
            <div class="accordion-tab">
                <div class="accordion-tab-header">Minors</div>
                
                <div class="accordion-tab-content">
                    <asp:DropDownList ID="ddlMinor" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlMinor_SelectedIndexChanged"></asp:DropDownList>
                    <asp:GridView ID="gvMinorClassesTaken" runat="server"></asp:GridView>
                </div>

            </div>
        
        </div>
    </form>
</body>
</html>
