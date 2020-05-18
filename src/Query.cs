using System;
using System.Collections.Generic;
using System.Data.SQLite;

//https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0
//USE PREPARED STATEMENTS 
//USE ENCYRPTION

namespace Summary
{
    class Query : Db 
    {
        Validate verify = new Validate();  
        
        public Query()
        {   
            
        }

       private void addUser(string userName, string passWord){
            //sqlQuery(qry);
        }

        private void getUserQuery(String qry){
            //sqlQuery(qry);
        }

       private void addData(string name, double amount, string details){
        
            // var addQry = ($"Hi {name}");
            // sqlQuery(addQry);
        }

        private void getDataQuery(String qry){
       
            // var addQry = ($"Hi {qry}");
            // sqlQuery(addQry);
        }

        private void addDate(DateTime date){
       
            // var addQry = ($"Hi {qry}");
            // sqlQuery(addQry);
        }

        private void getDateQuery(String qry){
       
            // var addQry = ($"Hi {qry}");
            // sqlQuery(addQry);
        }
    }  
}