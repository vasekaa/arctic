using System;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal interface IUserService
    {
        void setUserPermissions(string login);
        Boolean chechUserPermission(string permissions);
    }
}