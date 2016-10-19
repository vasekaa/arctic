using System;
using System.Collections;
using System.Collections.Generic;

namespace ArcticDB
{
    internal class LoginServiceStub : ILoginService
    {
        public bool checkPassword(string login, string password)
        {
            if (login == null || password == null)
                return false;
            return password.Equals("test");
        }

        public List<string> getUserAccounts()
        {
            List<string> accounts = new List<string>();
            accounts.Add("Administrator");
            accounts.Add("User");
            return accounts;
        }
    }
}