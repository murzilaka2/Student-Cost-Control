using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cost_Control.Models
{
    public class Debts
    {
        public int ID { get; }
        public int UserID { get; }
        public string Name { get; }
        public string Currency { get; }
        public decimal Sum { get; }
        public string Type { get; }
        public DateTime LoanDate { get; }
        public DateTime ReturnDate { get; }
        public string Description { get; }
        
        public Debts(int ID, int UserID, string Name, string Currency, decimal Sum, string Type, DateTime LoanDate, DateTime ReturnDate, string Description)
        {
            this.ID = ID;
            this.UserID = UserID;
            this.Name = Name;
            this.Currency = Currency;
            this.Sum = Sum;
            this.Type = Type;
            this.LoanDate = LoanDate;
            this.ReturnDate = ReturnDate;
            this.Description = Description;
        }
    }
}