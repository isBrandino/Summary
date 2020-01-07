using System;
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
        // public enum selecion { add, edit, list, count };
        // public enum user { logon, logout, create };
        // public enum settings { display, account, layout };
        int index;
        List<string> options = new List<string>() { "[Z: User Login][C: Create A Account][X: Guest Login]", "[Z: account][C: display][X: layout]", "[D: add][E : edit][C: count][F: list]" };
        public Menu()
        {
            option();
            main();
        }

        public void main()
        {
            Console.Write("> ");
            ConsoleKeyInfo keyInMain = Console.ReadKey(false);
            switch (keyInMain.KeyChar.ToString())
            {
                case "z":
                    Console.WriteLine("\n[Z: User Login]");
                    break;
                case "c":
                    Console.WriteLine("\n[C: Create A Account]");
                    break;
                case "x":
                    Console.WriteLine("\n[X: Guest Login]");
                    option(2);
                    home();
                    break;
                default:
                    Console.Write("\t" + "[input not valid]" + "\n");
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
        public static string center(String input)
        {
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
            return input;
        }

        public void home()
        {
            Console.Write("> ");
            ConsoleKeyInfo keyInHome = Console.ReadKey(false);
            switch (keyInHome.KeyChar.ToString())
            {
               case "d":
                    Console.WriteLine("\n[D: add]");
                    data.add();
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
                default:
                    Console.Write("\t" + "[input not valid]" + "\n");
                    main();
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
