using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ChainOfResponsibility
{
    public class HandlerTwo : Handler
    {
        public override void HandleRequest(int days)
        {
            if (days<20)
            {
                Console.WriteLine("我是处理2，我可以处理");
            }
            else
            {
                if (GetNextHandler()!=null)
                {
                    GetNextHandler().HandleRequest(days);
                }
                else
                {
                    Console.WriteLine("无人处理");
                }
            }
        }
    }
}
