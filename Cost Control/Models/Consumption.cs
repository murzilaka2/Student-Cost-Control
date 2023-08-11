using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cost_Control.Models
{
    //Рассходы
    public class Consumption
    {
        public int ID { get; }
        public int UserID { get; }
        public string Name { get; }
        public decimal Sum { get; }
        public string Currency { get; }
        public DateTime Date { get; }
        public string Definition { get; }
        public string Description { get; }

        public Consumption(int ID, int UserID, string Name, decimal Sum, string Currency, DateTime Date, string Definition, string Description)
        {
            this.ID = ID;
            this.UserID = UserID;
            this.Name = Name;
            this.Sum = Sum;
            this.Currency = Currency;
            this.Date = Date;
            this.Definition = Definition;
            this.Description = Description;

            
        }
    }
}