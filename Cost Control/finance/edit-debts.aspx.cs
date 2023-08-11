using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control.finance
{
    public partial class edit_debts : System.Web.UI.Page
    {
        static int id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddCurrency();
                GetDebts();
            }
        }
        private void AddCurrency()
        {
            Currency.Items.Add(Server.HtmlDecode("Hryvnia &#8372;"));
            Currency.Items.Add(Server.HtmlDecode("Dollar &#36;"));
            Type.Items.Add("Lent ->");
            Type.Items.Add("Took <-");
        }
        private bool GetDebts()
        {
            bool isInt = Int32.TryParse(Request.QueryString["edit_id"], out int num);
            id = num;
            if (isInt == true)
            {
                DataBase.DB DB = new DataBase.DB();
                foreach (var item in DB.GetDebtsByID(id))
                {
                    Name.Text = item.Name;
                    Sum.Text = item.Sum.ToString();
                    Currency.SelectedValue = Server.HtmlDecode(item.Currency);
                    if(item.Type == "Lent") { Type.SelectedIndex = 0; }
                    else { Type.SelectedIndex = 1; }
                    LoanDate.Text = item.LoanDate.ToString("yyyy-MM-dd");
                    ReturnDate.Text = item.ReturnDate.ToString("yyyy-MM-dd");
                    Description.Text = item.Description;
                }
                return true;
            }
            else
            {
                Response.Redirect("debts.aspx");
                return false;
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            if (Name.Text.Length >= 2)
            {
                if (Currency.SelectedValue != null)
                {
                    if (LoanDate.Text.Length >= 6 && LoanDate.Text.Length >= 6)
                    {
                        SaveToDb();
                    }
                    else
                    {
                        error_label.InnerText = "The string 'LoanDate' and 'ReturnDate' must contain the full date.";
                    }
                }
                else
                {
                    error_label.InnerText = "The string 'Currency' must contain a value.";
                }
            }
            else
            {
                error_label.InnerText = "The string 'Name' contains 2 or more characters.";
            }
        }
        private void SaveToDb()
        {
            List<Models.Debts> Debts = new List<Models.Debts>();
            DataBase.DB DB = new DataBase.DB();
            string currency = null;
            if (Currency.SelectedValue == "Hryvnia ₴") { currency = "Hryvnia &#8372;"; }
            else { currency = "Dollar &#36;"; }
            Decimal.TryParse(Server.HtmlEncode(Sum.Text.Trim()), out decimal n);
            DateTime.TryParse(Server.HtmlEncode(LoanDate.Text.Trim()), out DateTime l);
            DateTime.TryParse(Server.HtmlEncode(ReturnDate.Text.Trim()), out DateTime r);
            Debts.Add(new Models.Debts(id, DB.GetUserID((string)Session["Authorization"]), Server.HtmlEncode(Name.Text.Trim()), currency ,
                n, Server.HtmlEncode(Type.Text.Trim()), l, r, Server.HtmlEncode(Description.Text.Trim())));
            if (DB.EditDebts(Debts))
            {
                error_label.InnerText = "Well Done!";
            }
            else { error_label.InnerText = "Error. Try again later."; }
        }
    }
}