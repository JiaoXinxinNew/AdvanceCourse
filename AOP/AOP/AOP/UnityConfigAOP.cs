using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace AOP.AOP
{
    public class UnityConfigAOP
    {
        public static void Show()
        {
            User user = new User
            {
                Name = "123456",
                Password = "123456890"
            };
            //{//不是用配置实现AOP
            //    IUnityContainer container = new UnityContainer();
            //    container.RegisterType<IUserProcessor, UserProcessor>();
            //    IUserProcessor userProcessor = container.Resolve<IUserProcessor>();
            //    var use1r = userProcessor.GetUser(user);
            //}
            {
                IUnityContainer container = new UnityContainer();
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "AOPConfig\\AOP.Config");
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                container.RegisterType<IUserProcessor, UserProcessor>();
                configSection.Configure(container, "aopContainer");

                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.GetUser(user);
                
            }
           

        }
    }
}
