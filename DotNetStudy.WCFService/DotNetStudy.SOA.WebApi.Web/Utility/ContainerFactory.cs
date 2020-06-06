using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace DotNetStudy.SOA.WebApi.Web.Utility
{
    public class ContainerFactory
    {
        public static IUnityContainer BuildUnityContainer()
        {
            return _Container;
        }
        private static IUnityContainer _Container = null;
        static ContainerFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap(); fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ConfigFiles\\Unity.Config");//找配置文件的路径并赋值 
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);//将配置文件已config形式打开，并指定文件的映射和用户级别 
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);//返回指定的config节点 
            _Container = new UnityContainer();//创建Unity DI的容器 
            section.Configure(_Container, "DIContainer"); //将默认容器元素中的配置应用于给定容器。
            //IPhone phone = container.Resolve<IPhone>("ApplePhone");//通过名解析 
            //IPhone phone1 = container.Resolve<IPhone>("MiPhone");//通过名解析 
            //IBaseBLL baseBLL = container.Resolve<IBaseBLL>();//含有构造函数参数的解析 
            //IDBContextDAL<Program> dBContextDAL = container.Resolve<DBContextDAL<Program>>();
        }
    }
}