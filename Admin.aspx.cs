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
            //object[] keys = new object[gvUpdatePlan.DataKeyNames.Length];
            //gvUpdatePlan.DataKeys[e.RowIndex].Values.CopyTo(keys, 0);
            string majorMinor = e.NewValues["Major_Minor"].ToString();
            string code = e.NewValues["Code"].ToString();
            string credits = e.NewValues["Credits"].ToString();
            string optional = e.NewValues["Optional"].ToString();
            string descrip = e.NewValues["Descrip"].ToString();
            if (e.NewValues.Contains("Prereq") && e.NewValues["Prereq"] != null)
            {
                string prereq = e.NewValues["Prereq"].ToString();
            }

            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Requirements SET Major_Minor = @MajorMinor, Code = @Code, Credits = @Credits, Optional = @Optional, Descrip = @Descrip, Prereq = @Prereq WHERE Major_Minor = @MajorMinor";
                cmd.Parameters.AddWithValue("@MajorMinor", majorMinor);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Credits", credits);
                cmd.Parameters.AddWithValue("@Optional", optional);
                cmd.Parameters.AddWithValue("@Decrip", descrip);
                cmd.Parameters.AddWithValue("@Prereq", prereq);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Rebind the GridView control to the updated data source
            gvUpdatePlan.EditIndex = -1;
            BindGridView();
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