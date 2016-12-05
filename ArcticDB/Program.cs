using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcticDB
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static SQLiteConnection conn = null;
        public static string applicationReportsPath = ".\\ReportsArctic\\";
        public static string ActiveDBName = "arctic.db";
        public static string BackUpDBName = "BackupDb.db";
        public static string dbExportFileName = "DBExported.zip";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartDBConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            logger.Debug("Exiting program");
            conn.Dispose();
        }
        public static void StartDBConnection()
        {
            logger.Debug("StartDBConnection");
            conn = new SQLiteConnection("Data Source=arctic.db; Version=3;foreign keys=true;");
            try
            {
                conn.Open();
            }
            catch (SQLiteException ex)
            {
                logger.Error("Starting DB connection error", ex);
            }
        }
        public static void CloseDbConnection()
        {
            logger.Debug("CloseDbConnection");
            conn.Dispose();
        }
        public static void backUpDb()
        {
            logger.Debug("backUpDb");
            using (var destination = new SQLiteConnection("Data Source=BackupDb.db; Version=3;foreign keys=true;"))
            {
                destination.Open();
                conn.BackupDatabase(destination, "main", "main", -1, null, 0);
            }
        }
    }
}
