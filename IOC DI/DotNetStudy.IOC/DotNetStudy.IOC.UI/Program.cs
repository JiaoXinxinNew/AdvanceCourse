using DotNetStudy.IOC.BLL;
using DotNetStudy.IOC.DAL;
using DotNetStudy.IOC.Framework.IOCDI;
using DotNetStudy.IOC.IBLL;
using DotNetStudy.IOC.IDAL;
using DotNetStudy.IOC.Interface;
using DotNetStudy.IOC.Service;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace DotNetStudy.IOC.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnityContainer unityContainer = new UnityContainer();//实例化容器
            //unityContainer.RegisterType<IPhone, ApplePhone>(new SingletonLifetimeManager());//注册类型<接口，实现类>
            //unityContainer.RegisterType<AbstractPad, ApplePad>(new TransientLifetimeManager());//注册类型<抽象父类，抽象实现类>
            //unityContainer.RegisterType<ApplePad, ApplePadChild>(new PerThreadLifetimeManager());//注册类型<父类，子类>
            //unityContainer.RegisterType<IPower, Power>(new PerResolveLifetimeManager());
            //unityContainer.RegisterType<IMicrophone, Microphone>();
            //unityContainer.RegisterType<IHeadphone, Headphone>();
            //unityContainer.RegisterType<IBaseBLL, BaseBLL>();
            //unityContainer.RegisterType<IBaseDAL, BaseDAL>();
            //IPhone phone = unityContainer.Resolve<IPhone>();//解析获取实例

            //phone.Call();//调用
            //ICustomDIContainer customDIContainer = new CustomDIContainer();
            //customDIContainer.RegistType<IPhone, ApplePhone>(LifeTimeType.SingleTon);
            //customDIContainer.RegistType<IPower, Power>(LifeTimeType.SingleTon);
            //customDIContainer.RegistType<IMicrophone, Microphone>(LifeTimeType.SingleTon);
            //customDIContainer.RegistType<IHeadphone, Headphone>(LifeTimeType.SingleTon);
            //customDIContainer.RegistType<IBaseBLL, BaseBLL>(LifeTimeType.SingleTon);
            //customDIContainer.RegistType<IBaseDAL, BaseDAL>(LifeTimeType.SingleTon);
            //IPhone headphone = customDIContainer.Resolve<IPhone>();
            //IPhone phone = customDIContainer.Resolve<IPhone>();
            //Console.WriteLine(object.ReferenceEquals(headphone,phone));
            //headphone.Call();

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ConfigFiles\\Unity.Config");//找配置文件的路径并赋值
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);//将配置文件已config形式打开，并指定文件的映射和用户级别
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);//返回指定的config节点
            IUnityContainer container = new UnityContainer();//创建Unity DI的容器
            section.Configure(container, "DIContainer"); //将默认容器元素中的配置应用于给定容器。

            IPhone phone = container.Resolve<IPhone>("ApplePhone");//通过名解析
            phone.Call();
            IPhone phone1 = container.Resolve<IPhone>("MiPhone");//通过名解析
            IBaseBLL baseBLL = container.Resolve<IBaseBLL>();//含有构造函数参数的解析
            IDBContextDAL<Program> dBContextDAL = container.Resolve<DBContextDAL<Program>>();


        }
    }
}
