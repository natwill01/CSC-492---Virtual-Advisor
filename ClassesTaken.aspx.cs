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

namespace Virtual_Advisor
{
    public partial class ClassesTaken : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMajorMinor.Items.Insert(0, new ListItem("Select Major", "-1"));

                conn = new SqlConnection(getConnectionString());
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements]";
                conn.Open();

                reader = cmd.ExecuteReader();
                ddlMajorMinor.DataSource = reader;
                ddlMajorMinor.DataTextField = "Major_Minor";
                ddlMajorMinor.DataValueField = "Major_Minor";
                ddlMajorMinor.DataBind();
                conn.Close();
            }
        }

        protected void ddlMajorMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblStatus.Text = "SelectedIndexChanged event triggered!";

            if (gvClassesTaken != null)
            {
                gvClassesTaken.DataSource = null;
                gvClassesTaken.DataBind();
            }

            String majorMinor = Convert.ToString(ddlMajorMinor.SelectedValue);

            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Code, Credits, Descrip FROM [Requirements] WHERE Major_Minor = @Major_Minor";
            cmd.Parameters.AddWithValue("@Major_Minor", majorMinor);
            conn.Open();

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            gvClassesTaken.DataSource = dt;
            gvClassesTaken.DataBind();

            conn.Close();
        }
        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}