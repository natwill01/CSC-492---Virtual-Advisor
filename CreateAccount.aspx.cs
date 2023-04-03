using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Diagnostics;

namespace Virtual_Advisor
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private int numRowsAffected;

        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string gradYear;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            username = txtUserName.Text;
            password = txtPassword.Text;
            gradYear = txtGradYear.Text;

            if(firstName.Length > 0 && lastName.Length > 0 && username.Length > 0 && password.Length > 0 && gradYear.Length > 0)
            {
                if(gradYear.Length == 2)
                {
                    conn = new SqlConnection(getConnectionString());
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO StudentInfo VALUES (@FirstName, @LastName, @Username, @Password, @GradYear)";
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = lastName;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30).Value = password;
                    cmd.Parameters.AddWithValue("@GradYear", gradYear);
                    conn.Open();

                    try
                    {
                        numRowsAffected = cmd.ExecuteNonQuery();
                        if(numRowsAffected == 1)
                        {
                            Session["Username"] = username;
                            Session["Password"] = password;

                            lblStatus.Text = "Account Created, thanks for joining!";
                            pnlInformation.Visible = true;

                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            txtUserName.Text = "";
                            txtPassword.Text = "";
                            txtGradYear.Text = "";
                        }
                        else
                        {
                            lblStatus.Text = "Account Not Added.";
                        }
                    }
                    catch
                    {
                        lblStatus.Text = "Account not created. This username has been used already.";
                    }
                    conn.Close();
                }
                else
                {
                    lblStatus.Text = "Please only enter two numbers representing your graduation year.";
                }
            }
            else
            {
                lblStatus.Text = "Please enter information in all boxes to create an account.";
            }
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Server.Transfer("ClassesTaken.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }
    }
}