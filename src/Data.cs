using System;
using System.Collections.Generic;
using System.Data.SQLite;
// https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0

namespace Summary
{
    class Data
    {
        Db dbSql = new Db();

        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        int exit = 0;

        List<String> schema = new List<String>(); 
        Validate verify = new Validate();
        //sets unquire value for each input
        public Data()
        {
            
        }

        //add validation methods here
        public void add()
        {
            Console.Write("[Balance Name/Type] > ");
            Name = Console.ReadLine();

            Amount = voidSetAmount(Amount);
            
            Console.Write("[Details] > ");
            Details = Console.ReadLine();
            
            Console.WriteLine($"Added: {Amount} to {Name}," + "\n" + $"{Details}" + " on " + dateInput());
            //pass data to database && list        
            loginData(Name,Convert.ToDouble(Amount),Date, Details);
            //return ($"The total for {Name}, is: ${Amount}" + "/n" + $"{Details}" + $"{Date}");
        }
        
        public double voidSetAmount(double Amount){
            	Console.Write("[Amount] > ");
            if (!double.TryParse(Console.ReadLine(), out Amount))
            {
                Console.WriteLine("not a number! Try Again.");
                voidSetAmount(Amount);
            }
            return Amount;
        }

    	//error when no data is entered
        public DateTime dateInput(){
           Console.Write("Enter a day: > ");
                int day = int.Parse(Console.ReadLine());

            Console.Write("Enter a month: > ");
                int month = int.Parse(Console.ReadLine());

            Console.Write("Enter a year: > ");
                int year = int.Parse(Console.ReadLine());

            bool valid = verify.dateTimeValidate(year, month, day);
            if(valid  == true){
                Date = new DateTime(year, month, day);
                return Date;
             }else{
                Console.WriteLine("Invalid Date! Please Try Again");
                if(exit < 7){
                    dateInput();
                }
                exit++;
             }
            return Date;
        }

        //add test methods here
        public void loginData(String name, double amount, DateTime date, string details)
        {
            
            this.Name = name;
            this.Amount = amount;
            this.Date = date;
            this.Details = Details;
            Console.WriteLine("\nlogindata = " +$"{Name} {Amount} {Date} {Details}");
            //write method to pass data to database here
            
        }

        public void edit(){
	
        }

        public void remove()
        {

        }

	    //method displays total balance 
        public void Balance(int balanceID, String balaceName, double total, string details)
        {
            Console.WriteLine("balance");
            foreach (var item in schema)
            {

            }
        }
    }
}
