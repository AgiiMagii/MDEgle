using System;
namespace MDEgle
{
    internal class Program
    {
        static int width;
        static int heigh;
        static void Main(string[] args)
        {
            width = GetUserInput(" Set the picture width!", " (choose an integer 7 or above)");
            heigh = GetUserInput(" Set the picture heigh!", " (choose an integer 7 or above)");
            Console.Clear();
            char[,] Patterns = new char[heigh, width];
            for (int i = 0; i < heigh; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Patterns[i, j] = '.';
                }
            }
            int tree = width / 2;
            for (int i = 0; i < heigh; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j >= tree - i && j <= tree + i && i < heigh / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('^' + " ");
                        Console.ResetColor();
                    }
                    else if (j >= tree - 1 && j <= tree + 1 && i >= heigh / 2 && i < heigh - 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write('|' + " ");
                        Console.ResetColor();
                    }
                    else if (i >= heigh - 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('^' + " ");
                        Console.ResetColor();
                    }
                    else Console.Write($"{Patterns[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static int GetUserInput(string message1, string message2)
        {
            int value;
            bool result;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(message1);
                Console.ResetColor();
                Console.WriteLine(message2);
                string input = Console.ReadLine();
                result = int.TryParse(input, out value);
                if (!result || value < 7)
                {
                    Console.WriteLine(" False input! Try again!");
                }
            }
            while (!result || value < 7);
            return value;
        }
    }
}

