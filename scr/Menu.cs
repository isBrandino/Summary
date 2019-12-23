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
      Console.WriteLine("\t[Z: User Login][C: Create A Account][X: Guest Login]");   
         input();   
      }
      private ConsoleKeyInfo input(){  
            ConsoleKeyInfo input = Console.ReadKey();
            return input;
      }
      private Menu(string input){
         
      }
   }
}