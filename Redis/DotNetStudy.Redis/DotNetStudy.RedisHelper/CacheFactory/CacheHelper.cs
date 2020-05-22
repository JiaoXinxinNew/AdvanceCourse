using DotNetStudy.RedisHelper.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.CacheFactory
{
    public class CacheHelper
    {
        private static string IRacTypeConfigReflection = ConfigurationManager.AppSettings["Cache"];
        private static string DllName = IRacTypeConfigReflection.Split(',')[0];
        private static string TypeName = IRacTypeConfigReflection.Split(',')[1];
        public static ICache CreateCacheConfigRelex()
        {
            Assembly assembly = Assembly.Load(DllName);//加载dll文件 
            Type type = assembly.GetType(TypeName);//根据类型名获取dll中的类型 
            var race = (ICache)Activator.CreateInstance(type);//根据类型创建实例
            return race;
        }
    }
}
