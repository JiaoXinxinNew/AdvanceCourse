﻿using DotNetStudy.RedisHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.RedisHelper.Service
{
   public class RedisStringService: RedisBase, ICache
    {
        #region 赋值
        /// <summary>
        /// 设置key的value
        /// </summary>
        public bool Set<T>(string key, T value)
        {
            return base.iClient.Set<T>(key, value);
        }

        public bool Set<T>(string key, T value, DateTime dt)
        {
            return base.iClient.Set<T>(key, value, dt);
        }
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set<T>(string key, T value, TimeSpan sp)
        {
            return base.iClient.Set<T>(key, value, sp);
        }
        /// <summary>
        /// 设置多个key/value
        /// </summary>
        public void Set(Dictionary<string, string> dic)
        {
            base.iClient.SetAll(dic);
        }

        #endregion

        #region 追加
        /// <summary>
        /// 在原有key的value值之后追加value,没有就新增一项
        /// </summary>
        public long Append(string key, string value)
        {
            return base.iClient.AppendToValue(key, value);
        }
        #endregion

        #region 获取值
        /// <summary>
        /// 获取key的value值
        /// </summary>
        public string Get(string key)
        {
            return base.iClient.GetValue(key);
        }
        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<string> Get(List<string> keys)
        {
            return base.iClient.GetValues(keys);
        }
        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<T> Get<T>(List<string> keys)
        {
            return base.iClient.GetValues<T>(keys);
        }
        #endregion

        #region 获取旧值赋上新值
        /// <summary>
        /// 获取旧值赋上新值
        /// </summary>
        public string GetAndSetValue(string key, string value)
        {
            return base.iClient.GetAndSetValue(key, value);
        }
        #endregion

        //#region 辅助方法
        ///// <summary>
        ///// 获取值的长度
        ///// </summary>
        //public long GetLength(string key)
        //{
        //    return base.iClient.GetStringCount(key);
        //}
        ///// <summary>
        ///// 自增1，返回自增后的值
        ///// </summary>
        //public long Incr(string key)
        //{
        //    return base.iClient.IncrementValue(key);
        //}
        ///// <summary>
        ///// 自增count，返回自增后的值
        ///// </summary>
        //public long IncrBy(string key, int count)
        //{
        //    return base.iClient.IncrementValueBy(key, count);
        //}
        ///// <summary>
        ///// 自减1，返回自减后的值
        ///// </summary>
        //public long Decr(string key)
        //{
        //    return base.iClient.DecrementValue(key);
        //}
        ///// <summary>
        ///// 自减count ，返回自减后的值
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="count"></param>
        ///// <returns></returns>
        //public long DecrBy(string key, int count)
        //{
        //    return base.iClient.DecrementValueBy(key, count);
        //}
        //#endregion
    }
}
