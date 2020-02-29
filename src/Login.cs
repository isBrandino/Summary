using System;
using System.Collections.Generic;

namespace Summary
{
class Login{
  private Data data;
  private Dictionary<string, string> Credentials = new Dictionary<string, string>(); 
  public string username { get; set; }
  private string password { get; set; }
  private string verification { get; set; }
  private bool verfied;
 
//use password salt and hash
  public Login (){
        Credentials.Add("bob", "password1");
        Credentials.Add("alice", "password2");  
  }
  public int intID(int id){
      return id;
  }
  }
}
