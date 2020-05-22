using AOP.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.AOP
{
    public interface IUserProcessor
    {
        [AuthorityAttribute]
        void RegUser(User user);
        User GetUser(User user);
    }
}
