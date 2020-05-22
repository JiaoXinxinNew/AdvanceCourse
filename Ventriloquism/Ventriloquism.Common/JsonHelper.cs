using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Ventriloquism.Common
{
    /// <summary>
    /// 使用System.Extension下的JavaScriptSerializer对象
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Json字符串转为T类型的对象
        /// </summary>
        /// <typeparam name="T">自定义T类型</typeparam>
        /// <param name="jsonStr">Json字符串</param>
        /// <returns>自定义T类型</returns>
        public static T JsonToObj<T>(string jsonStr)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Deserialize<T>(jsonStr);
        }

        /// <summary>
        /// 对象转为Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>Json字符串</returns>
        public static string ObjTOJosn(object obj)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(obj);
        }
    }
}
