<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Virtual_Advisor.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Virtual Advisor</title>
    <link rel="stylesheet" href="Style.css" />
</head>

<body>
    <form id="form" runat="server">
        <div class="gradient"></div>
        <div>
            <ul class="homepageNav">
                <li>
                    <a href="Wiki.aspx">Our Blog</a>
                </li>
                <li>
                    <a href="Login.aspx">Login</a>
                </li>
            </ul>
        </div>

        <div class="homepageText">
            <h1>Virtual Advisor</h1>
        </div>

        <table class="centeredTable">
            <tr>
                <td>
                    <div class="separatedView">
                        <h3>Computer Science General 4-year Plans</h3>
                        <p>Click the button below to view the 4-year plans for the Computer Science Program.</p>
                        <a href="4YearPlan.aspx">4-year Plans</a>
                    </div>
                </td>
                <td>
                    <div class="separatedView">
                        <h3>Personalized Plan</h3>
                        <p>Click the button below to view your personalized plan. Make sure you create an account
                           first and input the correct information.</p>
                        <a href="PersonalizedPlan.aspx">Personalized Plan</a>
                    </div>
                </td>
                <td>
                    <div class="separatedView">
                        <h3>Computer Science GPA Calculator</h3>
                        <p>Click the button below to view your GPA for the Computer Science Program.</p>
                        <a href="GPA.aspx">GPA Calculator</a>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>

</html>
