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
        private SqlDataReader dr;
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
                if(gradYear.Length > 2)
                {
                    conn = new SqlConnection(getConnectionString());
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO StudentInfo VALUES ('@FirstName', '@LastName', '@Username', '@Password', @GradYear)";
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@GradYear", gradYear);
                    conn.Open();

                    try
                    {
                        numRowsAffected = cmd.ExecuteNonQuery();
                        if(numRowsAffected == 1)
                        {
                            //Accout has been created
                            //Add Yes or No button to take to personalized plan Classes Taken Page
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
    }
}