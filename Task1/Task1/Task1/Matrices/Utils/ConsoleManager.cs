using System;

namespace Task1.Matrices.Utils
{
    public static class ConsoleManager
    {
        public static void WriteLine(Matrix matrix, string title = "", bool newBeginLine = true)
        {
            if (newBeginLine)
            {
                Console.WriteLine("\n");
            }

            Console.WriteLine(title);
            for (int i = 1, n = matrix.Rows; i <= n; ++i)
            {
                for (int j = 1, m = matrix.Cols; j <= m; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}