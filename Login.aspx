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

            <div class="loginWrapper">
                <br /><br />
                <h3>Please Login to View Your Personalized Plan:</h3>
                <br />
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
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="centeredButton" />
                <br /><br />
            </div>

        </form>
    </body>
</html>
