﻿using ArcticDB.Servicies;
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

namespace ArcticDB
{
    public partial class Login : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ILoginService loginService = new LoginServiceImpl();
        IUserService userService = new UserServiceImpl();

        public Login()
        {
            InitializeComponent();
            foreach(string loginAccount in loginService.getUserAccounts()){
                this.loginPicker.Items.Add(loginAccount);
                if (loginAccount.Equals("Пользователь"))
                {
                    this.loginPicker.SelectedItem = "Пользователь";
                }
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
            logger.Debug("Loging user: "+ loginAccount);
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
                logger.Debug("Loging user failed: " + loginAccount);
                this.loginErrorText.Visible = true;
            }
        }

    }
}
