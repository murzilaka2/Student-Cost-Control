using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control.finance
{
    public partial class detailed_statistics_expenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AllExpensesPlaceM();
                SetDate();
            }
        }
        private void AllExpensesPlaceM()
        {
            DataBase.DB DB = new DataBase.DB();
            foreach (var item in DB.GetConsumption((string)Session["Authorization"]))
            {
                LinkButton delete = new LinkButton();
                delete.Controls.Add(new LiteralControl("<i class=\"fa fa-fw fa-trash-alt\"></i>"));
                delete.Click += (sender, args) =>
                {
                    DB.DeleteConsumption(item.ID);
                    Response.Redirect("detailed_statistics_expenses.aspx");
                };
                AllExpensesPlace.Controls.Add(new LiteralControl($"<tr><td>{item.ID}</td><td>{item.Name}</td><td>{item.Sum}</td><td>{item.Currency}</td><td>{item.Date.ToShortDateString()}</td><td>{item.Definition}</td><td>{item.Description}</td><td><a href=\"../finance/edit-expenses.aspx?edit_id={item.ID}\"><i class=\"fa fa-fw fa-edit\"></i></a><a href=\"\">"));
                AllExpensesPlace.Controls.Add(delete);
                AllExpensesPlace.Controls.Add(new LiteralControl("</a></td></tr>"));
            }
        }
        private void SetDate()
        {
            StartDate.Text = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
            EndDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            int count = 0;
            string currency = null;
            decimal sum = 0;
            if (StartDate.Text != null && EndDate.Text != null)
            {
                DateTime.TryParse(StartDate.Text, out DateTime Start);
                DateTime.TryParse(EndDate.Text, out DateTime End);
                DateTime PeriodBeforeStart = Start;
                DateTime PeriodBeforeEnd = End;
                int counter = 0;
                DataBase.DB DB = new DataBase.DB();
                while (Start <= End)
                {
                    counter++;
                    foreach (var item in DB.GetConsumption((string)Session["Authorization"], Start))
                    {
                        count++;
                        sum += item.Sum;
                        currency = item.Currency;
                        LinkButton delete = new LinkButton();
                        delete.Controls.Add(new LiteralControl("<i class=\"fa fa-fw fa-trash-alt\"></i>"));
                        delete.Click += (sender2, args) =>
                        {
                            DB.DeleteConsumption(item.ID);
                            Response.Redirect("panel.aspx");
                        };
                        AllExpensesPlace.Controls.Add(new LiteralControl($"<tr><td>{item.ID}</td><td>{item.Name}</td><td>{item.Sum}</td><td>{item.Currency}</td><td>{item.Date.ToShortDateString()}</td><td>{item.Definition}</td><td>{item.Description}</td><td><a href=\"../finance/edit-expenses.aspx?edit_id={item.ID}\"><i class=\"fa fa-fw fa-edit\"></i></a><a href=\"\">"));
                        AllExpensesPlace.Controls.Add(delete);
                        AllExpensesPlace.Controls.Add(new LiteralControl("</a></td></tr>"));
                    }
                    Start = Start.AddDays(1);
                }
                CreateReport(count, currency, sum, Start.ToShortDateString(), End.ToShortDateString());
                PeriodBeforeStart = PeriodBeforeStart.AddDays(-counter);
                PeriodBeforeEnd = PeriodBeforeEnd.AddDays(-counter);
                decimal sum2 = 0;
                while (PeriodBeforeStart <= PeriodBeforeEnd)
                {
                    foreach (var item in DB.GetConsumption((string)Session["Authorization"], PeriodBeforeStart))
                    {
                        sum2 += item.Sum;
                    }
                    PeriodBeforeStart = PeriodBeforeStart.AddDays(1);
                }
                if (sum2 != 0)
                {
                    sum2 = ((sum - sum2) / sum2) * 100;
                    if (sum2 < 1) { previousperiod.Attributes.Add("style", "color:red;");  previousperiod.InnerText = $"Down {sum2 = decimal.Round(sum2,2)}%"; }
                    else { previousperiod.Attributes.Add("style","color:green;"); previousperiod.InnerText = $"Up {sum2 = decimal.Round(sum2, 2)}%"; }
                }
                else
                {
                    previousperiod.InnerText = "There is nothing to compare.";
                }
            }
            else
            {

            }
        }

        private void CreateReport(int count, string currency, decimal sum, string start, string end)
        {
            ReportItem.Visible = true;
            CultureInfo ci = new CultureInfo("en-US");
            dateitem.InnerText = DateTime.Now.ToString("dd MMMM, yyyy", ci);
            items.InnerText = count.ToString();
            currencyitem.InnerText = Server.HtmlDecode(currency);
            datespanitem.InnerText = $"{start} - {end}";
            nameitem.InnerText = (string)Session["Authorization"];
            currency = "&" + currency.Split('&').Last();
            totalitem.InnerText = $"{Server.HtmlDecode(currency)} {sum.ToString()}";
        }
    }
}