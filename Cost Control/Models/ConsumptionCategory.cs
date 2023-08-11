using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cost_Control.Models
{
    //Категория расходов
    public class ConsumptionCategory
    {
        public int ID { get; }
        public string Name { get; }

        public ConsumptionCategory(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}