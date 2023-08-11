using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control.Parts
{
    public partial class SideBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Session["Authorization"] = null;
            Response.Redirect("index.aspx");
        }
    }
}