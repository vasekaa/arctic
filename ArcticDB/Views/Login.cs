using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcticDB
{
    public partial class Login : Form
    {
        ILoginService loginService = new LoginServiceImpl();
        IUserService userService = new UserServiceStub();

        public Login()
        {
            InitializeComponent();
            foreach(string loginAccount in loginService.getUserAccounts()){
                this.loginPicker.Items.Add(loginAccount);
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginAccount = null;
            string accountPassword = this.password.Text;
            if (this.loginPicker.SelectedItem != null)
            {
               loginAccount = this.loginPicker.SelectedItem.ToString();
            }
            
            if (loginService.checkPassword(loginAccount, accountPassword))
            {
                this.loginErrorText.Visible = false;
                userService.setUserPermissions(loginAccount);
                this.Hide();
                var mainWindowForm = new MainWindow();
                mainWindowForm.Closed += (s, args) => this.Close();
                mainWindowForm.Show();
            }
            else
            {
                this.loginErrorText.Visible = true;
            }
        }

    }
}
