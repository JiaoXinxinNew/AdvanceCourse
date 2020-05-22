using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepository
{
    public class Singleton2
    {
        
        private static Singleton2 _Singleton2 = null;
        /// <summary>
        /// 使用静态构造函数，在第一次调用该类的时候创建，而且只创建一次
        /// </summary>
        static Singleton2()
        {
            _Singleton2 = new Singleton2(); 
        }
        /// <summary>
        /// 返回该对象的实例，创建对象。
        /// </summary>
        /// <returns></returns>
        public static Singleton2 CreateInstance()
        {
            return _Singleton2; 
        }

        /// <summary>
        /// 原型模式，通过内存创建新的对象，避免走构造函数
        /// </summary>
        /// <returns></returns>
        public static Singleton2 CreateInstancePrototype()
        {
            Singleton2 singleton2 = _Singleton2.MemberwiseClone() as Singleton2;
            return singleton2;
        }
    }
}
