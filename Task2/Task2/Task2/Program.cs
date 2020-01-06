using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Polynomials;
using Task2.Polynomials.Utils;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Polynomial(2) { [0] = 2, [1] = 5, [2] = 90 };
            var p2 = new Polynomial(3) { [0] = 3, [1] = 1, [2] = 2, [3] = 10 };
            
            ConsoleManager.WriteLine(p1, "P1:");
            ConsoleManager.WriteLine(p2, "P2");

            ConsoleManager.WriteLine(p1 + p2, "P1 + P2:");
            ConsoleManager.WriteLine(p1 - p2, "P1 - P2:");
            ConsoleManager.WriteLine(p2 - p1, "P2 - P1:");
            ConsoleManager.WriteLine(p1 * p2, "P1 * P2:");

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
