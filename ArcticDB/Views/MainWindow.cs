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

namespace ArcticDB
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddProbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addProbeForm = new AddProbe();
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
    }
}
