using System;
using System.Collections.Generic;
using System.Data.SQLite;

//https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0
//USE PREPARED STATEMENTS 
//USE ENCYRPTION
namespace Summary
{
    //use a hash table to return data items
    class Db
    {
        public Db()
        {

        }
        public void SqlConnect()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";
            using var con = new SQLiteConnection(cs);
            con.Open();
            SqlInit();
            using var cmd = new SQLiteCommand(stm, con);
        }
        //create a default guest table at initalization//
        public void SqlInit()
        {
            //string cs = @"URI=file:.main.db";
            string cs = @"URI=file:test.db";
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(con))
                {

                    void RunCmd(String a)
                    {
                        cmd.CommandText = $"{a}";
                        cmd.ExecuteNonQuery();
                    }

                    //https://devdocs.io/sqlite/foreignkeys#parentchild
                    //HOW to add values to to dataDate and loginData
                    //temporary auto increated id for now

                    RunCmd(@"CREATE TABLE IF NOT EXISTS login(loginId TEXT PRIMARY KEY, username TEXT, salt TEXT, hash TEXT)");

                    RunCmd(@"CREATE TABLE IF NOT EXISTS dataTable(dataID INTEGER PRIMARY KEY AUTOINCREMENT, dataName TEXT, amount INT, description TEXT)");

                    RunCmd(@"CREATE TABLE IF NOT EXISTS dateTable(dateID INTEGER PRIMARY KEY AUTOINCREMENT, isMonth INT, isDay INT, isYear INT)");

                    RunCmd(@"CREATE TABLE IF NOT EXISTS loginData(dataID REFERENCES dataTable(dataID), loginId REFERENCES login(loginId),
                    CONSTRAINT loginDataID PRIMARY KEY(dataID,loginID))");

                    RunCmd(@"CREATE TABLE IF NOT EXISTS dateData(dataID REFERENCES dataTable(dataID), dateID REFERENCES dateTable(dateID),
                    CONSTRAINT dataDataID PRIMARY KEY(dateId, dataID))");
                }
            }
        }

        public class DataList<T>
        {
            private List<T> value = new List<T>();
            public void Add(T input)
            {
                value.Add(input);
            }

            private static string Center(String input)
            {
                Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
                return input;
            }


            public void Search()
            {

            }

            public void Update()
            {

            }

            public void Delete()
            {

            }

            public void ListData(string addQry)
            {
                var count = 0;
                string cs = @"URI=file:test.db";
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(addQry, con))
                    {
                        using SQLiteDataReader readit = cmd.ExecuteReader();

                        while (readit.HasRows)
                        {
                            var header = ("{0}\t{1}\t{2}\t{3}",
                            name: "[name] ", total: "[total] ", date: "[date] ", info: "[info] ");

                            while (readit.Read())
                            {
                                count++;
                                var readDate = (readit.GetInt32(4) + "/" + readit.GetInt32(5) + "/" + readit.GetInt32(6));
                                Console.ResetColor();
                                Console.WriteLine(count+".");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n",
                                  header.name + readit.GetString(1),
                                  header.total + readit.GetInt32(2),
                                  header.date + readDate,
                                  header.info + readit.GetString(3));
                            }
                            Console.ResetColor();
                        }
                        Console.Write("\n");
                    }
                }
            }
        }
    }
}