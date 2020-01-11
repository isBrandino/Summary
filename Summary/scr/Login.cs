using System;
namespace Summary
{
class Login{
  private Data data;
  public string username { get; set; }
  private string password { get; set; }
   public Login () {

    }
    public void login (String UserName, String PassWord){
      this.username = username;
      this.password = password;
    }
    private string verify { get; set; }
    public void signUp(String username, String password, String verify){
      this.username = username;
      this.password = password;
      this.verify = verify;

      if(password == verify){
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


    private void signIn(String username, String password){
      this.username = username;
      this.password = password;
    }
  }
}
