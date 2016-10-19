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
    public partial class AddProbe : Form
    {
        public AddProbe()
        {
            InitializeComponent();
        }

        private void AddCharacteristic_Click(object sender, EventArgs e)
        {     
            if (CharacteristicsTableLayout.RowCount < 20) {
                
                Label lblTitle = null;
                lblTitle = new Label();
                lblTitle.Text = ("Новая характеристика" + CharacteristicsTableLayout.RowCount);
                lblTitle.AutoSize = true;
               
                CharacteristicsTableLayout.Controls.Add(lblTitle,0, CharacteristicsTableLayout.RowCount);

                
                if ((CharacteristicsTableLayout.RowCount % 3) == 0)
                {
                    MaskedTextBox txtValue = new MaskedTextBox();
                    txtValue.Mask = "00/00/0000";
                    CharacteristicsTableLayout.Controls.Add(txtValue, 1, CharacteristicsTableLayout.RowCount);
                }
                else
                {
                    TextBox txtValue = new TextBox();
                    CharacteristicsTableLayout.Controls.Add(txtValue, 1, CharacteristicsTableLayout.RowCount);
                }
                CharacteristicsTableLayout.RowCount++;
            }
        }

        private void AddProbe_Load(object sender, EventArgs e)
        {

        }
    }
}
