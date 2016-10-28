using ArcticDB.Model;
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
    public partial class Characteriscics : Form
    {
        ICharacteristicsService characteristicsService = new CharacteristicsServiceImpl();
        int charactListViewSelectedItemForChange = -1;
        public Characteriscics()
        {
            InitializeComponent();
            fillCharcteristicsComboBox();
            fillCharactList();

        }

        private void addCharactButton_Click(object sender, EventArgs e)
        {
            Characteristic characteristic = new Characteristic(CharacteristicsTypes.valueOf(charactTypeComboBox.SelectedItem.ToString()), charactNameTextFiled.Text);
            characteristicsService.addCharacteristic(characteristic);
            string[] row = { characteristic.id.ToString(), characteristic.name, characteristic.type.ToString() };
            ListViewItem item = new ListViewItem(row);
            this.characteristicsListView.Items.Add(item);
            this.characteristicsListView.Refresh();
            this.charactNameTextFiled.Clear();
        }
        private void fillCharcteristicsComboBox()
        {
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.INTEGER.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.FLOAT.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.TEXT.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.DATE.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.FILE.ToString());
            this.charactTypeComboBox.SelectedIndex = 0;
        }
        private void fillCharactList()
        {
            List<Characteristic> characteristics = characteristicsService.getAllCharacteristics();
            ListViewItem item = null;
            foreach (Characteristic charact in characteristics)
            {
                string[] row = { charact.id.ToString(), charact.name, charact.type.ToString() };
                item = new ListViewItem(row);
                this.characteristicsListView.Items.Add(item);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

            if (this.characteristicsListView.SelectedIndices.Count > 0)
            {
                int selectedListItemId = this.characteristicsListView.SelectedIndices[0];
                ListViewItem charactListItem = this.characteristicsListView.Items[selectedListItemId];
                int selectedCharactId = Int32.Parse(charactListItem.SubItems[0].Text);
                characteristicsService.removeCharacteristic(selectedCharactId);
                this.characteristicsListView.Items.RemoveAt(selectedListItemId);
                this.characteristicsListView.Refresh();
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (charactListViewSelectedItemForChange > 0)
            {
                ListViewItem charactListItem = this.characteristicsListView.Items[charactListViewSelectedItemForChange];
                int selectedCharactId = Int32.Parse(charactListItem.SubItems[0].Text);

                Characteristic characteristic = new Characteristic(CharacteristicsTypes.valueOf(charactTypeComboBox.SelectedItem.ToString()), charactNameTextFiled.Text, selectedCharactId);
                characteristicsService.updateCharacteristic(characteristic);
                this.characteristicsListView.Items.RemoveAt(charactListViewSelectedItemForChange);
                string[] row = { characteristic.id.ToString(), characteristic.name, characteristic.type.ToString() };
                ListViewItem item = new ListViewItem(row);
                this.characteristicsListView.Items.Add(item);
                this.characteristicsListView.Refresh();
            }
        }

        private void charactList_doubleClick(object sender, EventArgs e)
        {
            if (this.characteristicsListView.SelectedIndices.Count > 0)
            {
                charactListViewSelectedItemForChange = this.characteristicsListView.SelectedIndices[0];
                ListViewItem charactListItem = this.characteristicsListView.Items[charactListViewSelectedItemForChange];
                int selectedCharactId = Int32.Parse(charactListItem.SubItems[0].Text);
                charactTypeComboBox.SelectedIndex = charactTypeComboBox.Items.IndexOf(charactListItem.SubItems[2].Text);

                charactNameTextFiled.Text = charactListItem.SubItems[1].Text;
            }
        }
    }
}
