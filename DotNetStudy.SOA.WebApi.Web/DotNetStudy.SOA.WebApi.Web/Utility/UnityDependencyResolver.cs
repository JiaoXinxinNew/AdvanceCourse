using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace DotNetStudy.SOA.WebApi.Web.Utility
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _UnityContainer = null;
        /// <summary>
        /// 通过构造方法传入依赖容器，方便使用和释放
        /// </summary>
        /// <param name="container"></param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            _UnityContainer = container;
        }
        /// <summary>
        /// 通过构造方法传入
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return new UnityDependencyResolver(this._UnityContainer.CreateChildContainer());//每一个作用于创建一个子容器，也可以不用创建子容器，直接使用 _UnityContainer，因为子容器不需要读取配置文件。
        }

        public void Dispose()
        {
            this._UnityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try//在创建的过程中会依赖很多的Service，有可能出现异常，我们需要将其忽略，因此使用try进行过滤，
            {
                return ContainerFactory.BuildUnityContainer().Resolve(serviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return ContainerFactory.BuildUnityContainer().ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}