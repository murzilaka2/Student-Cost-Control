using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cost_Control.Models
{
    //Доходы
    public class Income : Consumption
    {
        public Income(int ID, int UserID, string Name, decimal Sum, string Currency, DateTime Date, string Definition, string Description) : base(ID, UserID, Name, Sum, Currency, Date, Definition, Description)
        {
        }
    }
}