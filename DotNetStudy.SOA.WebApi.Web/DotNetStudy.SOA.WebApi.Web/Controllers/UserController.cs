using DotNetStudy.SOA.WebApi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;
using System.Web.Security;
using DotNetStudy.SOA.WebApi.Web.Utility;

namespace DotNetStudy.SOA.WebApi.Web.Controllers
{
    //[CustomerBasicAuthorizeAttribute]
    public class UserController : ApiController
    {
        User user = new User() { Id = 1, Name = "焦鑫鑫", Remark = "Hard Work" };
        [CustomAllowAnonymousAttribute]
        [HttpGet]
        public string Login(string userId, string userPwd)
        {
            if ("Admin".Equals(userId) && "123".Equals(userPwd))
            {
                FormsAuthenticationTicket ticketObject = new FormsAuthenticationTicket(0, userId, DateTime.Now, DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", userId, userPwd), FormsAuthentication.FormsCookiePath);
                var result = new
                {
                    Result = true,
                    Ticket = FormsAuthentication.Encrypt(ticketObject)
                };
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new { Result = false };
                return JsonConvert.SerializeObject(result);
            }
        }
        [HttpGet]
        public User GetUserById(int id)
        {
            return user;
        }
        [HttpGet]
        public User GetUserByName(string Name)
        {
            return user;
        }
    }
}
