using System;
using System.Collections.Generic;
using System.Data.SQLite;
//https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0
//class to validation for summary methods
namespace Summary
{
    public class Validate{
        public DateTime Date { get; set; }

        public Validate()
        {
            
        }
        
        public bool dateTimeValidate(int year = 1, int month = 1, int day = 1){
            if(year > 0 && IsLeapYear(year) == true && month == 2){
                if((day >= 0 && day <= 29)){
                    Console.WriteLine("Leap Year");
                    return true;
                }
            }
            if(year > 0 && IsLeapYear(year) == false && month == 2){
                if((day > 0 && day <= 28) && (month > 0 && month <= 12)){ 
                    Console.WriteLine("Feb but Not leap year");       
                    return true;
                }
            }else{
                if((year > 0) && (day > 0 && day <= 31) && (month > 0 && month <= 12)){
                    Console.WriteLine("Not leap year not feb");
                    return true;
                }           
            }return false;
        }

        public static bool IsLeapYear(int year){
            if(year % 400 == 0 ||(year % 4 == 0 && year % 100 != 0)){
                Console.WriteLine("Leap Year");
                return true;
            }return false;
        }   

    }
}


