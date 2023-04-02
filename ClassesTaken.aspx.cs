using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Runtime.Remoting.Messaging;

namespace Virtual_Advisor
{
    public partial class ClassesTaken : System.Web.UI.Page
    {
        private SqlConnection conn1;
        private SqlCommand cmd1;
        private SqlDataReader reader1;

        private SqlConnection conn2;
        private SqlCommand cmd2;
        private SqlDataReader reader2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMajor.Items.Insert(0, new ListItem("Select Major", "-1"));
                ddlMinor.Items.Insert(0, new ListItem("Select Minor", "-1"));

                conn1 = new SqlConnection(getConnectionString());
                cmd1 = new SqlCommand();
                cmd1.Connection = conn1;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Major%'";
                conn1.Open();

                reader1 = cmd1.ExecuteReader();
                ddlMajor.DataSource = reader1;
                ddlMajor.DataTextField = "Major_Minor";
                ddlMajor.DataValueField = "Major_Minor";
                ddlMajor.DataBind();
                conn1.Close();

                //***************************************************************************************//

                conn2 = new SqlConnection(getConnectionString());
                cmd2 = new SqlCommand();
                cmd2.Connection = conn2;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Minor%'";
                conn2.Open();

                reader2 = cmd2.ExecuteReader();
                ddlMinor.DataSource = reader2;
                ddlMinor.DataTextField = "Major_Minor";
                ddlMinor.DataValueField = "Major_Minor";
                ddlMinor.DataBind();
                conn2.Close();
            }
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblStatus.Text = "SelectedIndexChanged event triggered!";

            if (gvMajorClassesTaken != null)
            {
                gvMajorClassesTaken.DataSource = null;
                gvMajorClassesTaken.DataBind();
            }

            String major = Convert.ToString(ddlMajor.SelectedValue);

            conn1 = new SqlConnection(getConnectionString());
            cmd1 = new SqlCommand();
            cmd1.Connection = conn1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT Code, Credits, Descrip FROM [Requirements] WHERE Major_Minor = @Major_Minor";
            cmd1.Parameters.AddWithValue("@Major_Minor", major);
            conn1.Open();

            reader1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader1);
            gvMajorClassesTaken.DataSource = dt;
            gvMajorClassesTaken.DataBind();

            conn1.Close();
        }

        protected void ddlMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvMinorClassesTaken != null)
            {
                gvMinorClassesTaken.DataSource = null;
                gvMinorClassesTaken.DataBind();
            }

            String minor = Convert.ToString(ddlMinor.SelectedValue);

            conn2 = new SqlConnection(getConnectionString());
            cmd2 = new SqlCommand();
            cmd2.Connection = conn2;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT Code, Credits, Descrip FROM [Requirements] WHERE Major_Minor = @Major_Minor";
            cmd2.Parameters.AddWithValue("@Major_Minor", minor);
            conn2.Open();

            reader2 = cmd2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader2);
            gvMinorClassesTaken.DataSource = dt;
            gvMinorClassesTaken.DataBind();

            conn2.Close();
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}