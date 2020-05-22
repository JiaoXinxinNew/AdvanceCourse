using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ObserverPattern
{
    public class Binary : IObserver
    {
        public void Action()
        {
            Console.WriteLine("我是二进制");
        }
    }
}
