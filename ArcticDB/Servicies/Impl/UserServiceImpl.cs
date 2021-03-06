﻿using ArcticDB.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 CREATE TABLE Users ( id integer PRIMARY KEY AUTOINCREMENT, name text, permissions integer, passwordHash text )
 CREATE TABLE Permissions ( id integer, name text )
 Данные
 ------------------------------------------
 "1"	"1"	"Администратор"	"255"	"test"
 "2"	"2"	"Пользователь"	"16"	"test3"
 ------------------------------------------
"1"	"1"	    "ADD_FILE"
"2"	"2"	    "REMOVE_FILE"
"3"	"4"	    "ADD_KEYWORDS"
"4"	"8"	    "REMOVE_KEYWORDS"
"5"	"16"	"EXPORT_FILES"
"6"	"32"	"ADMINISTRATION_MENU_ACCESS"
"7"	"64"	"DELETE_SAMPLES"
"8"	"128"	"ADD_SAMPLES"
-------------------------------------------
*/
namespace ArcticDB.Servicies.Impl
{
    class UserServiceImpl : IUserService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private const string SELECT_USER_PASSWORD_BY_NAME = "SELECT passwordHash FROM Users WHERE name = @name";
        private const string INSERT_USER_PASSWORD_BY_NAME = "UPDATE Users SET passwordHash=@passwordHash WHERE name = @name";
        private const string GET_USER_PERMISSIONS = "SELECT Permissions.name AS Name FROM Users LEFT JOIN Permissions ON Users.permissions & Permissions.id WHERE Users.name = @name";

        public List<String> getUserPermissionsByUserName(string name)
        {
            SQLiteCommand fetchUserPermissions = new SQLiteCommand(Program.conn);
            fetchUserPermissions.CommandText = GET_USER_PERMISSIONS;
            fetchUserPermissions.Parameters.Add(new SQLiteParameter("@name", name));
            List<String> pesmissions = new List<string>();
            try
            {
                SQLiteDataReader r = fetchUserPermissions.ExecuteReader();
                while (r.Read())
                {
                    pesmissions.Add(r["Name"].ToString());
                }
                r.Close();
            }
            catch (SQLiteException ex)
            {
                logger.Error(ex);
            }
            return pesmissions;
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
                logger.Error(ex);
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
                logger.Error(ex);
                throw new Exception(ex.Message);
            }
        }

        public void setUserPermissions(string login)
        {
            ApplicationState.User user = new ApplicationState.User(login);
            user.permissions= getUserPermissionsByUserName(login);
            ApplicationState.CurrentUser = user;
        }

        public bool chechUserPermission(string permissions)
        {
            if (ApplicationState.CurrentUser.permissions.Contains(permissions))
                return true;
            else
                return false;

        }
    }
}
