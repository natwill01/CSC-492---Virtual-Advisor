using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;

namespace Virtual_Advisor
{
    public partial class GPA : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                ArrayList gradesList = new ArrayList();

                using (SqlConnection connection = new SqlConnection(getConnectionString()))
                {
                    SqlCommand command = new SqlCommand("SELECT Grade FROM ClassesTaken", connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int grade = reader.GetInt32(0);
                            gradesList.Add(grade);
                        }
                    }
                }
            }
        }

        protected void btnCalcGPA_Click(object sender, EventArgs e)
        {

        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}