using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticDB.Servicies.Impl
{
    class UserServiceImpl : IUserService
    {
        private const string SELECT_USER_PASSWORD_BY_NAME = "SELECT passwordHash FROM Users WHERE name = @name";
        private const string INSERT_USER_PASSWORD_BY_NAME = "UPDATE Users SET passwordHash=@passwordHash WHERE name = @name";

        public bool chechUserPermission(string permissions)
        {
            throw new NotImplementedException();
        }

        public string getUserPasswordByName(string name)
        {
            SQLiteCommand fetchMeta = new SQLiteCommand(Program.conn);
            fetchMeta.CommandText = SELECT_USER_PASSWORD_BY_NAME;
            fetchMeta.Parameters.Add(new SQLiteParameter("@name", name));
            String passwordHash = null;
            try
            {
                SQLiteDataReader r = fetchMeta.ExecuteReader();
                while (r.Read())
                {
                    passwordHash = r["passwordHash"].ToString();
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return passwordHash;
        }

        public void setUserPasswordByName(string name, string password)
        {
            SQLiteCommand insertSQL = new SQLiteCommand(INSERT_USER_PASSWORD_BY_NAME, Program.conn);
            insertSQL.Parameters.Add(new SQLiteParameter("@name", name));
            insertSQL.Parameters.Add(new SQLiteParameter("@passwordHash", password));
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setUserPermissions(string login)
        {
            throw new NotImplementedException();
        }
    }
}
