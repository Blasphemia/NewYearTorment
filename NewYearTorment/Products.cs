using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearTorment
{
    public partial class Products
    {
        public string Name_prefix { get; set; }
        public Price Prices { get; set; }
        

        public void PrintGifts()

        {
            Console.WriteLine($"{Name_prefix} : { Prices.Price_min.Amount} rub");

        }


    }
}