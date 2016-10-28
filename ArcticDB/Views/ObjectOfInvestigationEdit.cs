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
    public partial class ObjectOfInvestigationEdit : Form
    {
        IObjectsOfInvestService objectsOfInvestService = new ObjectsOfInvestServiceImpl();

        public ObjectOfInvestigationEdit()
        {
            InitializeComponent();
        }
        public ObjectOfInvestigationEdit(EventArgs e)
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ObjectOfInvestigationPojo objectOfInvestigationPojo = new ObjectOfInvestigationPojo();
            objectOfInvestigationPojo.name = this.OjectName.Text;
            foreach(ListViewItem item in selectedCharectlistView.Items)
            {
                Characteristic characteristic = new Characteristic(Int32.Parse(item.SubItems[0].Text), item.SubItems[1].Text);
                objectOfInvestigationPojo.characteristics.Add(characteristic);
            }
            objectsOfInvestService.addObjectOfInvestigation(objectOfInvestigationPojo);
        }

        private void addCharact_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem listViewItem in availableCharactlistView.SelectedItems)
            {
                availableCharactlistView.Items.Remove(listViewItem);
                this.selectedCharectlistView.Items.Add(listViewItem);
            }
        }

        private void removeCharact_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in selectedCharectlistView.SelectedItems)
            {
                selectedCharectlistView.Items.Remove(listViewItem);
                this.availableCharactlistView.Items.Add(listViewItem);
            }
        }
    }
}
