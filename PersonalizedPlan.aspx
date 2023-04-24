<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalizedPlan.aspx.cs" Inherits="Virtual_Advisor.PersonalizedPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Virtual Advisor - Personalized Plan</title>
        <link rel="stylesheet" href="Style.css" />
    </head>

<body>
    <form id="form1" runat="server">
         <div class="homepageLogo"></div>
         <div class="gradient"></div>
         
         <ul class="homepageNav">
             <li>
                 <a href="UpdateInfo.aspx">Update Your Information</a>
             </li>
            <li>
                <a href="Default.aspx">Homepage</a>
            </li>
         </ul>

        <div>
            <asp:DropDownList ID="DDLPP_Major" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DDLPP_Major_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="DDLPP_Minor" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DDLPP_Minor_SelectedIndexChanged"></asp:DropDownList>
            <asp:GridView ID="GVPP" runat="server"></asp:GridView>

        </div>
      
    </form>
</body>
</html>
