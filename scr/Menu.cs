using System;
using System.Collections.Generic;
using System.Linq;
namespace Summary{
    
   class Menu{
      private Login login;
      private Data data;

      public enum selecion { add , edit, list, count };
      public enum user { login , logout, create };
      public enum settings { display , account, layout };
      public Menu() {
      Console.WriteLine(center("[Z: User Login][C: Create A Account][X: Guest Login]"));   
         input();
         /*
         case break statment calling create login or guest method
         */
      }
      private ConsoleKeyInfo input(){  
         Console.Write("> ");
            ConsoleKeyInfo input = Console.ReadKey();
            return input;
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