using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ClanBattlesService.Controllers.Auth
{
    [ClanBattlesAuthenticationAttribute]
    public class AuthorizedController : ApiController
    {
        public User AuthorizedUser
        {
            get
            {
                return ((ApiIdentity)HttpContext.Current.User.Identity).User;
            }
        }
    }
}
