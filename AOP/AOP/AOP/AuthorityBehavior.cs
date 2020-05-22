using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOP.AOP
{
    class AuthorityBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get { return true; }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user!=null&& user.Name=="123456")
            {
                Console.WriteLine("排名第一");
                return getNext().Invoke(input, getNext);
            }
            else
            {
                throw new Exception("账号不对");
            }
        }
    }
}
