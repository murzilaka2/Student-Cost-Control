using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control
{
    public partial class panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllExpensesPlaceM();
            ThisMonthStates();
            GetThisMonthFinance();
            total_deborts.Text = GetTotalDeborts().ToString();
            if (!IsPostBack)
            {
                GetFinanceStates();
            }
        }
        private void AllExpensesPlaceM()
        {
            decimal sum = 0;
            DataBase.DB DB = new DataBase.DB();
            foreach (var item in DB.GetConsumption((string)Session["Authorization"]))
            {
                LinkButton delete = new LinkButton();
                delete.Controls.Add(new LiteralControl("<i class=\"fa fa-fw fa-trash-alt\"></i>"));
                delete.Click += (sender, args) =>
                {
                    DB.DeleteConsumption(item.ID);
                    Response.Redirect("panel.aspx");
                };
                AllExpensesPlace.Controls.Add(new LiteralControl($"<tr><td>{item.ID}</td><td>{item.Name}</td><td>{item.Sum}</td><td>{item.Currency}</td><td>{item.Date.ToShortDateString()}</td><td>{item.Definition}</td><td>{item.Description}</td><td><a href=\"../finance/edit-expenses.aspx?edit_id={item.ID}\"><i class=\"fa fa-fw fa-edit\"></i></a><a href=\"\">"));
                AllExpensesPlace.Controls.Add(delete);
                AllExpensesPlace.Controls.Add(new LiteralControl("</a></td></tr>"));
                sum += item.Sum;
            }
            AllIncomePlaceM(sum);
        }
        private void AllIncomePlaceM(decimal sum)
        {
            string currency = null;
            decimal sum2 = 0;
            DataBase.DB DB = new DataBase.DB();
            foreach (var item in DB.GetIncome((string)Session["Authorization"]))
            {
                LinkButton delete = new LinkButton();
                delete.Controls.Add(new LiteralControl("<i class=\"fa fa-fw fa-trash-alt\"></i>"));
                delete.Click += (sender, args) =>
                {
                    DB.DeleteIncome(item.ID);
                    Response.Redirect("panel.aspx");
                };
                AllIncomePlace.Controls.Add(new LiteralControl($"<tr><td>{item.ID}</td><td>{item.Name}</td><td>{item.Sum}</td><td>{item.Currency}</td><td>{item.Date.ToShortDateString()}</td><td>{item.Definition}</td><td>{item.Description}</td><td><a href=\"../finance/edit-incomes.aspx?edit_id={item.ID}\"><i class=\"fa fa-fw fa-edit\"></i></a><a href=\"\">"));
                AllIncomePlace.Controls.Add(delete);
                AllIncomePlace.Controls.Add(new LiteralControl("</a></td></tr>"));
                sum2 += item.Sum;
                currency = item.Currency;
            }
            sum2 = sum2 - sum;
            your_balance.Text = "&" + currency.Split('&').Last()+" "+sum2.ToString();

        }
        private void GetFinanceStates()
        {
            DataBase.DB DB = new DataBase.DB();
            decimal money = DB.GetConsumptionMonthSum((string)Session["Authorization"]);
            string currency = "&" + DB.GetUserCurrency((string)Session["Authorization"]).Split('&').Last();
            MoneyExpensesLabel.Text = money.ToString();
            CurrencyExpensesLabel.Text = currency;
            CurrencyIncomeLabel.Text = currency;
            CurrencyExpensesMonthLabel.Text = currency;
            CurrencyIncomesMonthLabel.Text = currency;
            money = DB.GetIncomeMonthSum((string)Session["Authorization"]);
            MoneyIncomeLabel.Text = money.ToString();
        }
        private void ThisMonthStates()
        {
            DateTime now = DateTime.Now;
            monthexpensesdate.InnerText = $" from {new DateTime(now.Year, now.Month, 1).ToShortDateString()} to {DateTime.Now.ToShortDateString()}";
            monthincomesdate.InnerText = $" from {new DateTime(now.Year, now.Month, 1).ToShortDateString()} to {DateTime.Now.ToShortDateString()}";
        }
        private void GetThisMonthFinance()
        {
            decimal sum = 0;
            DataBase.DB DB = new DataBase.DB();
            foreach (var item in DB.GetMonthConsumption((string)Session["Authorization"]))
            {
                sum += item.Sum;
            }
            MoneyExpensesMonthLabel.Text = sum.ToString();
            sum = 0;
            foreach (var item in DB.GetMonthIncomes((string)Session["Authorization"]))
            {
                sum += item.Sum;
            }
            MoneyIncomesMonthLabel.Text = sum.ToString();
        }
        private int GetTotalDeborts()
        {
            DataBase.DB DB = new DataBase.DB();
            return DB.GetDebtsCount((string)Session["Authorization"]);
        }
    }
}