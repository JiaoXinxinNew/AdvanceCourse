using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.MVCFilter
{
    public class OrderService : BaseController, IOrderService
    {
        [LogFilter]
        public void Index(int id, string name)
        {
            Console.WriteLine($"这是{name}的第{id}页");
        }
    }
}
