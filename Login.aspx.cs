using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
            string sqlChecks = "'\";\\-%<>|&()[]{}\0\n";
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                if (sqlChecks.Any(c => txtUserName.Text.Contains(c)) && sqlChecks.Any(c => txtPassword.Text.Contains(c)))
                {
                    lblStatus.Text = "Please enter only valid characters.";
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(getConnectionString()))
                    {
                        SqlCommand command = new SqlCommand("SELECT Username, Password FROM StudentInfo WHERE Username = @username AND Password = @password", connection);
                        command.Parameters.AddWithValue("username", txtUserName.Text);
                        command.Parameters.AddWithValue("password", txtPassword.Text);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            username = reader.GetString(0);
                            password = reader.GetString(1);
                            Session["Username"] = username;
                            Session["Password"] = password;

                            if ((string)Session["Username"] == "cindricbb")
                            {
                                Response.Redirect("Admin.aspx");
                            }
                            else
                            {
                                Response.Redirect("PersonalizedPlan.aspx");
                            }
                            
                        }
                        else
                        {
                            lblStatus.Text = "Invalid User Name or Password.";
                        }
                    }
                }
            }
            else
            {
                lblStatus.Text = "Please enter both a User Name and a Password.";
            }
        }
        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}