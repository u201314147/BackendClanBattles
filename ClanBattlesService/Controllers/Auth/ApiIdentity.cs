using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace ClanBattlesService.Controllers.Auth
{
    public class ApiIdentity : IIdentity
    {
        public User User
        {
            get;
            private set;
        }

        public ApiIdentity(User user)
        {
            if (user == null) throw new ArgumentException("user");
            this.User = user;
        }

        public string Name
        {
            get { return User.username; }
        }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

    }
}