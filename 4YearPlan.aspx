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

            <asp:DropDownList ID="ddlPlan" runat="server" DataSourceID="sdsPlan" DataTextField="Major_Minor" DataValueField="Major_Minor" AppendDataBoundItems="True"></asp:DropDownList>

            <asp:SqlDataSource runat="server" ID="sdsPlan" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' 
                SelectCommand="SELECT [Major_Minor]
                                FROM (
                                  SELECT DISTINCT [Major_Minor]
                                  FROM [Requirements]
                                ) AS subquery
                                WHERE [Major_Minor] LIKE '%Major%'
                                ORDER BY
                                  [Major_Minor]

                                UNION

                                SELECT '---------------'

                                UNION

                                SELECT [Major_Minor]
                                FROM (
                                  SELECT DISTINCT [Major_Minor]
                                  FROM [Requirements]
                                ) AS subquery
                                WHERE [Major_Minor] LIKE '%Minor%'
                                ORDER BY
                                  [Major_Minor]"></asp:SqlDataSource>
            
            <asp:GridView ID="gvPlan" runat="server" AutoGenerateColumns="False" DataSourceID="sdsVirtualAdvisor">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"></asp:BoundField>
                    <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
                    <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                    <asp:BoundField DataField="Prereq" HeaderText="Prereq" SortExpression="Prereq"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="sdsVirtualAdvisor" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' SelectCommand="SELECT [Code], [Credits], [Descrip], [Prereq] FROM [Requirements] WHERE ([Major_Minor] = @Major_Minor)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlPlan" PropertyName="SelectedValue" Name="Major_Minor" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>

        </form>
    </body>

</html>
