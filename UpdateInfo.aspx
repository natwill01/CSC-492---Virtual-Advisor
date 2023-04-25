<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateInfo.aspx.cs" Inherits="Virtual_Advisor.UpdateInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Virtual Advisor - Update Information</title>
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

        <asp:GridView ID="gvUpdateGrade" runat="server" AutoGenerateColumns="False" DataSourceID="sdsGradeUpdate" OnRowUpdating="gvUpdateGrade_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Code_CT" HeaderText="Code_CT" SortExpression="Code_CT" ReadOnly="True" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                <asp:CommandField ShowEditButton="True" ButtonType="Button" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="sdsGradeUpdate" runat="server" ConnectionString="<%$ ConnectionStrings:VirtualAdvisorConnectionString %>" 
            SelectCommand="SELECT ClassesTaken.Code_CT, ClassesTaken.Grade FROM ClassesTaken INNER JOIN Student_ClassesTaken ON ClassesTaken.Course_ID = Student_ClassesTaken.Course_ID" 
            UpdateCommand="UPDATE ClassesTaken SET Grade = @Grade FROM ClassesTaken INNER JOIN Student_ClassesTaken ON ClassesTaken.Course_ID = Student_ClassesTaken.Course_ID WHERE Student_ClassesTaken.Username = @Username AND ClassesTaken.Code_CT = CourseCode">
            <UpdateParameters>
                <asp:ControlParameter ControlID="gvUpdateGrade" Name="Grade" PropertyName="Text" />
                <asp:SessionParameter Name="Username" SessionField="Username" />
                <asp:ControlParameter ControlID="gvUpdateGrade" Name="CourseCode" PropertyName="Text" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>
</body>
</html>
