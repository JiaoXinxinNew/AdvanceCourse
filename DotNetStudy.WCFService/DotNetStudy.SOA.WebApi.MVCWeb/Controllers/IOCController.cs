using DotNetStudy.SOA.WebApi.Interface;
using DotNetStudy.SOA.WebApi.Service;
using DotNetStudy.SOA.WebApi.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace DotNetStudy.SOA.WebApi.MVCWeb.Controllers
{
    public class IOCController : ApiController
    {
        public int GetUser(int id)
        {
            IUserService userService = ContainerFactory.BuildUnityContainer().Resolve<UserService>();
            return userService.Query(id);
        }
    }
}
