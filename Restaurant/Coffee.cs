using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, double caffeine) 
            : base(name, 3.50m, 50)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
