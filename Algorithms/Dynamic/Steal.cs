using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Dynamic
{
    public class Steal
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }

        public Steal(string name, int weight, int price)
        {
            Name = name;
            Weight = weight;
            Price = price;
        }
    }
}
