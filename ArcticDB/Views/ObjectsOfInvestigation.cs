using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcticDB.Views
{
    public partial class ObjectsOfInvestigation : Form
    {
        public ObjectsOfInvestigation()
        {
            InitializeComponent();
        }

        private void ObjectsOfInvestigation_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modObOfInvest = new ObjectOfInvestigationEdit();
            modObOfInvest.ShowDialog(this);
            var listViewItem = new ListViewItem("item");
            this.obOfInvestigateListView.Items.Add(listViewItem);
        }

        private void obOfInvestigateListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in this.obOfInvestigateListView.SelectedItems)
            {
                listViewItem.Remove();
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modObOfInvest = new ObjectOfInvestigationEdit(e);
            modObOfInvest.ShowDialog(this);
        }
    }
}
