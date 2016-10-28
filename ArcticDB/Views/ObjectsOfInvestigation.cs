using ArcticDB.Model;
using ArcticDB.Servicies;
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
        IObjectsOfInvestService objectsOfInvestService = new ObjectsOfInvestServiceImpl();
        int charactListViewSelectedItemForChange = -1;
        public ObjectsOfInvestigation()
        {
            InitializeComponent();
            loadObjectsList();
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
            if (this.obOfInvestigateListView.SelectedItems.Count > 0)
            {
                int selectedListItemId = this.obOfInvestigateListView.SelectedIndices[0];
                ListViewItem objectListItem = this.obOfInvestigateListView.Items[selectedListItemId];
                int selectedObjId = Int32.Parse(objectListItem.SubItems[0].Text);
                if (objectsOfInvestService.removeObjectOfInvestigation(selectedObjId) == null)
                {
                    return;
                }
                objectListItem.Remove();
                this.obOfInvestigateListView.Refresh();
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
        private void loadObjectsList()
        {
            List<ObjectOfInvestigationPojo> objectsOfInvestigations = objectsOfInvestService.getAllObjectOfInvestigations();
            ListViewItem item = null;
            foreach (ObjectOfInvestigationPojo objectsOfInvestigation in objectsOfInvestigations)
            {
                string[] row = { objectsOfInvestigation.id.ToString(), objectsOfInvestigation.name};
                item = new ListViewItem(row);
                this.obOfInvestigateListView.Items.Add(item);
            }
        }
    }
}
