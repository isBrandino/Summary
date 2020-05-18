using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Summary
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments
    //use optional arguments

    //limit length of data entered(50 for char) && (200 - for description)
    class Menu
    {
        Db dbSql = new Db();
        Data data = new Data();
        Login login = new Login();

        int index;
        int exitConsole = 0;
        
        List<string> options = new List<string>() {
            "[Z: User Login][C: Create A Account][X: Guest Login][Q: exit]",
             "[Z: account][C: display][X: layout]",
              "[D: add][E : edit][C: count][F: list][Q: exit]" };
        public Menu()
        {
            dbSql.sqlConnect();
            option();
            main();
        }

        //fix me :) FIX ME :))
        private async Task<ConsoleKeyInfo> GetInputAsync()
        {
            return await Task.Run(() => Console.ReadKey(false));
        }

        private static string center(String input)
        {
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
            return input;
        }

        //main input menu
        public void main()
        {
            Console.Write("> ");

            ConsoleKeyInfo keyInMain = Console.ReadKey(false);
            //try making input ascychous 

            switch (keyInMain.KeyChar.ToString().ToLower())
            {
                case "z":
                    Console.WriteLine("\n[Z: User Login]");
                    login.signIn();
                    Console.WriteLine("\n[user: " + login.getUsername() + "]");
                    option(2);
                    home();
                    break;
                case "c":
                    Console.WriteLine("\n[C: Create A Account]");
                    login.signUp();
                    Console.WriteLine("\n[user: " + login.getUsername() + "]");
                    option(2);
                    home();
                    break;
                case "x":
                    Console.WriteLine("\n[X: Guest Login]");
                    option(2);
                    home();
                    break;
                case "q":
                    Console.WriteLine("\n[Exiting]");
                    Environment.Exit(0);
                    break;
                default:
                    exitConsole++;
                    Console.Write("\t" + "[input not valid]" + "\n");
                    if (exitConsole >= 20)
                    {
                        Environment.Exit(0);
                    }
                    main();
                    break;
            }
            if (keyInMain.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        public int option(int i = 0)
        {
            index = i;
            Console.WriteLine(center(options[index]));
            return index;
        }


        //change, update, or delete this method
        public void home()
        {
            Console.Write("> ");
            ConsoleKeyInfo keyInHome = Console.ReadKey(false);
            switch (keyInHome.KeyChar.ToString().ToLower())
            {
                case "d":
                    Console.WriteLine("\n[D: add]");
                    //data entry method
                    data.add();
                    Console.Clear();
                    option(2);
                    home();
                    break;
                case "e":
                    Console.WriteLine("\n[E : edit]");
                    home();
                    break;
                case "c":
                    Console.WriteLine("\n[C: count]");
                    option(2);
                    home();
                    break;
                case "f":
                    Console.WriteLine("\n[F: list]");
                    home();
                    break;
                case "q":
                    Console.WriteLine("\n[Exiting]");
                    Environment.Exit(0);
                    break;
                default:
                    exitConsole++;
                    Console.Write("\t" + "[input not valid]" + "\n");
                    if (exitConsole >= 20)
                    {
                        Environment.Exit(0);
                    }
                    home();
                    break;
            }
            if (keyInHome.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}