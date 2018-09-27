using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ClanBattlesService.Models;
using System.Security.Principal;

namespace ClanBattlesService.Controllers.Auth
{
    public class ClanBattlesAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string username = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
                ClanBattlesEntities _context = new ClanBattlesEntities();
                Gamer gamer =
                    _context.Gamers.SingleOrDefault(x =>
                        x.username.Equals(username) && x.password.Equals(password));
                LanCenter lanCenter =
                    _context.LanCenters.SingleOrDefault(x =>
                        x.username.Equals(username) && x.password.Equals(password));
               
                if (gamer != null)
                {
                    User user = new User();
                    user.username = gamer.username;
                    user.password = gamer.password;
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(user), new string[] { });
                    base.OnActionExecuting(actionContext);
                }
                else if (lanCenter != null)
                {
                    User user = new User();
                    user.username = lanCenter.username;
                    user.password = lanCenter.password;
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(user), new string[] { });
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }


    }
}