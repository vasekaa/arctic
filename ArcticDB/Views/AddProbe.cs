using ArcticDB.Model;
using ArcticDB.Servicies;
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
        ISamplesService sampleService = new SamplesServiceImpl();
        string tempPath;
        string UserTmpPathString;
        SamplePojo selectedSample=null;

        public AddProbe(int sampleId)
        {
            InitializeComponent();
            tempPath = System.IO.Path.GetTempPath();
            UserTmpPathString = System.IO.Path.Combine(tempPath, "ReportsArctic");

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
            this.textBox1.Text = selectedSample.name;
        }

        private void copyFilesFromApplicationToTmpDir(string visibleFileName, string storageFileName)
        {
            File.Copy(Path.Combine(Program.applicationReportsPath, storageFileName), Path.Combine(UserTmpPathString, visibleFileName), true);
        }

        private void AddProbe_Load(object sender, EventArgs e)
        {

        }

        private void addFile_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(UserTmpPathString);
            string randomFileName = System.Guid.NewGuid().ToString();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Файлы Excel (*.xls; *.xlsx) | *.xls; *.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filename = Path.GetFileName(openFileDialog.FileName);
                if (this.listView2.FindItemWithText(filename) == null)
                {
                    File.Copy(openFileDialog.FileName, Path.Combine(UserTmpPathString, randomFileName), true);
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
                File.Delete(Path.Combine(UserTmpPathString, eachItem.SubItems[1].Text));
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
            sample.name = textBox1.Text;
            sample.Date = maskedTextBox1.Text.ToString();
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
                filesList.Add(item.SubItems[1].Text);
            }
            sample.metaList = metaObjests;
            if (selectedSample!=null)
            {
                sampleService.removeMetaBySample(selectedSample.id);
                sample.id = selectedSample.id;
                sampleService.updateSample(sample);
                sampleService.addMetaBySample(sample);
                copyFilesToAppDir(filesList);
            }
            else
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
                File.Copy(Path.Combine(UserTmpPathString, fileName), Path.Combine(Program.applicationReportsPath, fileName), true);
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
                String fileToOpen = items[0].SubItems[0].Text.ToString();
                Path.Combine(UserTmpPathString, fileToOpen);
                System.Diagnostics.Process.Start(Path.Combine(UserTmpPathString, fileToOpen));
            }
        }
    }
}
