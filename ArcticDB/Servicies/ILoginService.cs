using System;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal interface ILoginService
    {
        List<string> getUserAccounts();
        Boolean checkPassword(string login, string password);

    }
}