using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control.Parts
{
    public partial class NavBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorization_Checker();
        }
        private void Authorization_Checker()
        {
            if (!String.IsNullOrEmpty((string)Session["Authorization"]))
            {
                User_Name.InnerText = (string)Session["Authorization"];
            }
            else { Response.Redirect("index.aspx"); }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["Authorization"] = null;
            Response.Redirect("index.aspx");
        }
    }
}