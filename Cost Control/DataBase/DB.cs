using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cost_Control.DataBase
{
    public class DB
    {
        private string Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //Global Part
        public bool Authorization(string Login, string Password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [User] Where [Login] = '{Login}'", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        return (ReaderUrl.GetValue(1).ToString() == Login && ReaderUrl.GetValue(2).ToString() == Password) ? true : false;
                    }
                    ReaderUrl.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public int GetUserID(string Login)
        {
            try
            {
                int ID = 0;
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [User] WHERE [Login] = '{ Login}'", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        ID = ReaderUrl.GetInt32(0);
                    }
                    ReaderUrl.Close();
                }
                return ID;
            }
            catch
            {
                return 0;
            }
        }
        public string GetUserCurrency(string Login)
        {
            try
            {
                int ID = GetUserID(Login);
                string Currency = null;
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select [Currency] from [Settings] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Currency = ReaderUrl.GetString(0);
                    }
                    ReaderUrl.Close();
                }
                return Currency;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.User> GetUser(string Login)
        {
            try
            {
                int ID = GetUserID(Login);
                List<Models.User> User = new List<Models.User>();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [User] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        User.Add(new Models.User(ReaderUrl.GetInt32(0), ReaderUrl.GetString(1), ReaderUrl.GetString(2), ReaderUrl.GetString(3), ReaderUrl.GetString(4), ReaderUrl.GetString(5)));
                    }
                    ReaderUrl.Close();
                }
                return User;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public bool SaveUser(List<Models.User> User)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in User)
                    {
                        int ID = GetUserID(item.Login);
                        SqlCommand Url = new SqlCommand($"Update [User] set [FIO] = '{item.FIO}', [About] = '{item.Info}' WHERE [ID] = {ID}", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public bool ChangeUserPassword(string Login, string Password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    int ID = GetUserID(Login);
                    SqlCommand Url = new SqlCommand($"Update [User] set [Password] = '{Password}' WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    ReaderUrl.Close();
                }
                return true;
            }
            catch { return false; }
        }
        //Finance Part
        public bool AddConsumption(List<Models.Consumption> Consumption)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in Consumption)
                    {
                        SqlCommand Url = new SqlCommand($"insert into [Consumption] values ({item.UserID},'{item.Name}',{item.Sum},'{item.Currency}','{item.Date.ToString("yyyy-MM-dd")}','{item.Definition}','{item.Description}')", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public bool AddIncome(List<Models.Income> Income)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in Income)
                    {
                        SqlCommand Url = new SqlCommand($"insert into [Income] values ({item.UserID},'{item.Name}',{item.Sum},'{item.Currency}','{item.Date.ToString("yyyy-MM-dd")}','{item.Definition}','{item.Description}')", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public List<Models.Consumption> GetConsumption(string Login)
        {
            int ID = GetUserID(Login);
            List<Models.Consumption> Consumption = new List<Models.Consumption>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Consumption] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Consumption.Add(new Models.Consumption(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                        ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                    }
                    ReaderUrl.Close();
                }
                return Consumption;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.Income> GetIncome(string Login)
        {
            int ID = GetUserID(Login);
            List<Models.Income> Income = new List<Models.Income>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Income] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Income.Add(new Models.Income(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                        ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                    }
                    ReaderUrl.Close();
                }
                return Income;
            }
            catch
            {
                return null;
            }
        }
        public decimal GetConsumptionMonthSum(string Login)
        {
            try
            {
                int ID = GetUserID(Login);
                decimal Sum = 0;
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select [Sum] from [Consumption] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Sum += ReaderUrl.GetDecimal(0);
                    }
                    ReaderUrl.Close();
                }
                return Sum;
            }
            catch
            {
                return 0;
            }
        }
        public decimal GetIncomeMonthSum(string Login)
        {
            try
            {
                int ID = GetUserID(Login);
                decimal Sum = 0;
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select [Sum] from [Income] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Sum += ReaderUrl.GetDecimal(0);
                    }
                    ReaderUrl.Close();
                }
                return Sum;
            }
            catch
            {
                return 0;
            }
        }
        public void DeleteConsumption(int ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"delete from [Consumption] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        ID = ReaderUrl.GetInt32(0);
                    }
                    ReaderUrl.Close();
                }
            }
            catch { }
        }
        public void DeleteIncome(int ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"delete from [Income] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        ID = ReaderUrl.GetInt32(0);
                    }
                    ReaderUrl.Close();
                }
            }
            catch { }
        }
        public List<Models.Consumption> GetConsumptionByID(int ID)
        {
            List<Models.Consumption> Consumption = new List<Models.Consumption>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Consumption] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Consumption.Add(new Models.Consumption(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                        ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                    }
                    ReaderUrl.Close();
                }
                return Consumption;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.Income> GetIncomeByID(int ID)
        {
            List<Models.Income> Income = new List<Models.Income>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Income] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Income.Add(new Models.Income(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                        ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                    }
                    ReaderUrl.Close();
                }
                return Income;
            }
            catch
            {
                return null;
            }
        }
        public bool EditConsumption(List<Models.Consumption> Consumption)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in Consumption)
                    {
                        SqlCommand Url = new SqlCommand($"Update [Consumption] set [Name] = '{item.Name}',[Sum] = {item.Sum},[Date] = '{item.Date.ToString("yyyy-MM-dd")}',[Definition] = '{item.Definition}',[Description] = '{item.Description}' WHERE [ID] = {item.ID}", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public bool EditIncome(List<Models.Income> Income)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in Income)
                    {
                        SqlCommand Url = new SqlCommand($"Update [Income] set [Name] = '{item.Name}',[Sum] = {item.Sum},[Date] = '{item.Date.ToString("yyyy-MM-dd")}',[Definition] = '{item.Definition}',[Description] = '{item.Description}' WHERE [ID] = {item.ID}", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public List<Models.Consumption> GetMonthConsumption(string Login)
        {
            int ID = GetUserID(Login);
            List<Models.Consumption> Consumption = new List<Models.Consumption>();
            try
            {
                string date = DateTime.Now.ToShortDateString().Remove(0, 3).Remove(2, 5);
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Consumption] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        if (ReaderUrl.GetDateTime(5).ToShortDateString().Remove(0, 3).Remove(2, 5).Contains(date))
                        {
                            Consumption.Add(new Models.Consumption(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                            ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                        }
                    }
                    ReaderUrl.Close();
                }
                return Consumption;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.Income> GetMonthIncomes(string Login)
        {
            int ID = GetUserID(Login);
            List<Models.Income> Income = new List<Models.Income>();
            try
            {
                string date = DateTime.Now.ToShortDateString().Remove(0, 3).Remove(2, 5);
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Income] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        if (ReaderUrl.GetDateTime(5).ToShortDateString().Remove(0, 3).Remove(2, 5).Contains(date))
                        {
                            Income.Add(new Models.Income(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                            ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                        }
                    }
                    ReaderUrl.Close();
                }
                return Income;
            }
            catch
            {
                return null;
            }
        }
        //Reports
        public List<Models.Consumption> GetConsumption(string Login, DateTime Date)
        {
            int ID = GetUserID(Login);
            List<Models.Consumption> Consumption = new List<Models.Consumption>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Consumption] WHERE [UserID] = {ID} and [Date] = '{Date.ToString("yyyy-MM-dd")}'", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Consumption.Add(new Models.Consumption(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                        ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                    }
                    ReaderUrl.Close();
                }
                return Consumption;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.Income> GetIncome(string Login, DateTime Date)
        {
            int ID = GetUserID(Login);
            List<Models.Income> Income = new List<Models.Income>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Income] WHERE [UserID] = {ID} and [Date] = '{Date.ToString("yyyy-MM-dd")}'", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Income.Add(new Models.Income(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetDecimal(3),
                        ReaderUrl.GetString(4), ReaderUrl.GetDateTime(5), ReaderUrl.GetString(6), ReaderUrl.GetString(7)));
                    }
                    ReaderUrl.Close();
                }
                return Income;
            }
            catch
            {
                return null;
            }
        }
        public bool AddDebts(List<Models.Debts> Debts, string Login)
        {
            try
            {
                int ID = GetUserID(Login);
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in Debts)
                    {
                        SqlCommand Url = new SqlCommand($"insert into [Debts] values ({ID},'{item.Name}','{item.Currency}',{item.Sum},'{item.Type}','{item.LoanDate.ToString("yyyy-MM-dd")}','{item.ReturnDate.ToString("yyyy-MM-dd")}','{item.Description}')", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public List<Models.Debts> GetDebts(string Login)
        {
            int ID = GetUserID(Login);
            List<Models.Debts> Debts = new List<Models.Debts>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Debts] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Debts.Add(new Models.Debts(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetString(3), ReaderUrl.GetDecimal(4), ReaderUrl.GetString(5),
                            ReaderUrl.GetDateTime(6), ReaderUrl.GetDateTime(7), ReaderUrl.GetString(8)));
                    }
                    ReaderUrl.Close();
                }
                return Debts;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.Debts> GetDebts(string Login, DateTime Date)
        {
            int ID = GetUserID(Login);
            List<Models.Debts> Debts = new List<Models.Debts>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Debts] WHERE [UserID] = {ID} and [LoanDate] = '{Date.ToString("yyyy-MM-dd")}'", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Debts.Add(new Models.Debts(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetString(3), ReaderUrl.GetDecimal(4), ReaderUrl.GetString(5),
                            ReaderUrl.GetDateTime(6), ReaderUrl.GetDateTime(7), ReaderUrl.GetString(8)));
                    }
                    ReaderUrl.Close();
                }
                return Debts;
            }
            catch
            {
                return null;
            }
        }
        public List<Models.Debts> GetDebtsByID(int ID)
        {
            List<Models.Debts> Debts = new List<Models.Debts>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Debts] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        Debts.Add(new Models.Debts(ReaderUrl.GetInt32(0), ReaderUrl.GetInt32(1), ReaderUrl.GetString(2), ReaderUrl.GetString(3), ReaderUrl.GetDecimal(4), ReaderUrl.GetString(5),
                            ReaderUrl.GetDateTime(6), ReaderUrl.GetDateTime(7), ReaderUrl.GetString(8)));
                    }
                    ReaderUrl.Close();
                }
                return Debts;
            }
            catch
            {
                return null;
            }
        }
        public void DeleteDebt(int ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"delete from [Debts] WHERE [ID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        ID = ReaderUrl.GetInt32(0);
                    }
                    ReaderUrl.Close();
                }
            }
            catch { }
        }
        public bool EditDebts(List<Models.Debts> Debts)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    foreach (var item in Debts)
                    {
                        SqlCommand Url = new SqlCommand($"Update [Debts] set [Name] = '{item.Name}',[Currency] = '{item.Currency}',[Sum] = {item.Sum},[Type] = '{item.Type}',[LoanDate] = '{item.LoanDate.ToString("yyyy-MM-dd")}'" +
                            $",[ReturnDate] = '{item.ReturnDate.ToString("yyyy-MM-dd")}', [Description] = '{item.Description}' WHERE [ID] = {item.ID}", con);
                        SqlDataReader ReaderUrl = Url.ExecuteReader();
                        ReaderUrl.Close();
                    }
                }
                return true;
            }
            catch { return false; }

        }
        public int GetDebtsCount(string Login)
        {
            int counter = 0;
            int ID = GetUserID(Login);
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand Url = new SqlCommand($"select * from [Debts] WHERE [UserID] = {ID}", con);
                    SqlDataReader ReaderUrl = Url.ExecuteReader();
                    while (ReaderUrl.Read())
                    {
                        counter++;
                    }
                    ReaderUrl.Close();
                }
                return counter;
            }
            catch
            {
                return 0;
            }
        }
    }

}