using ArcticDB.Model;
using ArcticDB.Servicies;
using ArcticDB.Servicies.Impl;
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
    public partial class ProbList : Form
    {
        ISamplesService sampleService = new SamplesServiceImpl();
        IUserService permissionChecker = new UserServiceImpl();
        public ProbList()
        {
            InitializeComponent();
            InitPermissionsControl();
            fillSampleList();
        }

        private void InitPermissionsControl()
        {
            if (permissionChecker.chechUserPermission(Permissions.ADD_SAMPLES))
                this.AddProbButton.Enabled = false;
            if (permissionChecker.chechUserPermission(Permissions.ADD_SAMPLES))
                this.RemoveProbButton.Enabled = false;
        }

        private void fillSampleList()
        {
            List<SamplePojo> samples = sampleService.getAllSamples();
            foreach(SamplePojo sample in samples)
            {
                string[] row = { sample.name, sample.Date, sample.getKeysString() ,sample.id.ToString() };
                ListViewItem item = new ListViewItem(row);
                this.listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddProbButton_Click(object sender, EventArgs e)
        {
            var addProbeForm = new AddProbe(-1);
            DialogResult result = addProbeForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.listView1.Items.Clear();
                fillSampleList();
            }
        }

        private void RemoveProbButton_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem item in listView1.SelectedItems){
                int sampleId = Int32.Parse(item.SubItems[3].Text);
                List<string> fileList = sampleService.getFilelistBySample(sampleId);
                sampleService.removeSample(sampleId);
                this.listView1.Items.Remove(item);
                foreach (String fileName in fileList)
                {
                    File.Delete(Path.Combine(Program.applicationReportsPath, fileName));
                }
                
            }
        }

        private void doubleClickAction(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

                int sampleId = Int32.Parse(items[0].SubItems[3].Text.ToString());
                var addProbeForm = new AddProbe(sampleId);
                DialogResult result =  addProbeForm.ShowDialog(this);
                if(result == DialogResult.OK)
                {
                    this.listView1.Items.Clear();
                    fillSampleList();
                }
            }
        }
    }
}
