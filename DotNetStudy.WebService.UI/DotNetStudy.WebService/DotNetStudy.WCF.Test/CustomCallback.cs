using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Test
{
    public class CustomCallback : MyWCFDoubleService.ICalculatorServiceCallback
    {
        public void Show(int m, int n, int result)
        {
            Console.WriteLine($"回调：{m}+{n}={result} ThreadId:{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
