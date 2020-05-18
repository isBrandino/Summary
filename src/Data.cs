using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data.SQLite;
// https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0

namespace Summary
{
    class Data
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }

        //hash map search with key(ID)
        Query query = new Query();
        Validate verify = new Validate();
        int exit = 0;

        public Data()
        {

        }

        public void add()
        {
            Console.Write("[Balance Name/Type] > ");
            Name = Console.ReadLine();
            Amount = voidSetAmount(Amount);
            Console.Write("[Details] > ");
            Details = Console.ReadLine();
            dateInput();

            //pass data to database && list        
            addData(Name, Convert.ToDouble(Amount), Date, Details);
            //return ($"The total for {Name}, is: ${Amount}" + "/n" + $"{Details}" + $"{Date}");
        }

        public double voidSetAmount(double Amount)
        {
            Console.Write("[Amount] > ");
            if (!double.TryParse(Console.ReadLine(), out Amount))
            {
                Console.WriteLine("not a number! Try Again.");
                return voidSetAmount(Amount);
            }
            return Amount;
        }

        //error when no data is entered
        //!! FIND BETTER SOLUTION IF POSSIBLE !!
        public DateTime dateInput()
        {
            try
            {
                Console.Write("Enter a day: > ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Enter a month: > ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Enter a year: > ");
                int year = int.Parse(Console.ReadLine());
                
                bool valid = verify.dateTimeValidate(year, month, day);

                if (valid == true)
                {
                    Date = new DateTime(year, month, day);
                    return Date;
                }
                else
                {
                    Console.WriteLine("Invalid Date! Please Try Again");
                    if (exit < 5)
                    {
                        dateInput();
                    }
                    exit++;
                }
                return Date;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Date! Please Try Again");
                if (exit < 5)
                {
                    dateInput();
                }
                exit++;
            }
            return Date;
        }

        //add test methods here
        public void addData(String name, double amount, DateTime date, string details)
        {
            this.Name = name;
            this.Amount = amount;
            this.Date = date;
            this.Details = Details;

            Console.WriteLine(saved($"\nName: {Name} "
            + $"\nAmount: {Amount}" + $"\nDate: {Date.Day}/{Date.Month}/{Date.Year}"
            + $"\nDetails: {Details}"));
            Console.ResetColor();
            //write method to pass data to database here
            
            //query.addData(Name,Amount,Details);
            //query.addDate(Date.Day,Date.Month,Date.Year);
        }

        //concat date info to fit database 
        private string strdateFormat()
        {
            return null;
        }

        private static string saved(String input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return input;
        }
    }
}