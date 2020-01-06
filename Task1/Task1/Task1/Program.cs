using System;
using Task1.Matrices;
using Task1.Matrices.Utils;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mfs = new MatrixFileSerializer("file.txt");
            var a = new Matrix(3, 2) { [1, 1] = 1, [1, 2] = -1, [2, 1] = 2, [3, 1] = 3 };
            var b = new Matrix(2, 2) { [1, 1] = 1, [1, 2] = 1, [2, 1] = 2 };
            var c = new Matrix(2, 2) { [1, 1] = 4, [1, 2] = 2, [2, 1] = 7, [2, 2] = 5 };
            
            ConsoleManager.WriteLine(a, "A: ");
            ConsoleManager.WriteLine(b, "B:");
            ConsoleManager.WriteLine(c, "C:");
            ConsoleManager.WriteLine(a * b, "A * B:");
            ConsoleManager.WriteLine(b + c, "B + C:");
            ConsoleManager.WriteLine(b - c, "B - C:");
            ConsoleManager.WriteLine(c - b, "C - B:");
            ConsoleManager.WriteLine(a * 2, "A * 2:");

            mfs.Serialize(a);
            ConsoleManager.WriteLine(mfs.Deserialize(), "Deserialized A:");

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
