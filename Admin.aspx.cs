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

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }
    }

}