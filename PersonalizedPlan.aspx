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
            <asp:GridView ID="gvRequiredPersonalizedPlan" runat="server" DataSourceID="sdsRequiredPersonalizedPlan"></asp:GridView>
            
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
                                  AND sct.Username = 'nswims' 
                                WHERE ct.Code_CT IS NULL 
                                  AND sct.Username IS NULL
                                AND r.Major_Minor = 'CS Major'
                                AND r.Optional = 0">
            </asp:SqlDataSource>

            <asp:GridView ID="gvOptionalPersonalizedPlan" runat="server" DataSourceID="sdsOptionalPersonalizedPlan"></asp:GridView>

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
                                  AND sct.Username = 'nswims' 
                                WHERE ct.Code_CT IS NULL 
                                  AND sct.Username IS NULL
                                AND r.Major_Minor = 'CS Major'
                                AND r.Optional = 1">
            </asp:SqlDataSource>
        </div>
      
    </form>
</body>
</html>
