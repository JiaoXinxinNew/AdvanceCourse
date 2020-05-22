using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPattern.Common
{
    public static class XMLHelper
    {
        public static T FileToT<T>(string xmlPath)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlPath);
            string xmlContent = File.ReadAllText(path,Encoding.UTF8);
            return XmlDeserialize<T>(xmlContent, Encoding.UTF8);

        }
        /// <summary>
        /// 从XML字符串反序列化对象
        /// </summary>
        /// <typeparam name="T">反序列化后的对象类型</typeparam>
        /// <param name="xmlStr">XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string xmlStr, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(xmlStr))
                throw new ArgumentNullException("xmlPath");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(xmlStr)))
            {
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    return (T)xmlSerializer.Deserialize(sr);
                }
            }
        }

        /// <summary>
        /// XML序列化，将对象转为XML字符串
        /// </summary>
        /// <typeparam name="T">要转化的对象类型</typeparam>
        /// <param name="tObj">要转化的类型参数</param>
        /// <param name="encoding">编码</param>
        /// <returns>序列化之后的字符串</returns>
        public static string XmlSerialize<T>(T tObj, Encoding encoding)
        {
            if (tObj == null)
                throw new ArgumentNullException("xmlStr");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            string xlmContent = string.Empty;
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                mySerializer.Serialize(ms, tObj);
                xlmContent = encoding.GetString(ms.ToArray());
            }
            return xlmContent;
        }
    }
}
