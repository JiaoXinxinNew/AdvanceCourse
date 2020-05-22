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
    public interface IBaseDAL
    {
        /// <summary>
        /// 根据ID获取表中的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : BaseModel;

        /// <summary>
        /// 获取表中的所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> FindAll<T>() where T : BaseModel;

        /// <summary>
        /// 更新表中的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update<T>(T entity) where T : BaseModel;
        /// <summary>
        /// 向表中添加一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert<T>(T entity) where T : BaseModel;
        /// <summary>
        /// 删除表中的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        void Delete<T>(int id) where T : BaseModel;
    }
}
