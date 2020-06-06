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

namespace DotNetStudy.SOA.WebApi.Web.Controllers
{
    public class IOCController : ApiController
    {
        private IUserService _UserService = null;
        public IOCController(IUserService userService)
        {
            _UserService = userService;
        }
        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetUser(int id)
        {
            //IUserService userService = ContainerFactory.BuildUnityContainer().Resolve<UserService>();
            return Newtonsoft.Json.JsonConvert.SerializeObject(_UserService.Query(id));
        }
    }
}
