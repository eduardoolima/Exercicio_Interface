using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exFixInterface.Entities
{
    class Installment
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public Installment() 
        {}

        public Installment(DateTime date, double amount)
        {
            Date = date;
            Amount = amount;
        }

        public override string ToString()
        {
            return Date.ToString("dd/MM/yyyy") + " - " + Amount.ToString("F");
        }
    }
}
