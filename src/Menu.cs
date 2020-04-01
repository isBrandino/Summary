using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Summary
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments
    //use optional arguments
    class Menu
    {
        Login login = new Login();
        Data data = new Data();
        Db dbSql = new Db();
        //Array[] temp = new Array[]();
        int index;
        int exitConsole = 0;
        List<string> options = new List<string>() { "[Z: User Login][C: Create A Account][X: Guest Login][Q: exit]", "[Z: account][C: display][X: layout]", "[D: add][E : edit][C: count][F: list][Q: exit]" };
        public Menu()
        {
            dbSql.sqlConnect();
            option();
            main();
        }
        //fix me :)
        private async Task<ConsoleKeyInfo> GetInputAsync()
        {
            return await Task.Run(() => Console.ReadKey(false));
        }
        public static string center(String input)
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
            //Console.keyInMain = GetInputAsync();

            switch (keyInMain.KeyChar.ToString())
            {
                case "z":
                    Console.Clear();
                    Console.WriteLine("\n[Z: User Login]");
                    login.signIn();
                    break;
                case "c":
                    Console.Clear();
                    Console.WriteLine("\n[C: Create A Account]");
                    login.signUp();
                    break;
                case "x":
                    Console.Clear();
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
                    if(exitConsole >= 20){
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
            switch (keyInHome.KeyChar.ToString())
            {
                case "d":
                    Console.WriteLine("\n[D: add]");
                    //data entry method
                        data.add();
                    Console.Clear();
                        option(2);
                    //add temp storage display of added entries make is get info from data class
                        home();
                    break;
                case "e":
                    Console.WriteLine("\n[E : edit]");
                    break;
                case "c":
                    Console.WriteLine("\n[C: count]");
                        option(2);
                    break;
                case "f":
                    Console.WriteLine("\n[F: list]");
                    break;
                case "q":
                  Console.WriteLine("\n[Exiting]");
                    Environment.Exit(0);
                    break;
                default:
                    exitConsole++;
                    Console.Write("\t" + "[input not valid]" + "\n");
                    if(exitConsole >= 20){
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
/*
       Console.WriteLine(center("[Z: account][C: display][X: layout]"));  
       Console.WriteLine(center("[D: add][E : edit][C: count][F: list]"));  
 */
