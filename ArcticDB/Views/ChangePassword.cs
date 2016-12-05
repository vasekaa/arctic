using ArcticDB.Servicies;
using ArcticDB.Servicies.Impl;
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
    public partial class ChangePassword : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUserService userService = new UserServiceImpl();
        ILoginService loginService = new LoginServiceImpl();
        public ChangePassword()
        {
            InitializeComponent();
            foreach (String name in loginService.getUserAccounts())
            {
                this.comboBox1.Items.Add(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userService.setUserPasswordByName(this.comboBox1.SelectedItem.ToString(), this.textBox1.Text);
        }

        private void onSelectedUser(object sender, EventArgs e)
        {
            this.textBox1.Text = userService.getUserPasswordByName(this.comboBox1.SelectedItem.ToString());
        }
    }
}
