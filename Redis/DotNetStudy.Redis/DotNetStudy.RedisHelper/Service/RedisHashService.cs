using DotNetStudy.RedisHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.Service
{
    public class RedisHashService : RedisBase
    {
        #region 添加
        /// <summary>
        /// 向hashid中添加key value集合
        /// </summary>
        /// <param name="hashId">hashid</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns>是否添加成功，成功：true</returns>
        public bool SetEntryInHash(string hashId, string key, string value)
        {
            return base.iClient.SetEntryInHash(hashId, key, value);

        }

        /// <summary>
        /// 如果hash中不存在hashId则添加，存在则不添加
        /// </summary>
        /// <param name="hashId">hashId</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns>添加：true,不添加：false</returns>
        public bool SetEntryInHashIfNotExists(string hashId, string key, string value)
        {
            return base.iClient.SetEntryInHashIfNotExists(hashId, key, value);
        }

        /// <summary>
        /// 将对象T存储到hash集合中，对象中必须含有唯一的Id,否则不能使用
        /// </summary>
        /// <typeparam name="T">存储到Hash中的类型</typeparam>
        /// <param name="t">存储到Hash中的含唯一Id的实体</param>
        public void StoreAsHash<T>(T t)
        {
            base.iClient.StoreAsHash<T>(t);
        }

        #endregion

        #region 获取
        /// <summary>
        /// 获取对象T中ID为id的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">对象id</param>
        /// <returns>获取T类型的实体</returns>
        public T GetFromHash<T>(object id)
        {
            return base.iClient.GetFromHash<T>(id);
        }

        /// <summary>
        /// 根据HashId获取Hash集合中的所有key-value集合
        /// </summary>
        /// <param name="hashId">hashId</param>
        /// <returns>返回字典</returns>
        public Dictionary<string, string> GetAllEntriesFromHash(string hashId)
        {
            return base.iClient.GetAllEntriesFromHash(hashId);
        }

        /// <summary>
        /// 获取hashId所对应的数据总数
        /// </summary>
        /// <param name="hashId">hashId</param>
        /// <returns></returns>
        public long GetHashCount(string hashId)
        {
            return base.iClient.GetHashCount(hashId);
        }

        /// <summary>
        /// 根据HashId获取所有key
        /// </summary>
        /// <param name="hashId">HashId</param>
        /// <returns>key的List集合</returns>
        public List<string> GetHashKeys(string hashId)
        {
            return base.iClient.GetHashKeys(hashId);
        }

        /// <summary>
        /// 根据HashId获取所有value
        /// </summary>
        /// <param name="hashId">HashId</param>
        /// <returns>value的List集合</returns>
        public List<string> GetHashValues(string hashId)
        {
            return base.iClient.GetHashValues(hashId);
        }

        /// <summary>
        /// 根据HashId和Key获取value
        /// </summary>
        /// <param name="hashId">HashId</param>
        /// <param name="key">Key</param>
        /// <returns>value字符串</returns>
        public string GetValueFormHash(string hashId, string key)
        {
            return base.iClient.GetValueFromHash(hashId, key);
        }

        /// <summary>
        /// 根据HashId和多个key获取多个value
        /// </summary>
        /// <param name="hashId">HashId</param>
        /// <param name="keys">Key</param>
        /// <returns>value字符串</returns>
        public List<string> GetValuesFromHash(string hashId,string[] keys)
        {
            return base.iClient.GetValuesFromHash(hashId, keys);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据HashId和key删除value
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <returns>成功:true</returns>
        public bool RemoveEntryFromHash(string hashId, string key)
        {
            return base.iClient.RemoveEntryFromHash(hashId, key);
        }
        #endregion

        #region 其他
        /// <summary>
        /// 判断hashid数据集中是否存在key的数据
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <returns>存在：true</returns>
        public bool HashContainsEntry(string hashId, string key)
        {
            return base.iClient.HashContainsEntry(hashId, key);
        }
        /// <summary>
        /// 给hashid数据集key的value加countby，返回相加后的数据
        /// </summary>
        public double IncrementValueInHash(string hashId, string key, double countBy)
        {
            return base.iClient.IncrementValueInHash(hashId, key, countBy);
        }
        #endregion
    }
}
