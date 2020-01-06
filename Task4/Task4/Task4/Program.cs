using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new ArbitraryArray<int>(-2, 3) {[-2] = 5, [-1] = 10, [0] = 3, [1] = 9, [2] = 11, [3] = 4};

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
