using ArcticDB.Model;
using System;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal class UserServiceStub : IUserService
    {
        public bool chechUserPermission(string permissions)
        {
            return true;
        }

        public string getUserPasswordByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<string> getUserPermissionsByUserName(string name)
        {
            throw new NotImplementedException();
        }

        public void setUserPasswordByName(string name, string password)
        {
            throw new NotImplementedException();
        }

        public void setUserPermissions(string login)
        {
            ApplicationState.User user  = new ApplicationState.User(login);
            user.permissions.Add("VIEW_DIRECTORIES");
            ApplicationState.CurrentUser = user;
        }
    }
}