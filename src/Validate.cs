using System;
using System.Collections.Generic;
using System.Data.SQLite;

//https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0
//class to validation for summary methods
namespace Summary
{
    public class Validate
    {
        private string myPasswordTemp { get; set; }
        public DateTime Date { get; set; }
        
        public Validate()
        {

        }

        public bool DateTimeValidate(int year = 1, int month = 1, int day = 1)
        {
            if (year > 0 && BoolLeapYear(year) == true && month == 2)
            {
                if ((day >= 0 && day <= 29))
                {
                    return true;
                }
            }
            if (year > 0 && BoolLeapYear(year) == false && month == 2)
            {
                if ((day > 0 && day <= 28) && (month > 0 && month <= 12))
                {
                    return true;
                }
            }
            else
            {
                if ((year > 0) && (day > 0 && day <= 31) && (month > 0 && month <= 12))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool BoolLeapYear(int year)
        {

            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                return true;
            }
            return false;
        }
    }
}