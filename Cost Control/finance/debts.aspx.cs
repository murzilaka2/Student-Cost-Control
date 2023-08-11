using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cost_Control.finance
{
    public partial class debts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetForms();
                SetDate();
                AllDebtsPlaceM();
            }
        }
        private void SetForms()
        {
            Currency.Items.Add(Server.HtmlDecode("Hryvnia &#8372;"));
            Currency.Items.Add(Server.HtmlDecode("Dollar &#36;"));
            OperationType.Items.Add("Lent ->");
            OperationType.Items.Add("Took <-");
            LoanDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            ReturnDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (Name.Text.Length >= 2)
            {
                SaveToDB();
            }
            else
            {
                error_label.InnerText = "The string 'Name' contains 2 or more characters.";
            }
        }
        private void SaveToDB()
        {
            List<Models.Debts> Debts = new List<Models.Debts>();
            DataBase.DB DB = new DataBase.DB();
            Decimal.TryParse(Sum.Text, out decimal d);
            DateTime.TryParse(LoanDate.Text, out DateTime l);
            DateTime.TryParse(ReturnDate.Text, out DateTime r);
            string currency = null;
            if(Currency.SelectedValue == "Hryvnia &#8372;") { currency = "Hryvnia &#8372;"; }
            else { currency = "Dollar &#36;"; }
            string op = null;
            if (OperationType.SelectedValue == "Lent ->") { op = "Lent"; }
            else{ op = "Took"; }
            Debts.Add(new Models.Debts(0,0,Server.HtmlEncode(Name.Text.Trim()),currency,d,op,l,r.AddDays(7),Server.HtmlEncode(Description.Text.Trim())));
            if (DB.AddDebts(Debts, (string)Session["Authorization"]))
            {
                error_label.InnerText = "Well Done!";
            }
            else { error_label.InnerText = "Error. Try again later."; }
        }
        private void AllDebtsPlaceM()
        {
            DataBase.DB DB = new DataBase.DB();
            foreach (var item in DB.GetDebts((string)Session["Authorization"]))
            {
                LinkButton delete = new LinkButton();
                delete.Controls.Add(new LiteralControl("<i class=\"fa fa-fw fa-trash-alt\"></i>"));
                delete.Click += (sender, args) =>
                {
                    DB.DeleteDebt(item.ID);
                    Response.Redirect("debts.aspx");
                };
                AllDebtsPlace.Controls.Add(new LiteralControl($"<tr><td>{item.ID}</td><td>{item.Name}</td><td>{item.Sum}</td><td>{item.Currency}</td><td>{item.Type}</td><td>{item.LoanDate.ToShortDateString()}</td><td>{item.ReturnDate.ToShortDateString()}</td><td>{item.Description}</td><td><a href=\"../finance/edit-debts.aspx?edit_id={item.ID}\"><i class=\"fa fa-fw fa-edit\"></i></a><a href=\"\">"));
                AllDebtsPlace.Controls.Add(delete);
                AllDebtsPlace.Controls.Add(new LiteralControl("</a></td></tr>"));
            }
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
                DataBase.DB DB = new DataBase.DB();
                while (Start <= End)
                {
                    foreach (var item in DB.GetDebts((string)Session["Authorization"], Start))
                    {
                        currency = item.Currency;
                        LinkButton delete = new LinkButton();
                        delete.Controls.Add(new LiteralControl("<i class=\"fa fa-fw fa-trash-alt\"></i>"));
                        delete.Click += (sender2, args) =>
                        {
                            DB.DeleteDebt(item.ID);
                            Response.Redirect("debts.aspx");
                        };
                        AllDebtsPlace.Controls.Add(new LiteralControl($"<tr><td>{item.ID}</td><td>{item.Name}</td><td>{item.Sum}</td><td>{item.Currency}</td><td>{item.Type}</td><td>{item.LoanDate.ToShortDateString()}</td><td>{item.ReturnDate.ToShortDateString()}</td><td>{item.Description}</td><td><a href=\"../finance/edit-debts.aspx?edit_id={item.ID}\"><i class=\"fa fa-fw fa-edit\"></i></a><a href=\"\">"));
                        AllDebtsPlace.Controls.Add(delete);
                        AllDebtsPlace.Controls.Add(new LiteralControl("</a></td></tr>"));
                    }
                    Start = Start.AddDays(1);
                }
            }
        }
        private void SetDate()
        {
            StartDate.Text = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
            EndDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}