<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Virtual_Advisor.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Virtual Advisor - Login</title>
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

            <asp:SqlDataSource ID="sdsLogin" runat="server" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' SelectCommand="SELECT * FROM [StudentInfo]"></asp:SqlDataSource>

            <div class="loginWrapper">
                <br /><br />
                <h3>Please Login to View Your Personalized Plan:</h3>
                <br /><br />
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
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                
                <div class="centeredButton">
                    <asp:Label ID="lblStatus" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </div>
                <br /><br />
                <p class="centeredTextNoHover">
                    <a href="CreateAccount.aspx">Create A New Account</a>
                </p>
                <br />
                <p class="centeredTextNoHover">
                    <a href="ForgotPassword.aspx">Forgot Password?</a>
                </p>
                <br />
            </div>

        </form>
    </body>
</html>
