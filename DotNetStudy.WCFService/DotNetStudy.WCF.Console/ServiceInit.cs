using DotNetStudy.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Console
{
    public class ServiceInit
    {
        public static void Process()
        {
            List<ServiceHost> hosts = new List<ServiceHost>()
        {
            //new ServiceHost(typeof(MathService)),
            new ServiceHost(typeof(CalculatorService))
        };
            foreach (var host in hosts)
            {
                host.Opening += (s, e) => System.Console.WriteLine($"{host.GetType().Name} 准备打开");
                host.Opened += (s, e) => System.Console.WriteLine($"{host.GetType().Name} 已经正常打开");
                host.Closing += (s, e) => System.Console.WriteLine($"{host.GetType().Name} 准备关闭");
                host.Closed += (s, e) => System.Console.WriteLine($"{host.GetType().Name} 准备关闭");

                host.Open();
            }
            System.Console.WriteLine("输入任何字符，就停止");
            System.Console.Read();
            foreach (var host in hosts)
            {
                host.Close();
            }
            System.Console.Read();
        }
    }
}
