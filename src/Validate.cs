using System;
using System.Collections.Generic;
using System.Data.SQLite;
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0
//class to validation for summary methods
namespace Summary
{
    public class Validate{
        public DateTime Date { get; set; }

        public Validate()
        {
            
        }
        //if leap year day >= 29
        //if feb day >= 28
        //else day >= 31
        //month >= 12 
        
        //try catch

        public bool dateTimeValidate(int day = 1, int month = 1, int year = 1){
            //leap year feb
            if(year > 0 && IsLeapYear(year) == true && month == 2){
                if((day >= 0 && day <= 29) && (month >= 0 && month <= 12)){
                    return true;
                }
            }
            //feb
            if(IsLeapYear(year) == false && month == 2){
                if((day > 0 && day <= 28) && (month > 0 && month <= 12)){
                    return true;
                }
            }else{
                if((day > 0 && day <= 31) && (month > 0 && month <= 12)){
                    return true;
                }            
            }
            return false;
        }

        public static bool IsLeapYear(int year){
            if(year % 400 == 0 ||(year % 4 == 0 && year % 100 != 0)){
                return true;
            }return false;
        }   

    }
}


