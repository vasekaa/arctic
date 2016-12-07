using ArcticDB.Model;
using ArcticDB.Servicies;
using ArcticDB.Servicies.Impl;
using NLog;
using System;
using System.Collections;
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
    public partial class AddProbe : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ISamplesService sampleService = new SamplesServiceImpl();
        IUserService permissionChecker = new UserServiceImpl();
        string tempPath;
        string UserTmpPathString;
        SamplePojo selectedSample=null;

        public AddProbe(int sampleId)
        {
            InitializeComponent();
            InitPermissionsControl();
            tempPath = System.IO.Path.GetTempPath();
            UserTmpPathString = System.IO.Path.Combine(tempPath, "ReportsArctic");
            System.IO.Directory.CreateDirectory(UserTmpPathString);
            if (sampleId == -1)
            {
                maskedTextBox1.Text = DateTime.Today.ToShortDateString();
            }
            else
            {
                this.Text = "Исследование #"+ sampleId;
                selectedSample =  sampleService.getSampleBySampleId(sampleId);
                if (selectedSample == null)
                {
                    this.Dispose();
                    return;
                }
                else
                   initComponentsBySample();
            }
        }

        private void InitPermissionsControl()
        {
            if(!permissionChecker.chechUserPermission(Permissions.ADD_SAMPLES))
                this.SaveSampleButton.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.ADD_FILE))
                this.addFileButton.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.ADD_KEYWORDS))
                this.keyWordTextBox.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.REMOVE_FILE))
                this.deleteFileButton.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.ADD_SAMPLES))
                this.maskedTextBox1.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.ADD_SAMPLES))
                this.NameTextBox.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.ADD_KEYWORDS))
                this.deleteKeyword.Enabled = false;
            if (!permissionChecker.chechUserPermission(Permissions.EXPORT_FILES))
                this.exportButton.Enabled = false;
        }

        private void initComponentsBySample()
        {
            this.maskedTextBox1.Text = selectedSample.Date;
            foreach (MetaObject itemMeta in selectedSample.metaList)
            {
                if (itemMeta.type == 0)
                {
                    string[] row = { itemMeta.Value };
                    ListViewItem item = new ListViewItem(row);
                    this.listView1.Items.Add(item);
                }
                else
                {
                    String visibleFileName = FilesUtil.getVisibleFileNameByMetaItem(itemMeta.Value);
                    String storageFileName = FilesUtil.getStorageFileNameByMetaItem(itemMeta.Value);
                    string[] row = { visibleFileName,storageFileName};
                    ListViewItem item = new ListViewItem(row);
                    this.listView2.Items.Add(item);

                    copyFilesFromApplicationToTmpDir(visibleFileName, storageFileName);
                }
                
            }
            this.NameTextBox.Text = selectedSample.name;
        }

        private void copyFilesFromApplicationToTmpDir(string visibleFileName, string storageFileName)
        {
            try
            {
                File.Copy(Path.Combine(Program.applicationReportsPath, storageFileName), Path.Combine(UserTmpPathString, storageFileName), true);
            }
            catch(Exception e)
            {
                logger.Error(e);
                throw e;
            }
        }

        private void AddProbe_Load(object sender, EventArgs e)
        {

        }

        private void addFile_Click(object sender, EventArgs e)
        {
            string randomFileName = System.Guid.NewGuid().ToString();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Файлы Excel (*.xls; *.xlsx) | *.xls; *.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filename = Path.GetFileName(openFileDialog.FileName);
                if (this.listView2.FindItemWithText(filename) == null)
                {
                    try
                    {
                        File.Copy(openFileDialog.FileName, Path.Combine(UserTmpPathString, randomFileName), true);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        throw ex;
                    }
                    
                    string[] row = { filename, randomFileName };
                    ListViewItem item = new ListViewItem(row);
                    this.listView2.Items.Add(item);
                    this.listView2.Refresh();
                }
                else
                {
                    MessageBox.Show("Файл с таким именем уже есть.\nПереименуйте файл что бы добавить, \nили удалите уже добавленный.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


        }

        private void probTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteFileButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
                try
                {
                    File.Delete(Path.Combine(UserTmpPathString, eachItem.SubItems[1].Text));
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
                
            }
        }

        private void catchEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] row = { this.keyWordTextBox.Text };
                ListViewItem item = new ListViewItem(row);
                this.listView1.Items.Add(item);
                this.listView1.Refresh();
                this.keyWordTextBox.Clear();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            SamplePojo sample = new SamplePojo();
            sample.name = NameTextBox.Text;
            DateTime date;
            sample.Date = maskedTextBox1.Text.ToString();
            if (sample.name == null || sample.name.Equals(""))
            {
                MessageBox.Show("Исследование нельзя сохранить без имени",
                       "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!DateTime.TryParse(sample.Date, out date) || date.CompareTo(new DateTime(1911, 01, 01, 01, 00, 0))<0 || date.CompareTo(new DateTime(2050, 01, 01, 01, 00, 0))>0)
            {
                MessageBox.Show("Введите корректную дату",
                       "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            List<MetaObject> metaObjests = new List<MetaObject>();
            ArrayList filesList = new ArrayList();
            foreach (ListViewItem item in this.listView1.Items)
            {
                MetaObject key = new MetaObject(0,item.SubItems[0].Text);
                metaObjests.Add(key);
            }
            foreach (ListViewItem item in this.listView2.Items)
            {
                MetaObject key = new MetaObject(1, item.SubItems[0].Text+"-->"+ item.SubItems[1].Text);
                metaObjests.Add(key);
                filesList.Add(item.SubItems[1].Text);//storageNames
            }
            sample.metaList = metaObjests;
            if (selectedSample!=null)//EditSample case
            {
                sampleService.removeMetaBySample(selectedSample.id);
                sample.id = selectedSample.id;
                sampleService.updateSample(sample);
                sampleService.addMetaBySample(sample);
                copyFilesToAppDir(filesList);
            }
            else//SaveNewSample case
            {
                sampleService.addSample(sample);
                copyFilesToAppDir(filesList);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void copyFilesToAppDir(ArrayList filesList)
        {
            foreach (String fileName in filesList)
            {
                try
                {
                    File.Copy(Path.Combine(UserTmpPathString, fileName), Path.Combine(Program.applicationReportsPath, fileName), true);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
        }

        private void fileListDoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView2.SelectedItems;
                String storageFileName = items[0].SubItems[1].Text.ToString();
                String fileToOpen = items[0].SubItems[0].Text.ToString();
                if (Program.DissallowedExtensions.Contains(Path.GetExtension(fileToOpen)))
                {
                    MessageBox.Show("Вы пытаетесь открыть файл запрещенного формата: "+ Program.DissallowedExtensions,
                       "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                 }
                try
                {
                    File.Copy(Path.Combine(UserTmpPathString, storageFileName), Path.Combine(UserTmpPathString, fileToOpen), true);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
                try
                {
                    System.Diagnostics.Process.Start(Path.Combine(UserTmpPathString, fileToOpen));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("На вашем компьютере не установлено приложение для просмотра данного типа файлов\n Пожалуйста выгрузите файл на сменный носитель и откройте на другом компьютере",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem eachItem in listView2.SelectedItems)
                {
                    try
                    {
                        File.Copy(Path.Combine(UserTmpPathString, eachItem.SubItems[1].Text), Path.Combine(folderBrowserDialog1.SelectedPath, eachItem.SubItems[0].Text), true);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        throw ex;
                    }
                    
                }
            }
            
        }
    }
}
