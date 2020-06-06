using DotNetStudy.SOA.WebApi.Web.Utility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace DotNetStudy.SOA.WebApi.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));//允许所有东西跨域
            config.DependencyResolver = new UnityDependencyResolver(ContainerFactory.BuildUnityContainer());//将依赖注入容器换成自定义的依赖注入容器。

            config.Filters.Add(new CustomerBasicAuthorizeAttribute());//权限验证全局注册
            config.Filters.Add(new CustmoerExceptionFilterAttribute());//方法内异常处理全局注册

            config.Services.Replace(typeof(IExceptionHandler), new CustomerExceptionHandler());//将异常处理进行替换

            
            // Web API 路由
            config.MapHttpAttributeRoutes();

            //自定义路由
            config.Routes.MapHttpRoute(
             name: "CustomApi",//默认的api路由
             routeTemplate: "api/{controller}/{action}/{id}",//正则规则，以api开头，第二个是控制器  第三个是参数
             defaults: new { id = RouteParameter.Optional }
         );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
