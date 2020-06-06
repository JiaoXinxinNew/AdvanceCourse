using DotNetStudy.SOA.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.SOA.WebApi.Service
{
    public class UserService : IUserService
    {
        public int Query(int i)
        {
            return i;
        }
    }
}
