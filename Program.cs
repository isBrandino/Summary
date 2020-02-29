using System;
using Summary;
namespace Summary
{
    /* Summary is a website to Manage and list Income Infomation*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(center("Welcome to Summary"));
            Console.ResetColor();
            Menu Summary = new Menu();
        }
        //centers text in the terminal
        public static string center(String input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
            return input;
        }
    }
}



