using ArcticDB.Model;
using ArcticDB.Servicies;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IObjectsOfInvestService objectsOfInvestService = new ObjectsOfInvestServiceImpl();

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
            this.obOfInvestigateListView.Items.Clear();
            loadObjectsList();
            this.obOfInvestigateListView.Refresh();
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
            if (this.obOfInvestigateListView.SelectedIndices.Count > 0)
            {
                ObjectOfInvestigationPojo objectOfInvestigation = new ObjectOfInvestigationPojo();
                objectOfInvestigation.id = Int32.Parse(this.obOfInvestigateListView.SelectedItems[0].SubItems[0].Text);
                objectOfInvestigation.name = this.obOfInvestigateListView.SelectedItems[0].SubItems[1].Text;
                objectOfInvestigation.characteristics = objectsOfInvestService.getObjectCharactsByObjctId(objectOfInvestigation.id);
                var modObOfInvest = new ObjectOfInvestigationEdit(e);
                modObOfInvest.selectedObjectOfInvestigation = objectOfInvestigation;
                modObOfInvest.ShowDialog(this);
                this.obOfInvestigateListView.Items.Clear();
                loadObjectsList();
                this.obOfInvestigateListView.Refresh();
            }
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
