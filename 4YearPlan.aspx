<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4YearPlan.aspx.cs" Inherits="Virtual_Advisor._4YearPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Virtual Advisory - 4 Year Plan</title>
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

            <div>
                <asp:GridView ID="gvPlan" runat="server" AutoGenerateColumns="False" DataKeyNames="Major_Minor,Code" DataSourceID="sdsVirtualAdvisor">
                    <Columns>
                        <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code"></asp:BoundField>
                        <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
                        <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                        <asp:BoundField DataField="Prereq" HeaderText="Prereq" SortExpression="Prereq"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sdsVirtualAdvisor" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' SelectCommand="SELECT * FROM [Requirements] ORDER BY [Code]"></asp:SqlDataSource>
            </div>

        </form>
    </body>

</html>
