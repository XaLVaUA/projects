using System;
using Task3_Core.BinaryTrees;

namespace Task3_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberTree = new BinaryTree<int>
            {
                10, 7, 18, 2, 6, 3, 9, 4, 13, 34, 8, 11
            };

            foreach (var item in numberTree.OutOrder)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------");

            numberTree.Remove(13);

            foreach (var item in numberTree.OutOrder)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------");

            var tree = new BinaryTree<StudentTestInfo>()
            {
                new StudentTestInfo("Eduard", "Morgun", "OOP1", new DateTime(2019, 10, 1), 9),
                new StudentTestInfo("Vitalij", "Klimov", "OOP1", new DateTime(2019, 10, 1), 8),
                new StudentTestInfo("Bob", "Diss", "OOP1", new DateTime(2019, 10, 1), 3),
                new StudentTestInfo("Sasha", "Bolshoi", "OOP1", new DateTime(2019, 10, 3), 9),
                new StudentTestInfo("Andrij", "Bogdan", "OOP1", new DateTime(2019, 10, 4), 7),
                new StudentTestInfo("Eduard", "Morgun", "OOP2", new DateTime(2019, 11, 1), 5),
                new StudentTestInfo("Vitalij", "Klimov", "OOP2", new DateTime(2019, 11, 2), 8),
                new StudentTestInfo("Bob", "Diss", "OOP2", new DateTime(2019, 11, 5), 3),
                new StudentTestInfo("Sasha", "Bolshoi", "OOP2", new DateTime(2019, 11, 3), 9),
                new StudentTestInfo("Andrij", "Bogdan", "OOP2", new DateTime(2019, 11, 4), 7),
                new StudentTestInfo("Eduard", "Morgun", "Math", new DateTime(2019, 10, 20), 5),
                new StudentTestInfo("Vitalij", "Klimov", "Math", new DateTime(2019, 11, 3), 8),
                new StudentTestInfo("Bob", "Diss", "Math", new DateTime(2019, 11, 1), 3),
                new StudentTestInfo("Sasha", "Bolshoi", "Math", new DateTime(2019, 11, 2), 9),
                new StudentTestInfo("Andrij", "Bogdan", "Math", new DateTime(2019, 10, 23), 7)
            };

            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
