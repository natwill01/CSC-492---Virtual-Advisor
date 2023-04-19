<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassesTaken.aspx.cs" Inherits="Virtual_Advisor.ClassesTaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <title>Virtual Advisor - Create Account</title>
    <link rel="stylesheet" href="Style.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.min.js"></script>

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
            
        <div class="selectClasses">
            <asp:RadioButtonList ID="rbTabs" runat="server" OnSelectedIndexChanged="rbTabs_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="1">Select Classes for Your Major(s)</asp:ListItem>
                <asp:ListItem Value="2">Select Classes for Your Minor(s)</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False"></asp:DropDownList>
            <asp:GridView ID="gvMajorClassesTaken" runat="server" DataSourceID="sdsMajorClassesTaken" Visible="False" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbMajorSelected" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                    <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
                    <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip" />
                    <asp:TemplateField HeaderText="Grade">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMajorGrade" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sdsMajorClassesTaken" runat="server" ConnectionString="<%$ ConnectionStrings:VirtualAdvisorConnectionString %>" SelectCommand="SELECT [Code], [Credits], [Descrip] FROM [Requirements] WHERE ([Major_Minor] LIKE '%' + @Major_Minor + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlMajor" Name="Major_Minor" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="btnMajorAddClasses" runat="server" Text="Add Classes" Visible="False" OnClick="btnMajorAddClasses_Click" />
        </div>
            
        <div>
            <asp:DropDownList ID="ddlMinor" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlMinor_SelectedIndexChanged" Visible="False"></asp:DropDownList>
            <asp:GridView ID="gvMinorClassesTaken" runat="server" AutoGenerateColumns="False" DataSourceID="sdsMinorClassesTaken" Visible="False">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbMinorSelected" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code"></asp:BoundField>
                    <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits"></asp:BoundField>
                    <asp:BoundField DataField="Descrip" HeaderText="Descrip" SortExpression="Descrip"></asp:BoundField>
                    <asp:TemplateField HeaderText="Grade">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMinorGrade" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="sdsMinorClassesTaken" ConnectionString='<%$ ConnectionStrings:VirtualAdvisorConnectionString %>' SelectCommand="SELECT [Code], [Credits], [Descrip] FROM [Requirements] WHERE ([Major_Minor] LIKE '%' + @Major_Minor + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlMinor" PropertyName="SelectedValue" Name="Major_Minor" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="btnMinorAddClasses" runat="server" Text="Add Classes" OnClick="btnMinorAddClasses_Click" Visible="False" />
        </div>
    </form>
</body>
</html>
