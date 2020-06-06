using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace DotNetStudy.SOA.WebApi.Web.Utility
{
    public class CustomerBasicAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<CustomAllowAnonymousAttribute>().FirstOrDefault() != null)//判断该方法是否不用校验
            {
                return;
            }
            else if (actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<CustomAllowAnonymousAttribute>().FirstOrDefault() != null)//判断该控制器是否不用校验
            {
                return;
            }
            else
            {
                var ticket = actionContext.Request.Headers.Authorization;
                if (ticket == null)//验证是否ticket存在
                {
                    this.HandleUnAuthorization();
                }
                else if (this.ValidateTicket(ticket.Parameter))//验证参数是否正确
                {
                    return;
                }
                else
                {
                    this.HandleUnAuthorization();
                }
            }
        }
        /// <summary>
        /// 验证不通过的处理
        /// </summary>
        private void HandleUnAuthorization()
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
        }
        
        /// <summary>
        /// 验证用户ticket是否正确
        /// </summary>
        /// <param name="encryptTicket">ticket.Parameter</param>
        /// <returns></returns>
        private bool ValidateTicket(string encryptTicket)
        {
            try
            {
                var ticketUserDate = FormsAuthentication.Decrypt(encryptTicket).UserData;
                string[] userDate = ticketUserDate.Split('&');
                string userId = userDate[0];
                string userPwd = userDate[1];
                //从数据库获取账号和密码
                string userIdFromDB = "Admin";
                string userPwdFromDb = "123";
                return userId.Equals(userIdFromDB) && userPwd.Equals(userPwdFromDb);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}