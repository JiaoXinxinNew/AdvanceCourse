using Libraries.DAL;
using Libraries.Framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Factory
{
    public class DALFactory
    {
       /// <summary>
       /// 使用静态构造函数，通过反射获取类型，防止每一次调用都要加载，减慢速度
       /// </summary>
        static DALFactory()
        {
            //获取程序集
            Assembly assembly = Assembly.Load(StaticConstant.DALDllName);
            //获取类型
            _DALType = assembly.GetType(StaticConstant.DALTypeName);
        }
        private static Type _DALType=null;
        
        /// <summary>
        /// 创建BaseDAL实体
        /// </summary>
        /// <returns>返回IBaseDAL实体类</returns>
        public static IBaseDAL CreateInstance()
        {
            return Activator.CreateInstance(_DALType) as IBaseDAL;
        }
    }
}
