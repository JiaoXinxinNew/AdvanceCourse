using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace DotNetStudy.SOA.WebApi.Web.Utility
{
    public class CustomerExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// 判断是否要进行异常处理，规则自己定
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            string url = context.Request.RequestUri.AbsoluteUri;
            return url.Contains("/api/");
        }
        /// <summary>
        /// 完成异常处理
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(ExceptionHandlerContext context)
        {
            //1、写入日志
            //2、请求错误，查看请求错误信息，根据错误信息确定返回信息
            Console.WriteLine(context.Exception.Message);
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(System.Net.HttpStatusCode.OK, new
            {
                Result = false,
                Msg = "出现异常，请联系管理员",
                Debug = context.Exception.Message
            }));
        }
    }
}