using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cost_Control.Models
{
    //Категория доходов
    public class IncomeCategory : ConsumptionCategory
    {
        public IncomeCategory(int ID, string Name) : base(ID, Name)
        {
        }
    }
}