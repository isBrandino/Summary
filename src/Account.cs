using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Summary
{
    class Account
    {
        Query query = new Query();
        Validate verify = new Validate();
        private Data data;
        private bool verfied;
        private string Password { get; set; }
        
        private static string Center(String input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
            return input;
        }
        
        public string Username { get; set; }
        
        //use password salt and hash
        public Account()
        {

        }
        //make sure username has at least one char
        //or is username is blank == "";
        public bool SignIn()
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

        public bool SignUp()
        {
            Console.Write("\n" + "[username] > ");
            Username = Console.ReadLine();
            Password = null;
            void enterPassword()
            {
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    Password += key.KeyChar;
                }
            }

            Console.Write("[password] > ");
            enterPassword();

            Console.WriteLine(Center("[Make this your password? (y,N)]"));
            Console.ResetColor();
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (key.Key == ConsoleKey.Y)
                    break;
                if (key.Key == ConsoleKey.N)
                    Console.Write("[password] > ");
                Password += key.KeyChar;
            }
            query.AddUser(Username, Password);
            return true;
        }

        public string GetUsername()
        {
            return Username;
        }

    }
    public class HashSalt
    {
        public string Hash { get; set; }
        public string Salt { get; set; }

        public HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
}