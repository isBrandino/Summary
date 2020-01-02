using System;
using System.Collections.Generic;

//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments
//use optional arguments 
namespace Summary{    
    class Data{  
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Details { get; }
        public string Name { get; }
        
        private List<Data> dataList = new List<Data>();
        
        //sets unquire value for each input
        public Data(Dictionary<string, string> dataDictonary){
            Console.WriteLine("data dictonary");
            dataDictonary = new Dictionary<string, string>()
            {
                ["Doyle, Arthur Conan"] = "Hound of the Baskervilles, The",
                ["London, Jack"] = "Call of the Wild, The",
                ["Shakespeare, William"] = "Tempest, The"
            };
        }
        
        //store name amount and date
        public Data(String name, decimal amount, DateTime date, string Details){
            Console.WriteLine("data");
            this.Name = name;
            this.Amount = amount;
            this.Date = date;
            this.Details = Details;
        }
        
        //method displays total balance 
        public void Balance(int balanceID,String balaceName, double total,string Details){
            Console.WriteLine("balance");
            foreach (var item in dataList){

            }        
        }
    }
}
