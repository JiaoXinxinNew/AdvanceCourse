using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.MVCFilter
{
    public class LogFilterAttribute : Attribute
    {
        public void Log(string msg)
        {
            Console.WriteLine("写一个日志，信息为:"+msg);
        }
    }
}
