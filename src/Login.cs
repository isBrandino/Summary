using System;
using System.Collections.Generic;

namespace Summary
{
    class Login
    {
        Query loginQuery = new Query();
        private Data data;

        private Dictionary<string, string> Credentials = new Dictionary<string, string>();
        
        public string Username { get; set; }
        private string Password { get; set; }
        
        private bool verfied;

        //use password salt and hash
        public Login()
        {
            
        }

        public bool signIn()
        {
            //query.getUserQuery(Username,Password);
            Console.Write("\n" + "[username] > ");
            Username = Console.ReadLine();

            Console.Write("[password] > ");
            Password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                Password += key.KeyChar;
            }
            return true;
        }

        public bool signUp()
        {
            Console.Write("\n" + "[username] > ");
            Username = Console.ReadLine();

            Console.Write("[password] > ");
            Password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                Password += key.KeyChar;
            }
            //query.addUser(Username,Password);
            return true;
        }

        public string getUsername()
        {
            return Username;
        }


        private string strID(string id)
        {
            return id;
        }
    }
}