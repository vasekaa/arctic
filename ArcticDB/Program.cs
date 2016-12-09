using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcticDB
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static SQLiteConnection conn = null;
        public static string applicationReportsPath = Path.Combine(Application.StartupPath, "ReportsArctic\\");
        public static string ActiveDBName = "arctic.db";
        public static string DissallowedExtensions = ".exe .bat";
        public static string BackUpDBName = "BackupDb.db";
        public static string dbExportFileName = "DBExported.zip";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            if (DateTime.Now.CompareTo(new DateTime(2016, 12, 8, 00, 00, 0))>0)
            {
                Environment.Exit(0);
            }
            */
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
            logger.Error("StartDBConnection Application.StartupPath - " + Application.StartupPath);
            logger.Debug("StartDBConnection");
            string databaseName = Path.Combine(Application.StartupPath, ActiveDBName);
            logger.Error("backUpDb databaseName - " + databaseName);
            conn = new SQLiteConnection(string.Format("Data Source={0}; Version=3;foreign keys=true;", databaseName));
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
            string databaseName = Path.Combine(Application.StartupPath, BackUpDBName);
            logger.Error("backUpDb databaseName - " + databaseName);
            using (var destination = new SQLiteConnection(string.Format("Data Source={0}; Version=3;foreign keys=true;", databaseName)))
            {
                destination.Open();
                conn.BackupDatabase(destination, "main", "main", -1, null, 0);
            }
        }
    }
}
