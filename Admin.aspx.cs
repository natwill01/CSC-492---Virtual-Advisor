using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Username"] != "cindricbb")
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void gvUpdatePlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtMajorMinor = (TextBox)gvUpdatePlan.Rows[e.RowIndex].FindControl("gvUpdatePlan_Major_Minor_" + e.RowIndex);
            string newMajorMinor = txtMajorMinor != null ? txtMajorMinor.Text : "";

            TextBox txtCode = (TextBox)gvUpdatePlan.Rows[e.RowIndex].FindControl("gvUpdatePlan_Code_" + e.RowIndex);
            string newCode = txtCode != null ? txtCode.Text : "";

            TextBox txtCredits = (TextBox)gvUpdatePlan.Rows[e.RowIndex].FindControl("gvUpdatePlan_Credits_" + e.RowIndex);
            int newCredits = 0;
            int.TryParse(txtCredits.Text, out newCredits);

            TextBox txtOptional = (TextBox)gvUpdatePlan.Rows[e.RowIndex].FindControl("gvUpdatePlan_Optional_" + e.RowIndex);
            int newOptional = 0;
            int.TryParse(txtOptional.Text, out newOptional);

            TextBox txtDescrip = (TextBox)gvUpdatePlan.Rows[e.RowIndex].FindControl("gvUpdatePlan_Descrip_" + e.RowIndex);
            string newDescrip = txtDescrip != null ? txtDescrip.Text : "";

            TextBox txtPrereq = (TextBox)gvUpdatePlan.Rows[e.RowIndex].FindControl("gvUpdatePlan_Prereq_" + e.RowIndex);
            string newPrereq = txtPrereq != null ? txtPrereq.Text : "";


            SqlDataSource sdsUpdatePlan = sender as SqlDataSource;
                sdsUpdatePlan.UpdateParameters["MajorMinor"].DefaultValue = newMajorMinor;
                sdsUpdatePlan.UpdateParameters["Code"].DefaultValue = newCode;
                sdsUpdatePlan.UpdateParameters["Credits"].DefaultValue = newCredits.ToString();
                sdsUpdatePlan.UpdateParameters["Optional"].DefaultValue = newOptional.ToString();
                sdsUpdatePlan.UpdateParameters["Descrip"].DefaultValue = newDescrip;
                sdsUpdatePlan.UpdateParameters["Prereq"].DefaultValue = string.IsNullOrEmpty(newPrereq) ? null : newPrereq;
        }
    }
}