using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class PersonalizedPlan : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private int numRowsAffected;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ddlShowMajors.Items.Insert(0, new ListItem("Select What Major Plan You Would Like to View", "-1"));
                    ddlShowMinors.Items.Insert(0, new ListItem("Select What Minor Plan You Would Like to View", "-1"));

                    conn = new SqlConnection(getConnectionString());
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Major%'";
                    conn.Open();

                    reader = cmd.ExecuteReader();
                    ddlShowMajors.DataSource = reader;
                    ddlShowMajors.DataTextField = "Major_Minor";
                    ddlShowMajors.DataValueField = "Major_Minor";
                    ddlShowMajors.DataBind();
                    conn.Close();

                    //***************************************************************************************//

                    conn = new SqlConnection(getConnectionString());
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Minor%'";
                    conn.Open();

                    reader = cmd.ExecuteReader();
                    ddlShowMinors.DataSource = reader;
                    ddlShowMinors.DataTextField = "Major_Minor";
                    ddlShowMinors.DataValueField = "Major_Minor";
                    ddlShowMinors.DataBind();
                    conn.Close();
                }
            }
        }

        protected void ddlShowMajors_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMinorRequiredPersonalizedPlan.Visible = false;
            gvMinorOptionalPersonalizedPlan.Visible = false;
            gvMajorRequiredPersonalizedPlan.Visible = true;
            gvMajorOptionalPersonalizedPlan.Visible = true;
        }

        protected void ddlShowMinors_SelectedIndexChanged(object sender, EventArgs e)
        {            
            gvMajorRequiredPersonalizedPlan.Visible = false;
            gvMajorOptionalPersonalizedPlan.Visible = false;
            gvMinorRequiredPersonalizedPlan.Visible = true;
            gvMinorOptionalPersonalizedPlan.Visible = true;
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }
}
