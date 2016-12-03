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
        public static SQLiteConnection conn = null;
        public static string applicationReportsPath = ".\\ReportsArctic\\";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            conn = new SQLiteConnection("Data Source=arctic.db; Version=3;foreign keys=true;");
            try
            {
                conn.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("I'm out of here");
            conn.Dispose();
        }
    }
}
