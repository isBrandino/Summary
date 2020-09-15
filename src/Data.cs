using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data.SQLite;
// https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0

namespace Summary
{
    class Data
    {
        private static string Saved(String input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return input;
        }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        
        Query query = new Query();
        Validate verify = new Validate();
        int exit = 0;

        public Data()
        {

        }

        public void Add()
        {
            Console.Write("[Balance Name/Type] > ");
            Name = Console.ReadLine();
            Amount = VoidSetAmount(Amount);
            Console.Write("[Details] > ");
            Details = Console.ReadLine();
            DateInput();

            //pass data to database && list        
            AddData(Name, Convert.ToDouble(Amount), Date, Details);
        }

        public double VoidSetAmount(double Amount)
        {
            Console.Write("[Amount] > ");
            if (!double.TryParse(Console.ReadLine(), out Amount))
            {
                Console.WriteLine("not a number! Try Again.");
                return VoidSetAmount(Amount);
            }
            return Amount;
        }

        //error when no data is entered
        //!! FIND BETTER SOLUTION IF POSSIBLE !!
        public DateTime DateInput()
        {
            try
            {
                Console.Write("Enter a month: > ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Enter a day: > ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Enter a year: > ");
                int year = int.Parse(Console.ReadLine());
                
                bool valid = verify.DateTimeValidate(year, month, day);

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
                        DateInput();
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
                    DateInput();
                }
                exit++;
            }
            return Date;
        }
        
        //creates a query to add data
        public void AddData(String name, double amount, DateTime date, string details)
        {
            this.Name = name;
            this.Amount = amount;
            this.Date = date;
            this.Details = Details;

            Console.WriteLine(Saved($"\nName: {Name} "
                + $"\nAmount: {Amount}" + $"\nDate: {Date.Month}/{Date.Day}/{Date.Year}"
                + $"\nDetails: {Details}"));
            Console.ResetColor();
            //write method to pass data to database here        
            query.AddData(Name,Amount,Details);
            query.AddDate(Date);
        }
    }
}