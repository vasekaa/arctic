using System;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal interface IUserService
    {
        void setUserPermissions(string login);
        Boolean chechUserPermission(string permissions);
        String getUserPasswordByName(string name);
        void setUserPasswordByName(string name,string password);
        List<String> getUserPermissionsByUserName(string name);
    }
}