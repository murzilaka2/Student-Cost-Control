using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
            }
        }
        private void LoadUser()
        {
            DataBase.DB DB = new DataBase.DB();
            foreach (var item in DB.GetUser((string)Session["Authorization"]))
            {
                Login.Text = item.Login;
                Email.Text = item.Email;
                FIO.Text = item.FIO;
                About.Text = item.Info;
            }
        }
        private void SaveUser()
        {
            if (Password.Text.Length >= 1 || PasswordAgain.Text.Length >= 1)
            {
                SetPassword();
            }
            else
            {
                DataBase.DB DB = new DataBase.DB();
                List<Models.User> User = new List<Models.User>();
                User.Add(new Models.User(0, (string)Session["Authorization"], "", "", Server.HtmlEncode(FIO.Text.Trim()), Server.HtmlEncode(About.Text.Trim())));
                if (DB.SaveUser(User))
                {
                    error_label.InnerText = "Well Done!";
                }
                else
                {
                    error_label.InnerText = "Error. Try again later.";
                }
            }          
        }
        private void SetPassword()
        {
            if (Password.Text.Length >= 3 && PasswordAgain.Text.Length >= 3)
            {
                if (Password.Text.Contains(PasswordAgain.Text))
                {
                    DataBase.DB DB = new DataBase.DB();
                    if (DB.ChangeUserPassword((string)Session["Authorization"],Helper.Help.MD5HASH(Server.HtmlEncode(Password.Text.Trim()))))
                    {
                        error_label.InnerText = "Well Done! Your password has been updated.";
                    }
                    else
                    {
                        error_label.InnerText = "Error. Try again later.";
                    }
                }
                else
                {
                    error_label.InnerText = "Passwords must match.";
                }
            }
            else { error_label.InnerText = "The string 'Password' and 'Password Again' contains 3 or more characters."; }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            SaveUser();
        }
    }
}