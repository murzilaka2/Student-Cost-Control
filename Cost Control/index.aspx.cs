using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.Login_But.UniqueID;
            Authorization_Checker();
        }
        private void Authorization_Checker()
        {
            if (!String.IsNullOrEmpty((string)Session["Authorization"]))
            {
                Response.Redirect("panel.aspx");
            }
        }

        protected void Login_But_Click(object sender, EventArgs e)
        {
            string sLogin = null;
            string sPassword = null;
            if (Login.Text.Length >= 3)
            {
                sLogin = Server.HtmlEncode(Login.Text.Trim());
                if (Password.Text.Length >= 3)
                {
                    sPassword = Server.HtmlEncode(Helper.Help.MD5HASH(Password.Text.Trim()));
                    DataBase.DB DB = new DataBase.DB();
                    if (DB.Authorization(sLogin, sPassword))
                    {
                        Session["Authorization"] = sLogin;
                        Response.Redirect("panel.aspx");
                    }
                    else { error_label.InnerText = "Wrong login or password."; }
                }
                else { error_label.InnerText = "The string 'Password' contains 3 or more characters."; }
            }
            else { error_label.InnerText = "The string 'Login' contains 3 or more characters."; }
        }
    }
}