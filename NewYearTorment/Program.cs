using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace NewYearTorment
{
    public class Program

    {
        static void Main(string[] args)
        {
            var start = new AllProducts();
            start.Start();
            
            Console.ReadLine();

        }
    }
}