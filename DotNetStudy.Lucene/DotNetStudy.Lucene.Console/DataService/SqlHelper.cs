using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Lucene.Console.DataService
{
    public class SqlHelper
    {
        private static string ConnStr = ConfigurationManager.ConnectionStrings["LAS"].ConnectionString;
        /// <summary>
        /// 根据sql查找数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> QueryList<T>(string sql) where T:new ()
        {
            using (SqlConnection sqlConn=new SqlConnection(ConnStr))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.CommandTimeout = 120;
                return TransList<T>(cmd.ExecuteReader());
            }
        }
        /// <summary>
        /// 将查找的数据匹配到相应的对象上
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<T> TransList<T>(SqlDataReader reader) where T : new()
        {
            List<T> tList = new List<T>();
            Type type = typeof(T);
            var properties = type.GetProperties();
            if (reader.Read())
            {
                do
                {
                    T t = new T();
                    foreach (PropertyInfo p in properties)
                    {
                        p.SetValue(t, Convert.ChangeType(reader[p.Name], p.PropertyType));
                    }
                    tList.Add(t);
                }
                while (reader.Read());
            }
            return tList;
        }


    }
}
