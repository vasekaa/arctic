using System;
using System.Collections.Generic;

namespace ArcticDB
{
    internal interface ILoginService
    {
        List<string> getUserAccounts();
        Boolean checkPassword(string login, string password);

    }
}