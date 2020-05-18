using System;
using Summary;
namespace Summary
/* 
 * Summary is a console application to Store Asset & Income Infomation 
 * @author Brandon Dawson
 */
{
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
        private static string center(String input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
            return input;
        }
    }
}



