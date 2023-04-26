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

        private ArrayList gradesList = new ArrayList();

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
                            string gradeStr = reader.GetString(0); // Retrieve the string value.
                            int grade = int.Parse(gradeStr); // Parse the string to an integer.
                            gradesList.Add(grade);
                        }
                    }
                }
            }
        }

        protected void btnCalcGPA_Click(object sender, EventArgs e)
        {
            int num_grades = gradesList.Count;
            double gpa = 0;

            for (int i = 0; i < num_grades; i++)
            {
                switch (gradesList[i])
                {
                    case "A+":
                        gpa += 4.0;
                        break;
                    case "A":
                        gpa += 4.0;
                        break;
                    case "A-":
                        gpa += 3.7;
                        break;
                    case "B+":
                        gpa += 3.3;
                        break;
                    case "B":
                        gpa += 3.0;
                        break;
                    case "B-":
                        gpa += 2.7;
                        break;
                    case "C+":
                        gpa += 2.3;
                        break;
                    case "C":
                        gpa += 2.0;
                        break;
                    case "C-":
                        gpa += 1.7;
                        break;
                    case "D+":
                        gpa += 1.3;
                        break;
                    case "D":
                        gpa += 1.0;
                        break;
                    case "F":
                        gpa += 0.0;
                        break;
                    default:
                        break;

                }
            }

            gpa /= num_grades;

            lblDisplay.Text = gpa.ToString();
            lblDisplay.EnableViewState = true;
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}