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
using System.Web.DynamicData;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

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

        private string course;
        private string grade;
        private string major_minor;
        private string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                username = getSessionUsername();
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
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            major_minor = ddlMajor.SelectedValue;
        }

        protected void ddlMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            major_minor = ddlMinor.SelectedValue;
        }

        protected void rbTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbTabs.SelectedItem.Text == "Select Classes for Your Major(s)")
            {
                ddlMajor.Visible = true;
                gvMajorClassesTaken.Visible = true;
                btnMajorAddClasses.Visible = true;
                ddlMinor.Visible = false;
                gvMinorClassesTaken.Visible = false;
                btnMinorAddClasses.Visible = false;
            }
            else if (rbTabs.SelectedItem.Text == "Select Classes for Your Minor(s)")
            {
                ddlMinor.Visible = true;
                gvMinorClassesTaken.Visible = true;
                btnMinorAddClasses.Visible = true;
                ddlMajor.Visible = false;
                gvMajorClassesTaken.Visible = false;
                btnMajorAddClasses.Visible = false;
            }
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }

        private string getSessionUsername()
        {
            return (string)Session["Username"];
        }

        protected void btnMajorAddClasses_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvMajorClassesTaken.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbMajorSelected");
                if (cb.Checked)
                {
                    course = row.Cells[1].Text;
                    grade = row.Cells[4].Text;
                }
            }

            //Inserts
        }

        protected void btnMinorAddClasses_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvMinorClassesTaken.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbMinorSelected");
                if (cb.Checked)
                {
                    course = row.Cells[1].Text;
                    grade = row.Cells[4].Text;
                }
            }

            //Inserts
        }
    }
}