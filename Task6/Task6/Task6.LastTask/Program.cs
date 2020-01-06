using System;
using System.Net;

namespace Task6.LastTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskService = new TaskService();
            Console.WriteLine("\nSync");
            taskService.DoSync();
            Console.WriteLine("\nAsync");
            taskService.DoAsync();
            Console.ReadLine();
        }
    }
}
