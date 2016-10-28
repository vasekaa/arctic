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
    }
}
