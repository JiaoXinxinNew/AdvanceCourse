using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Common
{
    public static class ConsoleWrite
    {
        private static readonly object _CWLock = new object();
        public static void ConsoleWriteLock(string str)
        {
            lock (_CWLock)
            {
                //System.Threading.Thread.Sleep(500);
                Console.WriteLine(str);
            }
        }
    }
}
