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
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.INTEGER.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.FLOAT.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.TEXT.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.DATE.ToString());
            this.charactTypeComboBox.Items.Add(CharacteristicsTypes.FILE.ToString());
            this.charactTypeComboBox.SelectedIndex = 0;
        }

        private void addCharactButton_Click(object sender, EventArgs e)
        {
            characteristicsService.addCharacteristic(new Characteristic(charactTypeComboBox.SelectedValue, charactNameTextFiled.Text));
        }
    }
}
