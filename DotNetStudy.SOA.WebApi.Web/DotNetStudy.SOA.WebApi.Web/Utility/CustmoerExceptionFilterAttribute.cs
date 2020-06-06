using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace DotNetStudy.SOA.WebApi.Web.Utility
{
    public class CustmoerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 重写此方法是为了当错误没有被catch时，进行处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1、首先将错误写入日志
            //2、判断是什么错误，看是否需要写入到前端
            //3、将错误返回到前端
            Console.WriteLine(actionExecutedContext.Exception.Message);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, new
            {
                Result = false,
                Msg = "出现异常，请联系管理员"
            });//创建与请求关联的返回信息
        }
    }
}