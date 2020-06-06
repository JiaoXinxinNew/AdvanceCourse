using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DotNetStudy.SOA.WebApi.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();//特性路由，WebApi特有的

            config.Routes.MapHttpRoute(
                name: "DefaultApi",//路由名称
                routeTemplate: "api/{controller}/{Action}/{id}",//api/控制器名称/参数
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
