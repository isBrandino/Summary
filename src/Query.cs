using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

// https://github.com/linq2db/linq2db/wiki/Introduction

// https://docs.:qmicrosoft.com/en-us/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-3.1.0


namespace Summary
{
    class Query : Db
    {
        HashSalt hashSalt = new HashSalt();
        DataList<string> listQuery = new DataList<string>();
        string cs = @"URI=file:test.db";


        public Query()
        {
            string userID;
        }

        public void AddUser(string newUsername, string newPassword)
        {
            //insert username salt and hash 
            var addQry = ($"INSERT INTO login(username, salt, hash) VALUES (@username, @salt, @hash)");
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = $"{addQry}";

                    hashSalt = hashSalt.GenerateSaltedHash(64, newPassword);

                    cmd.Parameters.AddWithValue("@username", $"{newUsername}");
                    cmd.Parameters.AddWithValue("@salt", hashSalt.Salt);
                    cmd.Parameters.AddWithValue("@hash", hashSalt.Hash);
                    //!!!***combine and concat salt and hash to make userID***!!!
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddData(string newName, double newAmount, string newDetails)
        {
            var addQry = ($"INSERT INTO dataTable(dataName, amount, description) VALUES (@dataName, @amount, @description)");
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = $"{addQry}";
                    cmd.Parameters.AddWithValue("@dataName", $"{newName}");
                    cmd.Parameters.AddWithValue("@amount", $"{newAmount}");
                    cmd.Parameters.AddWithValue("@description", $"{newDetails}");
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddDate(DateTime newDate)
        {
            var addQry = ($"INSERT INTO dateTable(isMonth, isDay, isYear) VALUES (@isMonth, @isDay, @isYear)");
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = $"{addQry}";
                    cmd.Parameters.AddWithValue("@isMonth", $"{Convert.ToInt32(newDate.Month)}");
                    cmd.Parameters.AddWithValue("@isDay", $"{Convert.ToInt32(newDate.Day)}");
                    cmd.Parameters.AddWithValue("@isYear", $"{Convert.ToInt32(newDate.Year)}");
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //login querty to data querty
        //sets login id for queryies 
        public bool LoginQuery(string oldUsername, string oldPassword)
        {

            (string username, string password) getLogin = ("SELECT * FROM login", "SELECT * FROM login");
            return false;
        }

        //search by name, amount, or details
        public void ByDataQuery(string search)
        {
            var data = $"'{search}'";
            var addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID And dataTable.dataName = {data}");
            listQuery.ListData(addQry);
        }

        public void ByAmountQuery(string search)
        {
            var data = $"'{search}'";
            var addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID And dataTable.dataName = {data}");
            listQuery.ListData(addQry);
        }

        //search by day, or year
        public void ByDateQuery(ConsoleKeyInfo select, string search)
        {
            var addQry = "";
            var data = $"'{search}'";
            switch (select.KeyChar.ToString())
            {
                case "1":
                    addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID And dateTable.isDay = {data}");
                    break;
                case "2":
                    addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID And dateTable.isMonth = {data}");
                    break;
                case "3":
                    addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID And dateTable.isYear = {data}");
                    break;
                default:
                     addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID And dateTable.isYear = {data}");
                    break;
            }
            listQuery.ListData(addQry);
        }


        //list all data saved within users account
        public void ListQueries()
        {
            var addQry = ($"SELECT * from dataTable, dateTable Where dataTable.dataID = dateTable.dateID");
            listQuery.ListData(addQry);
        }

        //output search examples 
        private void examples(int x)
        {

        }
    }
}
