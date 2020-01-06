using System;

namespace Task2.Polynomials.Utils
{
    public static class ConsoleManager
    {
        public static void WriteLine(Polynomial polynomial, string title = "", bool newBeginLine = true)
        {
            if (newBeginLine)
            {
                Console.WriteLine("\n");
            }

            Console.WriteLine(title);

            Console.Write(polynomial[0]);
            for (int i = 1, power = polynomial.Power; i <= power; ++i)
            {
                Console.Write(" + " + polynomial[i] + "x^" + i);
            }
        }
    }
}