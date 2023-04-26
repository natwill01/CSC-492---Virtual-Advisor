using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sqlChecks = "'\";\\-%<>|&()[]{}'\0\n";
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                if (sqlChecks.Any(c => txtUserName.Text.Contains(c)) || sqlChecks.Any(c => txtPassword.Text.Contains(c)))
                {
                    lblStatus.Text = "Please enter only valid characters.";
                }
                else
                {
                    sdsForgotPassword.UpdateCommand = "UPDATE StudentInfo SET Password = @Password WHERE Username = @Username";
                    sdsForgotPassword.UpdateParameters.Clear();
                    sdsForgotPassword.UpdateParameters.Add("Password", txtPassword.Text);
                    sdsForgotPassword.UpdateParameters.Add("Username", txtUserName.Text);
                    if (sdsForgotPassword.Update() > 0)
                    {
                        Session["Username"] = txtUserName.Text;
                        Session["Password"] = txtPassword.Text;
                        lblStatus.Text = "Password has been updated.";

                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        lblStatus.Text = "Password has not been updated. Please try again.";
                    }
                }
            }
            else
            {
                lblStatus.Text = "Please enter a username and a new password.";
            }
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}