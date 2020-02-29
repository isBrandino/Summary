using System;
namespace Summary
{
class Login{
  private Data data; 
  public string username { get; set; }
  private string password { get; set; }



    public Login () {
       
  }

    private string verification { get; set; }
    private bool verfied;
    public void login (String UserName, String PassWord , bool verfied){
      this.username = username;
      this.password = password;
    }
    public void signUp(String username, String password, String verification){
      this.username = username;
      this.password = password;
      this.verification = verification;

      if(password == verification){
        signUp(true);
      }else{
        signUp(false);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Passwords do not match");
        Console.ResetColor();
      }
    }

    public bool signUp(Boolean valid){
      return valid;
    }
    public int intID(int id){
      return id;
    }

    private void signIn(String username, String password){
      this.username = username;
      this.password = password;
    }
  }
}
