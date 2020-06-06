using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWCFDoubleService.CalculatorServiceClient client = null;
            try
            {
                Console.WriteLine($"双工调用开始 {Thread.CurrentThread.ManagedThreadId}");
                InstanceContext callbackInstance = new InstanceContext(new CustomCallback());
                client = new MyWCFDoubleService.CalculatorServiceClient(callbackInstance);
                client.Plus(123, 234);
                client.Close();
                Console.WriteLine($"双工调用结束 {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception ex)
            {
                if (client != null)
                    client.Abort();
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
