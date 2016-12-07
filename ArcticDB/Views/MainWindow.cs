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
using NLog;

namespace ArcticDB
{
    public partial class MainWindow : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
                using (StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, "warning.txt")))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "The file could not be read:");
            }
            if (line.Length > 5)
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
                StringBuilder deletedFileNames = new StringBuilder();
                ISamplesService sampleService = new SamplesServiceImpl();
                List<String> filesfromSamples = FilesUtil.getStorageFileNamesByMeta(sampleService.getAllMetaByType(1));
                String[] reportFolderFiles = FilesUtil.GetFileNames(Program.applicationReportsPath, "*");
                foreach (String fileFromStorage in reportFolderFiles)
                {
                    if (!filesfromSamples.Contains(fileFromStorage))
                    {
                        deletedFileNames.Append(fileFromStorage).AppendLine();
                        try
                        {
                            File.Delete(Path.Combine(Program.applicationReportsPath, fileFromStorage));
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);
                            throw ex;
                        }

                    }
                }
                MessageBox.Show("Место освобождено, удалены:" + deletedFileNames.ToString(),
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message,
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Program.backUpDb();
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.Arguments = "a -tzip " + Program.dbExportFileName + " @DBExportList.txt";
                    info.WorkingDirectory = Application.StartupPath;
                    info.FileName = @"7za.exe";
                    Process ArchiveProcess = Process.Start(info);
                    ArchiveProcess.WaitForExit();
                    File.Copy(Path.Combine(Application.StartupPath, Program.dbExportFileName), Path.Combine(folderBrowserDialog1.SelectedPath, Program.dbExportFileName), true);
                }
            }
            catch (Exception exep)
            {
                logger.Error(exep, "Couldn't export DB. ");
            }
        }

        private void ImportDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Zip Files|*.zip";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openFileDialog.FileName, Path.Combine(Application.StartupPath, Program.dbExportFileName), true);
                    logger.Error("111 Application.StartupPath - "+ Application.StartupPath);
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.Arguments = "x DBExported.zip -y";
                    info.WorkingDirectory = Application.StartupPath;
                    info.FileName = @"7za.exe";
                    Process unArchiveProcess = Process.Start(info);
                    logger.Error("2222222222222");
                    unArchiveProcess.WaitForExit();
                    logger.Error("3333333333333");
                    Program.CloseDbConnection();
                    logger.Error("44444444444444");
                    GC.Collect();
                    logger.Error("55555555555555");
                    File.Copy(Path.Combine(Application.StartupPath, Program.BackUpDBName), Path.Combine(Application.StartupPath, Program.ActiveDBName), true);
                    logger.Error("6666666666666");
                    Program.StartDBConnection();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
    }
}
