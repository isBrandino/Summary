using System;
using System.Collections.Generic;
using System.Data.SQLite;

//https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0
//USE PREPARED STATEMENTS 
//USE ENCYRPTION

namespace Summary
{
    class Db
    {
        public Db()
        {

        } 
        //https://stackoverflow.com/questions/35374697/how-to-properly-maksfedsdfdsafdsfsffffsfsgggdggdgdgdgdgdgdgddfgddgdgdgdfdfgdgerrgdger vbdfgbrgfgergdgwefewffsdefsdfsdfsdf efwe ce xe f e wse csdf sdfssdvdfvdffghs gdrsrf fvb fg g hfgg df gdrfse4s  ghghg   ge-asynchronous-parallel-database-calls
        public void sqlConnect()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";
            using var con = new SQLiteConnection(cs);
            con.Open();
            sqlInit();
            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"SQLite version: {version}");            
        }

        public void sqlInit()
        {
            //string cs = @"URI=file:.Sum.db";
            string cs = @"URI=file:test.db";
            using (var con = new SQLiteConnection(cs)){
            con.Open();
            using(var cmd = new SQLiteCommand(con)){     
                
		        void runCmd(String a)
                {
                    cmd.CommandText = $"{a}";
                    cmd.ExecuteNonQuery();
                }
                
                runCmd(@"CREATE TABLE IF NOT EXISTS 
                    login(loginId TEXT PRIMARY KEY, username TEXT, password TEXT)");
                
                runCmd(@"CREATE TABLE IF NOT EXISTS 
                    dataTable(dataID INT PRIMARY KEY, dataName TEXT, amount INT, description TEXT)");
                
                runCmd(@"CREATE TABLE IF NOT EXISTS 
                    dateTable(dateID INT PRIMARY KEY, isDay INT, isMonth INT, isYear INT)");
                
                runCmd(@"CREATE TABLE IF NOT EXISTS 
                    loginData(dataID INT, loginID INT, CONSTRAINT loginDataID PRIMARY KEY(dataID,loginID), 
                    FOREIGN KEY(dataID) REFERENCES dateTable(dateID))"); 
                
                runCmd(@"CREATE TABLE IF NOT EXISTS 
                    dateData(dateID, dataID INT, CONSTRAINT dataDataID PRIMARY KEY(dateId, dataID), 
                    FOREIGN KEY(dataID) REFERENCES dataTable(dataID))");

                }
            }
        }

        protected void key()
        {
            //validate keys are unique
            this.key();
        }

        private void sort()
        {

        }
        private void search()
        {

        }

        protected void sqlQuery(string strQuery){
            string cs = @"URI=file:.Sum.db"; 
            using (var con = new SQLiteConnection(cs))
            {
            con.Open();
                using(var cmd = new SQLiteCommand(con)){
                    cmd.CommandText = $"{strQuery}";
                    Console.WriteLine($"{strQuery}");
                    //pass paremeters
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }  
}
