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
        public ObjectOfInvestigationEdit()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

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
