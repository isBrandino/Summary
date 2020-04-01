using System;
using System.Collections.Generic;

namespace Summary
{
class Login{
  private Data data;
  private Dictionary<string, string> Credentials = new Dictionary<string, string>(); 
  public string Username { get; set; }
  private string Password { get; set; }
  private bool verfied;
 
    //use password salt and hash
    public Login()
    {
      Credentials.Add("bob", "password1");
      Credentials.Add("alice", "password2");  
    }

    public bool signIn()
    {
          Console.Write("\n" + "[username] > ");
          Username = Console.ReadLine(); 
          Console.Write("[password] > ");
          Password = Console.ReadLine();
          return true;
    }
    
    public bool signUp()
    {
          Console.Write("\n" + "[username] > ");
          Username = Console.ReadLine(); 
          Console.Write("[password] > ");
          Password = Console.ReadLine();
          return true;
    }

    private int intID(int id)
    {
      return id;
    }
  }
}
