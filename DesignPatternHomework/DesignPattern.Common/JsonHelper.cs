using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DesignPattern.Common
{
    /// <summary>
    /// 使用System.Extension下的JavaScriptSerializer对象
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 通过文件相对路径将Json转为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonPath">Json相对路径</param>
        /// <returns></returns>
        public static T JsonToObjByPath<T>(string jsonPath,Encoding encoding)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonPath);
            string jsonStr = File.ReadAllText(path,encoding);
            return JsonToObj<T>(jsonStr);
        }
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
