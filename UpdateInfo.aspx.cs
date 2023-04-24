using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Virtual_Advisor
{
    public partial class UpdateInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null && Session["Password"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void gvUpdateGrade_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtGrade = (TextBox)gvUpdateGrade.Rows[e.RowIndex].FindControl("gvUpdateGrade_Grade_" + e.RowIndex);
            string newGrade = txtGrade.Text;

            SqlDataSource sdsGradeUpdate = sender as SqlDataSource;
            sdsGradeUpdate.UpdateParameters["Grade"].DefaultValue = newGrade;
        }
    }
}