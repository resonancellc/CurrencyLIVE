using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLIVE
{
    public class CurrencyRate
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public CurrencyRate(DateTime date, string name, decimal value)
        {
            this.Date = date;
            this.Name = name;
            this.Value = value;
        }
    }
}
