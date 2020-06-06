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
    
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            IUserService userService = ContainerFactory.BuildUnityContainer().Resolve<UserService>();
            return userService.Query(id).ToString() ;
        }
        
        public int GetId(int id=10)
        {
            return id;
        }
        
        public string GetV2()
        {
            return "value V2";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
