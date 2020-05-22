using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ChainOfResponsibility
{
    public class HandlerOne : Handler
    {
        public HandlerOne()
        {
        }

        public override void HandleRequest(int days)
        {
            if (days<10)
            {
                Console.WriteLine("我是处理1，我可以决定通过");
            }
            else
            {
                if (GetNextHandler()!=null)
                {
                    GetNextHandler().HandleRequest(days);
                }
                else
                {
                    Console.WriteLine("无人处理请求");
                }
            }
        }
    }
}
