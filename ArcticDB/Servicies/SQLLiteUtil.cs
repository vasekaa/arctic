using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticDB.Servicies
{
    class SQLLiteUtil
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static int getLastRowId()
        {
            int id = -1;
            SQLiteCommand insertSQL = new SQLiteCommand("select last_insert_rowid()", Program.conn);
            try
            {
                id = ((int)(Int64)insertSQL.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }
    }
}
