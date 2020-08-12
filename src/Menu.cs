using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Summary
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-Optional-arguments#Optional-arguments
    //use Optional arguments

    class Menu
    {
        Query dbSql = new Query();
        Data data = new Data();
        Account login = new Account();

        int index;
        int exitConsole = 0;

           List<string> Options = new List<string>() {
            "[X: Guest Login][Q: exit]",
             "sort by [Z: Name][C: Amount][X: Date]",
              "[D: add][E : edit][C: search][F: list][Q: exit]" };

        // List<string> Options = new List<string>() {
        //     "[Z: User Login][C: Create A Account][X: Guest Login][Q: exit]",
        //      "sort by [Z: Name][C: Amount][X: Date]",
        //       "[D: add][E : edit][C: search][F: list][Q: exit]" };
        
        private static string Center(String input)
        {
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
            return input;
        }

        public Menu()
        {
            dbSql.SqlConnect();
            Option();
            Main();
        }

        //Main input menu
        public void Main()
        {
            Console.Write("> ");

            ConsoleKeyInfo keyInMain = Console.ReadKey(false);

            switch (keyInMain.KeyChar.ToString().ToLower())
            {
                // case "z":
                //     Console.WriteLine("\n[Z: User Login]");
                //     login.SignIn();
                //     Console.WriteLine("\n[user: " + login.GetUsername() + "]");
                //     Option(2);
                //     Home();
                //     break;
                // case "c":
                //     Console.WriteLine("\n[C: Create A Account]");
                //     login.SignUp();
                //     Console.WriteLine("\n[user: " + login.GetUsername() + "]");
                //     Option(2);
                //     Home();
                //     break;
                case "x":
                    Console.WriteLine("\n[X: Guest Login]");
                    Option(2);
                    Home();
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
                    Main();
                    break;
            }
            if (keyInMain.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        public int Option(int i = 0)
        {
            index = i;
            Console.WriteLine(Center(Options[index]));
            return index;
        }


        //change, update, or delete this method
        public void Home()
        {
            Console.Write("> ");
            ConsoleKeyInfo keyInHome = Console.ReadKey(false);
            switch (keyInHome.KeyChar.ToString().ToLower())
            {
                case "d":
                    Console.WriteLine("\n[D: Add]");
                    //data entry method
                    data.Add();
                    Console.Clear();
                    Option(2);
                    Home();
                    break;
                case "e":
                    Console.WriteLine("\n[E : edit]");
                    Home();
                    break;
                case "c":
                    Console.WriteLine("\n[C: Search]");
                    Option(1);
                    SearchOptions();
                    break;
                case "f":
                    Console.WriteLine("\n[F: list]\n");
                    dbSql.ListQueries();
                    Option(2);
                    Home();
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
                    Home();
                    break;
            }
            if (keyInHome.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        //change, update, or delete this method
        public void SearchOptions()
        {
            Console.Write("> ");
            ConsoleKeyInfo keyInHome = Console.ReadKey(false);
            switch (keyInHome.KeyChar.ToString().ToLower())
            {
                //name search
                case "z":
                    Console.Write("\n[Z: Search by Name] > ");
                    var searchName = Console.ReadLine();
                    dbSql.ByDataQuery(searchName);
                    Option(2);
                    Home();
                    break;
                case "c":
                    //amount search 
                    Console.Write("\n[X: Search by Amount] > ");
                    var searchTotal = Console.ReadLine();
                    dbSql.ByAmountQuery(searchTotal);
                    Option(2);
                    Home();
                    break;
                case "x":
                    //Date search options
                    Console.Write(Center("Select by day [1], month [2] , or year [3] > "));
                    var select = Console.ReadKey(false);
                    switch (select.KeyChar.ToString())
                    {
                        case "1":
                            Console.Write("\n[C: Search by Day]  > ");
                            break;
                        case "2":
                            Console.Write("\n[C: Search by Month]  > ");
                            break;
                        case "3":
                            Console.Write("\n[C: Search by Year]  > ");
                            break;
                        default:
                            Console.Write("\n[C: Search by Date]  > ");
                            break;
                    }
                    //date search
                    var search = Console.ReadLine();
                    dbSql.ByDateQuery(select, search);
                    Option(2);
                    Home();
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
                    Home();
                    break;
            }
            if (keyInHome.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}