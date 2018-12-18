using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace NewYearTorment
{
    public class AllProducts
    {
        public List<Products> Products { get; set; }


        public void Start()
        {
            
            string json;
            using (var reader = new StreamReader("PresentsJSON.txt"))
            {
                json = reader.ReadToEnd();
            }

            AllProducts allProducts = JsonConvert.DeserializeObject<AllProducts>(json);
            Console.WriteLine("All gifts: \n");
            foreach (var gift in allProducts.Products)
            {
                gift.PrintGifts();
            }

            ForReadability();
            allProducts.InexpensiveGift();
            allProducts.ExpensiveGift();
            allProducts.GiftsFor50Rub();
            allProducts.GiftsFor80Rub();
            allProducts.TotalPrice();
            allProducts.CostUpTo40rub();
            allProducts.PriceOfUpTo25rub();
        }

        public void ForReadability()
        {
            Console.WriteLine("\nPress any Key to continue. \n");
            Console.ReadLine();
        }

        public void InexpensiveGift()
        {
            Console.WriteLine("Inexpensive gift:");
            var inexpensiveGift = Products.OrderBy(x => x.Prices.Price_min.Amount).Take(1);

            foreach (var gift in inexpensiveGift)

            {
                gift.PrintGifts();
            }
            ForReadability();
        }
        public void ExpensiveGift()
        {
            Console.WriteLine("Expensive gift:");
            var mostExpensive = Products.OrderBy(x => x.Prices.Price_min.Amount).Last();

            mostExpensive.PrintGifts();
            ForReadability();
        }

        public void GiftsFor50Rub()
        {
            Console.WriteLine("Inexpensive gifts for 50 rubles:");
            double sum = 0;
            var giftsFor50Rub = Products.OrderBy(x => x.Prices.Price_min.Amount).TakeWhile(x => (sum += x.Prices.Price_min.Amount) <= 50);
            foreach (var gift in giftsFor50Rub)
            {
                gift.PrintGifts();
            }
           
            ForReadability();
        }
        public void GiftsFor80Rub()
        {
            Console.WriteLine("Random gifts for 80 rub:");
            double sum = 0; 
            var sortGifts = Products.OrderBy(n => Guid.NewGuid());
            var giftsFor80Rub = sortGifts.TakeWhile(x => (sum += x.Prices.Price_min.Amount) <= 80);
        
            foreach (var gift in giftsFor80Rub)
            {
                gift.PrintGifts();
               
            }

            ForReadability();
        }

        public void TotalPrice()
        {

            var sum = Products.Sum(x => x.Prices.Price_min.Amount);
            Console.WriteLine($"Total amount {sum};");
            ForReadability();
        }

        public void CostUpTo40rub()
        {
            var sum = Products.Where(x => x.Prices.Price_min.Amount >= 40).Sum(x => x.Prices.Price_min.Amount);
            Console.WriteLine($"How much gifts cost up to 40 rub: {sum} rub");
            ForReadability();
        }

        public void PriceOfUpTo25rub()
        {
            
            Console.WriteLine($"Gifts list with a price of up to 25  :");
            var priceOfUpTo25rub = Products.Where(x => x.Prices.Price_min.Amount <= 25);
            foreach (var gift in priceOfUpTo25rub)
            {
                gift.PrintGifts();
            }
            ForReadability();
        }
    }


}