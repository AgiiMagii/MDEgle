using System;
using System.Collections.Generic;
namespace MDEgle
{
    internal class Program
    {
        static int width;
        static int height;
        static string crownColor = "Green";
        static string trunkColor = "Gray";
        static string groundColor = "Green";
        static string backgroundColor = "White";
        static List<string> colors = new List<string> { "Black", "Blue", "Cyan", "DarkBlue", "DarkCyan", "DarkGray", "DarkGreen", "DarkMagenta", "DarkRed", "DarkYellow", "Gray", "Green", "Magenta", "Red", "White", "Yellow" };
        static void Main(string[] args)
        {
            height = GetUserInput(" Set the picture size!", " (choose an integer 7 or above)");
            width = height + 1;
            Console.WriteLine(string.Join(", ", colors));
            crownColor = GetColorInput(" Set the crown color! (choose from the list below)", crownColor);
            trunkColor = GetColorInput(" Set the trunk color! (choose from the list below)", trunkColor);
            groundColor = GetColorInput(" Set the ground color! (choose from the list below)", groundColor);
            backgroundColor = GetColorInput(" Set the background color! (choose from the list below)", backgroundColor);
            Console.Clear();
            DrawTree();
            Console.ReadLine();
        }
        static void DrawTree()
        {
            int tree = width / 2;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    char symbol = '.';
                    string color = backgroundColor;

                    if (j >= tree - i && j <= tree + i && i < height / 2)
                    {
                        symbol = '^';
                        color = crownColor;
                    }
                    else if (j >= tree - 1 && j <= tree + 1 && i >= height / 2 && i < height - 3)
                    {
                        symbol = '|';
                        color = trunkColor;
                    }
                    else if (i >= height - 3)
                    {
                        symbol = '^';
                        color = groundColor;
                    }

                    PrintWithColor(symbol, color);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static int GetUserInput(string message1, string message2) //Get user input for the size of the picture, validate it and return the value, if the input is invalid, ask the user to try again
        {
            int value;
            bool result;
            do
            {
                PrintWithColor($"{message1}\n", "Cyan");
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
        static string GetColorInput(string message, string defaultColor) //Get color input from user, validate it and return the color, if the user presses Enter, return the default color
        {
            string color;
            bool isValidColor;

            do
            {
                PrintWithColor($"{message} (press Enter for default: {defaultColor})\n", "Cyan");
                color = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(color))
                    return defaultColor;

                isValidColor = colors.Contains(color);

                if (!isValidColor)
                {
                    Console.WriteLine("False input! Try again!");
                }
            }
            while (!isValidColor);

            return color;
        }
        static void PrintWithColor(object value, string color = "White") //Print text in specified color, default is white
        {
            if (!Enum.TryParse(color, true, out ConsoleColor consoleColor))
            {
                consoleColor = ConsoleColor.White;
            }
            Console.ForegroundColor = consoleColor;

            Console.Write(value);
            Console.ResetColor();
        }
    }
}

