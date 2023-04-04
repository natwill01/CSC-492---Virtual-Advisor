using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class PersonalizedPlan : System.Web.UI.Page
    {
        private SqlConnection conn1;
        private SqlCommand cmd1;
        private SqlDataReader reader1;

        private SqlConnection conn2;
        private SqlCommand cmd2;
        private SqlDataReader reader2;

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (String)Session["Username"];


            if (!IsPostBack)
            {
                DDLPP_Major.Items.Insert(0, new ListItem("Select Major", "-1"));
                DDLPP_Minor.Items.Insert(0, new ListItem("Select Minor", "-1"));

                conn1 = new SqlConnection(getConnectionString());
                cmd1 = new SqlCommand();
                cmd1.Connection = conn1;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Major%'";
                conn1.Open();

                reader1 = cmd1.ExecuteReader();
                DDLPP_Major.DataSource = reader1;
                DDLPP_Major.DataTextField = "Major_Minor";
                DDLPP_Major.DataValueField = "Major_Minor";
                DDLPP_Major.DataBind();
                conn1.Close();

                //***************************************************************************************//

                conn2 = new SqlConnection(getConnectionString());
                cmd2 = new SqlCommand();
                cmd2.Connection = conn2;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT DISTINCT [Major_Minor] FROM [Requirements] WHERE Major_Minor LIKE '%Minor%'";
                conn2.Open();

                reader2 = cmd2.ExecuteReader();
                DDLPP_Minor.DataSource = reader2;
                DDLPP_Minor.DataTextField = "Major_Minor";
                DDLPP_Minor.DataValueField = "Major_Minor";
                DDLPP_Minor.DataBind();
                conn2.Close();
            }

        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VirtualAdvisorConnectionString"].ConnectionString;
        }

        protected void DDLPP_Major_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblStatus.Text = "SelectedIndexChanged event triggered!";

            if (GVPP != null)
            {
                GVPP.DataSource = null;
                GVPP.DataBind();
            }

            String major = Convert.ToString(DDLPP_Major.SelectedValue);

            conn1 = new SqlConnection(getConnectionString());
            cmd1 = new SqlCommand();
            cmd1.Connection = conn1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT Code, Credits, Descrip FROM [Requirements] JOIN ClassesTaken_Req on (Code, Mojor_Minor) JOIN ClassesTaken on (Course_ID) WHERE (Code != Code_CT) && ( ";
            cmd1.Parameters.AddWithValue("@Major_Minor", major);
            conn1.Open();

            reader1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader1);
            GVPP.DataSource = dt;
            GVPP.DataBind();

            conn1.Close();


        }

        protected void DDLPP_Minor_SelectedIndexChanged(object sender, EventArgs e)
        {




        }
    }
    }
