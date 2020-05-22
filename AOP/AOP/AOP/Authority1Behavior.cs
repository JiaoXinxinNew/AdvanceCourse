using AOP.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOP.AOP
{
    class Authority1Behavior : IInterceptionBehavior
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
            var method = input.MethodBase;
            if (method.IsDefined(typeof(AuthorityAttribute),true))
            {
                Console.WriteLine("排名第二");
                return getNext().Invoke(input, getNext);
            }
            else
            {
                throw new Exception("账号不对");
            }
        }
    }
}
