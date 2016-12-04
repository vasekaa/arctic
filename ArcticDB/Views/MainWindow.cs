using System.IO;
using ArcticDB.Model;
using ArcticDB.Servicies;
using ArcticDB.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcticDB.Servicies.Impl;
using System.Diagnostics;

namespace ArcticDB
{
    public partial class MainWindow : Form
    {
        IUserService permissionChecker = new UserServiceImpl();
        public MainWindow()
        {
            InitializeComponent();
            InitPermissionsControl();
        }

        private void InitPermissionsControl()
        {
            if (!permissionChecker.chechUserPermission(Permissions.ADMINISTRATION_MENU_ACCESS))
                this.администрированиеToolStripMenuItem.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.ADD_SAMPLES))
                this.AddProbeToolStripMenuItem.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String line = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("warning.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
            if (line.Length>5)
            {
                MessageBox.Show(line,
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
            

        private void AddProbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addProbeForm = new AddProbe(-1);
            addProbeForm.ShowDialog(this);
        }

        private void ObjectsOfInvestigationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aobOfInvestForm = new ObjectsOfInvestigation();
            aobOfInvestForm.ShowDialog(this);
        }

        private void AvailableCharacteristicsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var charactForm = new Characteriscics();
            charactForm.ShowDialog(this);
        }

        private void probListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var probsForm = new ProbList();
            probsForm.ShowDialog(this);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changePawwordForm = new ChangePassword();
            changePawwordForm.ShowDialog(this);

        }

        private void changeWarningMsgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var warningMessageForm = new WarningMessageForm();
            warningMessageForm.ShowDialog(this);
        }

        private void cleanSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ISamplesService sampleService = new SamplesServiceImpl();
                List<String> filesfromSamples = FilesUtil.getStorageFileNamesByMeta(sampleService.getAllMetaByType(1));
                String[] reportFolderFiles = FilesUtil.GetFileNames(Program.applicationReportsPath,"*");
                foreach (String fileFromStorage in reportFolderFiles)
                {
                    if (!filesfromSamples.Contains(fileFromStorage))
                    {
                        File.Delete(Path.Combine(Program.applicationReportsPath, fileFromStorage));
                    }
                }
                MessageBox.Show("Место освобождено" ,
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.backUpDb();
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Process ArchiveProcess = Process.Start("7za.exe", "a -tzip " + Program.dbExportFileName + " @DBExportList.txt");
                ArchiveProcess.WaitForExit();
                File.Copy(Program.dbExportFileName, Path.Combine(folderBrowserDialog1.SelectedPath, Program.dbExportFileName), true);
            }  
        }

        private void ImportDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip Files|*.zip";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog.FileName, Path.Combine(".\\", Program.dbExportFileName), true);
                Process unArchiveProcess = Process.Start("7za.exe", "x DBExported.zip -y");
                unArchiveProcess.WaitForExit();
                Program.CloseDbConnection();
                GC.Collect();
                File.Copy(Path.Combine(".\\", Program.BackUpDBName), Path.Combine(".\\", Program.ActiveDBName), true);
                Program.StartDBConnection();
            }
        }
    }
}
