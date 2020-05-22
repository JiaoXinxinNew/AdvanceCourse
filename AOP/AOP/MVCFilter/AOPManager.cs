using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOP.MVCFilter
{
    public class AOPManager
    {
        static AOPManager()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string[] filesName = Directory.GetFiles(basePath);
            //加载程序集
            foreach (var fileName in filesName.Where(f => f.EndsWith("dll") || f.EndsWith("exe")))
            {
                //加载程序集，并获取每一个类
                Assembly assembly = Assembly.Load(Path.GetFileNameWithoutExtension(fileName));
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(BaseController).IsAssignableFrom(type))
                    {
                        _ServiceList.Add(type.Name, type);
                    }
                }
            }
        }
        private static Dictionary<string, Type> _ServiceList = new Dictionary<string, Type>();
        public static void Invoke(string typeName, string methodName, params object[] parameters)
        {
           
            Type type = _ServiceList[typeName];
            object service = Activator.CreateInstance(type);
            var method = type.GetMethod(methodName);
            var info = method.Invoke(service, parameters);
            if (method.IsDefined(typeof(LogFilterAttribute), true))
            {
                var logFilter = (LogFilterAttribute)method.GetCustomAttribute(typeof(LogFilterAttribute), true);
                logFilter.Log("我想写个日志");
            }
        }
    }
}
