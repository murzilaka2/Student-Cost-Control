using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control.Finance
{
    public partial class annotate_expenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddCurrencyDate();
            }
        }
        private void AddCurrencyDate()
        {
            DataBase.DB DB = new DataBase.DB();
            string currency = DB.GetUserCurrency((string)Session["Authorization"]);
            if (currency == "Hryvnia &#8372;") { Currency.Items.Add(Server.HtmlDecode("Hryvnia &#8372;")); }
            else if (currency == "Dollar &#36;") { Currency.Items.Add(Server.HtmlDecode("Dollar &#36;")); }
            else if (currency == "Euro &#8364") { Currency.Items.Add(Server.HtmlDecode("Euro &#8364;")); }
            else { Currency.Items.Add(Server.HtmlDecode("Ruble &#8381;")); }
            Date.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (Name.Text.Length >= 2)
            {
                if (Currency.SelectedValue != null)
                {
                    if (Date.Text.Length >= 6)
                    {
                        SaveToDb();
                    }
                    else
                    {
                        error_label.InnerText = "The string 'Date' must contain the full date.";
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
            List<Models.Consumption> Consumption = new List<Models.Consumption>();
            DataBase.DB DB = new DataBase.DB();
            string currency = DB.GetUserCurrency((string)Session["Authorization"]);
            Decimal.TryParse(Server.HtmlEncode(Sum.Text.Trim()), out decimal n);
            DateTime.TryParse(Server.HtmlEncode(Date.Text.Trim()), out DateTime d);
            Consumption.Add(new Models.Consumption(0, DB.GetUserID((string)Session["Authorization"]), Server.HtmlEncode(Name.Text.Trim()), n, currency,
            d, Server.HtmlEncode(Definition.Text.Trim()), Server.HtmlEncode(Description.Text.Trim())));
            if (DB.AddConsumption(Consumption))
            {
                error_label.InnerText = "Well Done!";
            }
            else { error_label.InnerText = "Error. Try again later."; }
        }
    }
}