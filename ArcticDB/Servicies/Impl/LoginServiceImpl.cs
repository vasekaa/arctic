using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ArcticDB.Servicies
{
    internal class LoginServiceImpl : ILoginService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public bool checkPassword(string login, string password)
        {
            string passwordHash = "";
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            cmd.CommandText = "SELECT passwordHash FROM Users WHERE name ='"+ login+"'";
            try
            {
                passwordHash = (string)cmd.ExecuteScalar();
                if (passwordHash == null)
                    return false;
                
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }
            return passwordHash.Equals(password);
        }

        public List<string> getUserAccounts()
        {
            SQLiteCommand cmd = new SQLiteCommand(Program.conn);
            List < string > userNames = new List<string>();
            cmd.CommandText = "SELECT name" +" FROM Users";
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                string line = String.Empty;
                while (r.Read())
                {
                    line = r["name"].ToString();
                    userNames.Add(line);
                    logger.Debug("r.Read(): " + line);
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }
            return userNames;
        }
    }
}