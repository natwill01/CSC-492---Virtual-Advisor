<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Virtual_Advisor.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Virtual Advisor - Forgot Password?</title>
    <link rel="stylesheet" href="Style.css" />
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

        <div class="loginWrapper">
            <br /><br />
            <h3>Forgot Your Password?</h3>
            <br /><br />
            <asp:SqlDataSource ID="sdsForgotPassword" runat="server" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' SelectCommand="SELECT * FROM [StudentInfo]"></asp:SqlDataSource>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr><td><br /></td><td><br /></td></tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br />
            <div class="centeredButton">
                <asp:Button ID="btnSubmit" runat="server" Text="Button" OnClick="btnSubmit_Click" />
                <br />
                <asp:Label ID="lblStatus" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
            <br />
            <p class="centeredTextNoHover">
                <a href="Login.aspx">Back To Login Page</a>
            </p>
            <br /><br />
        </div>

    </form>
</body>
</html>
