using System;
using System.Collections.Generic;

//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments
//use optional arguments 
namespace Summary{    
    class Data{  
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        
        private List<Data> dataList = new List<Data>();
        
        //sets unquire value for each input
        public Data(){
    
        }
        
        //store name amount and date
        public Data(String name, decimal amount, DateTime date, string details){
            Console.WriteLine("data");
            this.Name = name;
            this.Amount = amount;
            this.Date = date;
            this.Details = Details;
        }
        
        //method displays total balance 
        public void Balance(int balanceID,String balaceName, double total,string details){
            Console.WriteLine("balance");
            foreach (var item in dataList){

            }        
        }

        public string add(String Name = "Guest", double Amount = 0.00 , string Details = ""){
            Console.Write("[Balance Name/Type] >"); 
            Name = Console.ReadLine();
            
            Console.Write("[Amount] >");
            //total = Convert.ToDouble(Console.ReadLine());
            if(!double.TryParse(Console.ReadLine(), out Amount)){
                
                Console.WriteLine("not a number");
                Amount = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("[Details] >");
            Details = Console.ReadLine(); 
            Console.WriteLine($"Added: {Amount} to {Name}," +"\n" + $"{Details}");
            return ($"The total for {Name}, is: {Amount}" +"/n" + $"{Details}");
        }
    }
}