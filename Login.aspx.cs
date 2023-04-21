using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class Login : System.Web.UI.Page
    {
        private DataView dView;
        private DataRowView dRowView;
        string username;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                sdsLogin.SelectCommand = "SELECT Username, Password FROM StudentInfo WHERE Username = @username AND Password = @password";
                sdsLogin.SelectParameters.Add("username", txtUserName.Text);
                sdsLogin.SelectParameters.Add("password", txtPassword.Text);
                dView = (DataView)sdsLogin.Select(DataSourceSelectArguments.Empty);
                if (dView.Count > 0)
                {
                    dRowView = dView[0];

                    username = (string)dRowView["Username"];

                    password = (string)dRowView["Password"];

                    Session["Username"] = username;

                    Session["Password"] = password;

                    Response.Redirect("ClassesTaken.aspx");
                }
                else
                {
                    lblStatus.Text = "Invalid User Name or Password.";
                }
            }
            else
            {
                lblStatus.Text = "Please enter both a User Name and a Password.";
            }
        }
    }
}