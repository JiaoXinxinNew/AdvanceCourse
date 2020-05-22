using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepository
{
    public class Singleton
    {
        private static volatile Singleton _Singleton=null;//线程安全
        private static readonly object Singleton_Lock = new object();
        private Singleton()
        {

        }
        public static Singleton CreateInstance()
        {
            if (_Singleton==null)//避免多个线程多次访问重复加锁等待
            {
                lock (Singleton_Lock)
                {
                    if (_Singleton==null)
                    {
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
        }
    }
}
