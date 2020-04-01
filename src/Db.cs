using System;
using System.Collections.Generic;
using System.Data.SQLite;
// https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0

namespace Summary
{
    class Db
    {
        SQLiteConnection con;
        public Db()
        {
            
        }

        //create a login and entry database 
        //store name amount and date
        //connection to sqllite   
        //https://stackoverflow.com/questions/35374697/how-to-properly-make-asynchronous-parallel-database-calls
        public void sqlConnect()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"SQLite version: {version}");
        }

        private void key(){

        }

        private void login(){

        }

        private void push(){

        }

        private void pop(){

        }

        private void sort(){
        
        }
        private void search(){

        }

    }
}
