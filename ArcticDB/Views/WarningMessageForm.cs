using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcticDB.Views
{
    public partial class WarningMessageForm : Form
    {
        public WarningMessageForm()
        {
            InitializeComponent();
            loadWarningMessage();
        }

        private void loadWarningMessage()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("warning.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    this.textBox1.Text = line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lines = this.textBox1.Text.ToString();
            // Write the string to a file.
            StreamWriter file = new StreamWriter("warning.txt");
            file.WriteLine(lines);
            file.Close();
        }
    }
}
