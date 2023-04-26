<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalizedPlan.aspx.cs" Inherits="Virtual_Advisor.PersonalizedPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Virtual Advisor - Personalized Plan</title>
        <link rel="stylesheet" href="Style.css" />
        <link rel="shortcut icon" type="x-icon" href="Images/icon.png" />
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
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

    <div class="ddlContainerPP">
        <asp:DropDownList ID="ddlShowMajors" runat="server" OnSelectedIndexChanged="ddlShowMajors_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" CssClass="ddlCustomizationPP"></asp:DropDownList>
        <asp:DropDownList ID="ddlShowMinors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShowMinors_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="ddlCustomizationPP"></asp:DropDownList>
    </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $('.ddlCustomizationPP').click(function () {
                    $(this).toggleClass('rotate');
                    $(this).toggleClass('arrow-rotate');
                });
            });
        </script>
    <div class="gridPP">
        <asp:GridView ID="gvMajorRequiredPersonalizedPlan" runat="server" DataSourceID="sdsRequiredPersonalizedPlan" Visible="False" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"></asp:BoundField>
                <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sdsRequiredPersonalizedPlan" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' 
            SelectCommand="SELECT r.Code, r.Descrip, r.Credits
                            FROM Requirements r 
                            LEFT JOIN (SELECT DISTINCT Code_CT FROM ClassesTaken) ct 
                                ON r.Code = ct.Code_CT 
                            LEFT JOIN ClassesTaken_Req ctr 
                                ON r.Code = ctr.Code 
                                AND r.Major_Minor = ctr.Major_Minor 
                            LEFT JOIN Student_ClassesTaken sct 
                                ON ctr.Course_ID = sct.Course_ID 
                                AND sct.Username = @Username 
                            WHERE ct.Code_CT IS NULL 
                                AND sct.Username IS NULL
                            AND r.Major_Minor = @MajorMinor
                            AND r.Optional = 0">
            <SelectParameters>
                <asp:SessionParameter SessionField="Username" Name="Username"></asp:SessionParameter>
                <asp:ControlParameter ControlID="ddlShowMajors" PropertyName="SelectedValue" Name="MajorMinor"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
        <asp:GridView ID="gvMajorOptionalPersonalizedPlan" runat="server" DataSourceID="sdsOptionalPersonalizedPlan" Visible="False" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"></asp:BoundField>
                <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsOptionalPersonalizedPlan" runat="server" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' 
            SelectCommand="SELECT r.Code, r.Descrip, r.Credits
                            FROM Requirements r 
                            LEFT JOIN (SELECT DISTINCT Code_CT FROM ClassesTaken) ct 
                                ON r.Code = ct.Code_CT 
                            LEFT JOIN ClassesTaken_Req ctr 
                                ON r.Code = ctr.Code 
                                AND r.Major_Minor = ctr.Major_Minor 
                            LEFT JOIN Student_ClassesTaken sct 
                                ON ctr.Course_ID = sct.Course_ID 
                                AND sct.Username = @Username 
                            WHERE ct.Code_CT IS NULL 
                                AND sct.Username IS NULL
                            AND r.Major_Minor = @MajorMinor
                            AND r.Optional = 1">
            <SelectParameters>
                <asp:SessionParameter SessionField="Username" Name="Username"></asp:SessionParameter>
                <asp:ControlParameter ControlID="ddlShowMajors" PropertyName="SelectedValue" Name="MajorMinor"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="gvMinorRequiredPersonalizedPlan" runat="server" AutoGenerateColumns="False" DataSourceID="sdsRequiredPP" Visible="False">
            <Columns>
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"></asp:BoundField>
                <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsRequiredPP" runat="server" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' 
            SelectCommand="SELECT r.Code, r.Descrip, r.Credits
                            FROM Requirements r 
                            LEFT JOIN (SELECT DISTINCT Code_CT FROM ClassesTaken) ct 
                                ON r.Code = ct.Code_CT 
                            LEFT JOIN ClassesTaken_Req ctr 
                                ON r.Code = ctr.Code 
                                AND r.Major_Minor = ctr.Major_Minor 
                            LEFT JOIN Student_ClassesTaken sct 
                                ON ctr.Course_ID = sct.Course_ID 
                                AND sct.Username = @Username 
                            WHERE ct.Code_CT IS NULL 
                                AND sct.Username IS NULL
                            AND r.Major_Minor = @MajorMinor
                            AND r.Optional = 0">
            <SelectParameters>
                <asp:SessionParameter SessionField="Username" Name="Username"></asp:SessionParameter>
                <asp:ControlParameter ControlID="ddlShowMinors" PropertyName="SelectedValue" Name="MajorMinor"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:GridView ID="gvMinorOptionalPersonalizedPlan" runat="server" DataSourceID="sdsOptionalPP" Visible="False"></asp:GridView>
        <asp:SqlDataSource ID="sdsOptionalPP" runat="server" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' 
            SelectCommand="SELECT r.Code, r.Descrip, r.Credits
                            FROM Requirements r 
                            LEFT JOIN (SELECT DISTINCT Code_CT FROM ClassesTaken) ct 
                                ON r.Code = ct.Code_CT 
                            LEFT JOIN ClassesTaken_Req ctr 
                                ON r.Code = ctr.Code 
                                AND r.Major_Minor = ctr.Major_Minor 
                            LEFT JOIN Student_ClassesTaken sct 
                                ON ctr.Course_ID = sct.Course_ID 
                                AND sct.Username = @Username 
                            WHERE ct.Code_CT IS NULL 
                                AND sct.Username IS NULL
                            AND r.Major_Minor = @MajorMinor
                            AND r.Optional = 1">
            <SelectParameters>
                <asp:SessionParameter SessionField="Username" Name="Username"></asp:SessionParameter>
                <asp:ControlParameter ControlID="ddlShowMinors" PropertyName="SelectedValue" Name="MajorMinor"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>

    </form>
</body>
</html>
