﻿using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public WarningMessageForm()
        {
            InitializeComponent();
            loadWarningMessage();
        }

        private void loadWarningMessage()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, "warning.txt")))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    this.textBox1.Text = line;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lines = this.textBox1.Text.ToString();
            // Write the string to a file.
            try
            {
                StreamWriter file = new StreamWriter(Path.Combine(Application.StartupPath, "warning.txt"));
                file.WriteLine(lines);
                file.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            
        }
    }
}
