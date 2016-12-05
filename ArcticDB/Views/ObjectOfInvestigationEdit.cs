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
    public partial class ObjectOfInvestigationEdit : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ObjectOfInvestigationPojo selectedObjectOfInvestigation = null;
        IObjectsOfInvestService objectsOfInvestService = new ObjectsOfInvestServiceImpl();
        ICharacteristicsService characteristicsService = new CharacteristicsServiceImpl();
        public ObjectOfInvestigationEdit()
        {
            InitializeComponent();
            initializeLists();
        }
        public ObjectOfInvestigationEdit(EventArgs e)
        {
            InitializeComponent();
            initializeLists();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedObjectOfInvestigation == null)
            {
                ObjectOfInvestigationPojo objectOfInvestigationPojo = new ObjectOfInvestigationPojo();
                objectOfInvestigationPojo.name = this.OjectName.Text;
                foreach (ListViewItem item in selectedCharectlistView.Items)
                {
                    Characteristic characteristic = new Characteristic(Int32.Parse(item.SubItems[0].Text), item.SubItems[1].Text);
                    objectOfInvestigationPojo.characteristics.Add(characteristic);
                }
                objectsOfInvestService.addObjectOfInvestigation(objectOfInvestigationPojo);
            }
            else//UPDATE Object of Investigation with characteristics
            {

            }
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
        private void initializeLists()
        {
            List<Characteristic> characteristics = characteristicsService.getAllCharacteristics();
            foreach (Characteristic charact in characteristics)
            {
                string[] row = { charact.id.ToString(), charact.name };
                ListViewItem item = new ListViewItem(row);
                this.availableCharactlistView.Items.Add(item);
            }
            if (selectedObjectOfInvestigation != null) {
                this.OjectName.Text = selectedObjectOfInvestigation.name;
                foreach (Characteristic charact in selectedObjectOfInvestigation.characteristics)
                {
                    string[] row = { charact.id.ToString(), charact.name };
                    ListViewItem item = new ListViewItem(row);
                    this.selectedCharectlistView.Items.Add(item);
                }
            }
        }
    }
}
