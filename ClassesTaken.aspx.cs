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
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private int numRowsAffected;

        private string code;
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
                if (!IsPostBack)
                {
                    ddlMajor.Items.Insert(0, new ListItem("Select Major", "-1"));
                    ddlMinor.Items.Insert(0, new ListItem("Select Minor", "-1"));

                    conn = new SqlConnection(getConnectionString());
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Major%'";
                    conn.Open();

                    reader = cmd.ExecuteReader();
                    ddlMajor.DataSource = reader;
                    ddlMajor.DataTextField = "Major_Minor";
                    ddlMajor.DataValueField = "Major_Minor";
                    ddlMajor.DataBind();
                    conn.Close();

                    //***************************************************************************************//

                    conn = new SqlConnection(getConnectionString());
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Minor%'";
                    conn.Open();

                    reader = cmd.ExecuteReader();
                    ddlMinor.DataSource = reader;
                    ddlMinor.DataTextField = "Major_Minor";
                    ddlMinor.DataValueField = "Major_Minor";
                    ddlMinor.DataBind();
                    conn.Close();
                }
            }
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlMajor.SelectedValue.Equals("Select Major"))
            {
                btnMajorAddClasses.Visible = false;
            }
            major_minor = ddlMajor.SelectedValue;
            gvMajorClassesTaken.Visible = true;
            btnMajorAddClasses.Visible = true;
            gvMinorClassesTaken.Visible = false;
            btnMinorAddClasses.Visible = false;
        }

        protected void ddlMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            major_minor = ddlMinor.SelectedValue;
            gvMinorClassesTaken.Visible = true;
            btnMinorAddClasses.Visible = true;
            gvMajorClassesTaken.Visible = false;
            btnMajorAddClasses.Visible = false;
        }

        protected void rbTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbTabs.SelectedItem.Text == "Select Classes for Your Major(s)")
            {
                ddlMajor.Visible = true;
                btnMajorAddClasses.Visible = false;
                ddlMinor.Visible = false;
                
            }
            else if (rbTabs.SelectedItem.Text == "Select Classes for Your Minor(s)")
            {
                ddlMinor.Visible = true;
                btnMinorAddClasses.Visible = false;
                ddlMajor.Visible = false;
                
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
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (GridViewRow row in gvMajorClassesTaken.Rows)
                        {
                            CheckBox cb = (CheckBox)row.FindControl("cbMajorSelected");
                            if (cb.Checked)
                            {
                                code = row.Cells[1].Text;

                                TextBox tbGrade = (TextBox)row.FindControl("txtMajorGrade");
                                grade = tbGrade.Text;

                                major_minor = ddlMajor.SelectedValue;
                                username = getSessionUsername();

                                // Insert into ClassesTaken table
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO ClassesTaken VALUES (@CourseCode, @Grade)", conn, tran))
                                {
                                    cmd.Parameters.Add("@CourseCode", SqlDbType.VarChar, 7).Value = code;
                                    cmd.Parameters.Add("@Grade", SqlDbType.VarChar, 2).Value = grade;
                                    cmd.ExecuteNonQuery();
                                }

                                // Insert into ClassesTaken_Req table
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO ClassesTaken_Req VALUES (@Major, @CourseCode)", conn, tran))
                                {
                                    cmd.Parameters.Add("@Major", SqlDbType.VarChar, 50).Value = major_minor;
                                    cmd.Parameters.Add("@CourseCode", SqlDbType.VarChar, 7).Value = code;
                                    cmd.ExecuteNonQuery();
                                }

                                // Insert into Student_ClassesTaken table
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO Student_ClassesTaken VALUES (@Username)", conn, tran))
                                {
                                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = username;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        tran.Commit();
                        lblStatus.Text = "Thank you for adding your classes!";
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        lblStatus.Text = "Classes not added. An error occurred: " + ex.Message;
                    }
                }
                conn.Close();
            }
        }

        protected void btnMinorAddClasses_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (GridViewRow row in gvMinorClassesTaken.Rows)
                        {
                            CheckBox cb = (CheckBox)row.FindControl("cbMinorSelected");
                            if (cb.Checked)
                            {
                                code = row.Cells[1].Text;

                                TextBox tbGrade = (TextBox)row.FindControl("txtMinorGrade");
                                grade = tbGrade.Text;

                                major_minor = ddlMinor.SelectedValue;
                                username = getSessionUsername();

                                // Insert into ClassesTaken table
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO ClassesTaken VALUES (@CourseCode, @Grade)", conn, tran))
                                {
                                    cmd.Parameters.Add("@CourseCode", SqlDbType.VarChar, 7).Value = code;
                                    cmd.Parameters.Add("@Grade", SqlDbType.VarChar, 2).Value = grade;
                                    cmd.ExecuteNonQuery();
                                }

                                // Insert into ClassesTaken_Req table
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO ClassesTaken_Req VALUES (@Minor, @CourseCode)", conn, tran))
                                {
                                    cmd.Parameters.Add("@Minor", SqlDbType.VarChar, 50).Value = major_minor;
                                    cmd.Parameters.Add("@CourseCode", SqlDbType.VarChar, 7).Value = code;
                                    cmd.ExecuteNonQuery();
                                }

                                // Insert into Student_ClassesTaken table
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO Student_ClassesTaken VALUES (@Username)", conn, tran))
                                {
                                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = username;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        tran.Commit();
                        lblStatus.Text = "Thank you for adding your classes!";
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        lblStatus.Text = "Classes not added. An error occurred: " + ex.Message;
                    }
                }
                conn.Close();
            }
        }
    }
}