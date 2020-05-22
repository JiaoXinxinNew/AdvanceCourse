using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepository
{
    public class Singleton3
    {
        /// <summary>
        /// 在第一次使用这个类之前，由CLR保证只初始化一次，这个比构造函数还早
        /// </summary>
        private static Singleton3 _Singleton3 = new Singleton3();

        /// <summary>
        /// 返回该对象的实例，创建对象。
        /// </summary>
        /// <returns></returns>
        public Singleton3 CreateInstance()
        {
            return _Singleton3;
        }
    }
}
