using Libraries.Framwork;
using Libraries.Framwork.AttributeExtend;
using Libraries.Framwork.Model;
using Libraries.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.DAL
{
    public class BaseDAL : IBaseDAL
    {
        /// <summary>
        /// 根据ID获取表中的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"{TSqlHelper<T>.SQLFindById}{id}";
            T tInstance = null;// Activator.CreateInstance(type) as T;
            Func<SqlCommand, T> func = new Func<SqlCommand, T>(c =>
            {
                SqlDataReader sqlDataReader = c.ExecuteReader();
                T tResult = ReaderToList<T>(sqlDataReader).FirstOrDefault();
                return tResult;
            });
            tInstance = ExcuteSQL(sql, func);
            return tInstance;
        }

        /// <summary>
        /// 获取表中的所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> FindAll<T>() where T : BaseModel
        {
            Type t = typeof(T);
            List<T> list = null;
            string sql = TSqlHelper<T>.SQLFindAll;
            Func<SqlCommand, List<T>> func = c =>
           {
               SqlDataReader sqlDataReader = c.ExecuteReader();
               return ReaderToList<T>(sqlDataReader);
           };
            list = ExcuteSQL(sql, func);
            return list;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : BaseModel
        {
            entity.Validate();
            Type t = typeof(T);
            var properities = t.GetProperties().Where(p => !p.GetCustomProperityName().Equals("Id"));
            string columnStr = string.Join(",", properities.Select(p => $"{p.GetCustomProperityName()}=@{p.GetCustomProperityName()}"));
            var sqlParameters = properities.Select(p => new SqlParameter($"@{p.GetCustomProperityName()}", p.GetValue(entity) ?? DBNull.Value)).ToArray();
            string sql = $"Update [{t.Name}] SET {columnStr} where id={entity.Id}";
            Func<SqlCommand, int> func = c =>
               {
                   c.Parameters.AddRange(sqlParameters);
                   int tResult = c.ExecuteNonQuery();
                   return tResult;
               };
            int tRes = ExcuteSQL(sql, func);
            if (tRes == 0)
                throw new Exception("DB不存在该ID的数据");
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Insert<T>(T entity) where T : BaseModel
        {
            entity.Validate();
            Type type = typeof(T);
            var properties = type.GetProperties().Where(p => !p.GetCustomProperityName().Equals("Id"));
            string columns = string.Join(",", properties.Select(p => $"[{p.GetCustomProperityName()}]"));
            string Colparameters = string.Join(",", properties.Select(p => $"@{p.GetCustomProperityName()}"));
            string sql = $"INSERT INTO [{type.Name}] ({columns}) VALUES({Colparameters}) ";
            var parameters = properties.Select(p => new SqlParameter($"@{p.GetCustomProperityName()}", p.GetValue(entity))).ToArray();
            Func<SqlCommand, int> func = c =>
               {
                   c.Parameters.AddRange(parameters);
                   return c.ExecuteNonQuery();
               };
            int res = ExcuteSQL(sql, func);
            if (res == 0)
                throw new Exception("添加失败");
        }
        /// <summary>
        /// 根据Id删除表中的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public void Delete<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"{TSqlHelper<T>.SQLDeleteById}{id}";
            Func<SqlCommand, int> func = c =>
                {
                    return c.ExecuteNonQuery();
                };
            int res = ExcuteSQL(sql, func);
            if (res == 0)
                throw new Exception("删除失败");
        }

        #region Privat Methods

        /// <summary>
        /// 将从数据库查询的SqlDataReader数据转为List<T>集合
        /// </summary>
        /// <typeparam name="T">查询的对象</typeparam>
        /// <param name="reader">实例化的SqlDataReader对象</param>
        /// <returns></returns>
        private List<T> ReaderToList<T>(SqlDataReader reader) where T : BaseModel
        {
            List<T> ts = new List<T>();
            Type type = typeof(T);
            while (reader.Read())
            {
                T t = Activator.CreateInstance(type) as T;
                foreach (var property in type.GetProperties())
                {
                    object value = reader[property.GetCustomProperityName()];
                    if (reader[property.Name] is DBNull)
                        value = null;
                    property.SetValue(t, value);
                }
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// 使用委托封装SQL执行的代码
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="func">具体的执行sql的方法</param>
        /// <returns></returns>
        private T ExcuteSQL<T>(string sql, Func<SqlCommand, T> func)
        {
            using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                try
                {
                    sqlCommand.Transaction = sqlTransaction;
                    T tResult = func.Invoke(sqlCommand);
                    sqlTransaction.Commit();
                    return tResult;
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw;
                }
            }
        }
        #endregion
    }
}
