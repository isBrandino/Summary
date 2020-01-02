using System;
using System.Collections.Generic;
using System.Linq;
namespace Summary{
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments
//use optional arguments
   class Menu{
      private Login login;
      private Data data;
      public enum selecion { add , edit, list, count };
      public enum user { logon , logout, create };
      public enum settings { display, account, layout };
      ConsoleKeyInfo keyIn;
      public Menu() {
      Console.WriteLine(center("[Z: User Login][C: Create A Account][X: Guest Login]"));   
         input();
      }

      public void input(){  
         Console.Write("> ");
            keyIn = Console.ReadKey(false);
            switch(keyIn.KeyChar.ToString()){
               case "z":
               Console.WriteLine("\n[login]");
               break;
               case "c":
               Console.WriteLine("\n[create]");
               break;
               case "x":
               Console.WriteLine("\n[guest]");
               break;
               default:
               Console.Write("\t" + "[input not valid]" + "\n");
               input();
               break;
            }if(keyIn.Key == ConsoleKey.Escape){   
               Environment.Exit(0);
         }
      }

      //change, update, or delete this method
      public static string center(String input){
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
         return input;
      }
   }
}

  /*
         Console.WriteLine(center("[Z: account][C: display][X: layout]"));  
         Console.WriteLine(center("[D: add][E : edit][C: count][F: list]"));  
   */
