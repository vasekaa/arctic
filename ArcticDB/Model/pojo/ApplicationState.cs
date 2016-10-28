using System.Collections.Generic;

namespace ArcticDB.Model
{
    public static class ApplicationState
    {
        public static User CurrentUser { get; set; }

        public class User
        {
            public User(string name)
            {
                this.login = name;
                this.permissions = new List<string>();
            }
            string login;
            public List<string> permissions;
        }
    }
}