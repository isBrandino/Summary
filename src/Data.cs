using System;
using System.Collections.Generic;
using System.Data.SQLite;
// https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0

namespace Summary
{
    class Data
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }

        private List<Data> dataList = new List<Data>();

        //sets unquire value for each input
        public Data()
        {

        }
        //add validation methods here
        public string add(String Name = "Guest", double Amount = 0.00, string Details = "")
        {
            Console.Write("[Balance Name/Type] > ");
            Name = Console.ReadLine();
            
            Amount = voidSetAmount(Amount);

            Console.Write("[Details] > ");
            Details = Console.ReadLine();
            
            Console.WriteLine($"Added: {Amount} to {Name}," + "\n" + $"{Details}" + " on " + dateInput());

            //pass data to database && list        
            loginData(Name,Convert.ToDouble(Amount),Date,Details);
            return ($"The total for {Name}, is: ${Amount}" + "/n" + $"{Details}" + $"{Date}");
        }
        public double voidSetAmount(double Amount){
        Console.Write("[Amount] > ");
            //total = Convert.ToDouble(Console.ReadLine());
            if (!double.TryParse(Console.ReadLine(), out Amount))
            {

                Console.WriteLine("not a number! Try Again.");
                voidSetAmount(Amount);
            }
            return Amount;
        }

        //add test methods here
        public void loginData(String name, double amount, DateTime date, string details)
        {
            Console.WriteLine("logindata = " +$"{name} {amount} {date} {details}");
            this.Name = name;
            this.Amount = amount;
            this.Date = date;
            this.Details = Details;
            
            //write method to pass data to database here
            
        }

        public void edit()
        {
	
        }

	//validate so user has to enter a number(or string)
        public DateTime dateInput(){
            
            Console.Write("Enter a month: > ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: > ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: > ");
            int year = int.Parse(Console.ReadLine());
            DateTime Date = new DateTime(year, month, day);
            return Date;
        }

        public void remove()
        {

        }

	//method displays total balance 
        public void Balance(int balanceID, String balaceName, double total, string details)
        {
            Console.WriteLine("balance");
            foreach (var item in dataList)
            {

            }
        }

    }
}
