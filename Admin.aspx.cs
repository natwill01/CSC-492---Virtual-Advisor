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
using System.Xml.Linq;

namespace Virtual_Advisor
{
    public partial class Admin : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Username"] != "cindricbb")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                conn = new SqlConnection(getConnectionString());
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requirements";
                conn.Open();

                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                gvUpdatePlan.DataSource = dt;
                gvUpdatePlan.DataBind();
                conn.Close();
            }

        }

        protected void gvUpdatePlan_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUpdatePlan.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void gvUpdatePlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUpdatePlan.Rows[e.RowIndex];

            string majorMinor = row.Cells[1].Text;
            string code = row.Cells[2].Text;
            string credits = e.NewValues["Credits"].ToString();
            string optional = e.NewValues["Optional"].ToString();
            string descrip = e.NewValues["Descrip"].ToString();
            string prereq = "";
            if (e.NewValues.Contains("Prereq") && e.NewValues["Prereq"] != null)
            {
                prereq = e.NewValues["Prereq"].ToString();
            }
            else
            {
                prereq = "";
            }

            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Requirements SET Credits = @Credits, Optional = @Optional, Descrip = @Descrip, Prereq = @Prereq WHERE Major_Minor = @MajorMinor AND Code = @Code";
                cmd.Parameters.AddWithValue("@Credits", credits);
                cmd.Parameters.AddWithValue("@Optional", optional);
                cmd.Parameters.AddWithValue("@Descrip", descrip);
                cmd.Parameters.AddWithValue("@Prereq", prereq);
                cmd.Parameters.AddWithValue("MajorMinor", majorMinor);
                cmd.Parameters.AddWithValue("Code", code);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                // Rebind the GridView control to the updated data source
                gvUpdatePlan.EditIndex = -1;
                BindGridView();
            }
        }

        private void BindGridView()
        {
            conn = new SqlConnection(getConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Requirements";
            conn.Open();

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            gvUpdatePlan.DataSource = dt;
            gvUpdatePlan.DataBind();
            conn.Close();
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }

        
    }

}