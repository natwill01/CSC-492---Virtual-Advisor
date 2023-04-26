using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class _4YearPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUser = getSessionUsername();
            if(currentUser == "cindricbb")
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ddlPlan.Items.Insert(0, new ListItem("Select The Plan You Would Like to View", "-1"));
                }
            }               
        }
        private string getSessionUsername()
        {
            return (string)Session["Username"];
        }
    }
}